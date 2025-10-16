using Domain.Contracts.Services;
using Domain.Contracts.Repositories;
using Domain.Models;
using Domain.Pagination;

namespace Application.Services;

public class ReservaService(IUnitOfWork unitOfWork) : IReservaService
{
    public async Task<Reserva> GetReservaAsync(Guid reservaId)
    {
        return await unitOfWork.Reservas.GetAsync(reservaId);
    }

    public async Task<PagedResult<Reserva>> ListarReservasAsync(int page, int pageSize)
    {
        return await unitOfWork.Reservas.GetPagedAsync(page, pageSize);
    }

    public async Task<Reserva> RegistrarReservaAsync(Guid clienteId, DateOnly fechaReserva, int cantidadCubiertos)
    {
        if (cantidadCubiertos <= 0)
            throw new Exception("Nadie va a comer?");

        if (fechaReserva < DateOnly.FromDateTime(DateTime.Now))
            throw new Exception("No se puede reservar para fechas que ya pasaron");

        var cliente = await unitOfWork.Clientes.GetAsync(clienteId)
            ?? throw new Exception("Cliente no encontrado");
        var categoria = cliente.Categoria
            ?? throw new Exception("Categoría no encontrada para el cliente");

        if (categoria.HorasAnticipacionReserva.HasValue)
        {
            var horasAnticipacion = (fechaReserva.ToDateTime(TimeOnly.MinValue) - DateTime.Now).TotalHours;
            if (horasAnticipacion < categoria.HorasAnticipacionReserva.Value)
                throw new Exception($"La reserva debe realizarse con al menos {categoria.HorasAnticipacionReserva.Value} horas de anticipación para la categoría {categoria.Nombre}.");
        }

        var mesas = await unitOfWork.Mesas.GetAllAsync();
        var reservas = await unitOfWork.Reservas.GetAllAsync();
        var mesasOcupadas = reservas
            .Where(r => r.FechaReserva == fechaReserva)
            .Select(r => r.MesaId)
            .ToHashSet();
        var mesaDisponible = mesas
            .Where(m => m.EstaDisponible && !mesasOcupadas.Contains(m.Id) && m.Capacidad >= cantidadCubiertos)
            .OrderBy(m => m.Capacidad)
            .FirstOrDefault();

        if (mesaDisponible == null)
        {
            var espera = new Espera
            {
                Id = Guid.NewGuid(),
                ClienteId = clienteId,
                FechaReserva = fechaReserva,
                CantidadCubiertos = cantidadCubiertos,
                FechaCreacion = DateTime.Now,
                Estado = EstadoEspera.EnEspera
            };
            await unitOfWork.Esperas.AddAsync(espera);

            return null;
        }

        var reserva = new Reserva
        {
            Id = Guid.NewGuid(),
            ClienteId = clienteId,
            FechaReserva = fechaReserva,
            MesaId = mesaDisponible.Id,
            Estado = mesaDisponible != null ? EstadoDeReserva.Confirmada : EstadoDeReserva.EnEspera,
            FechaCreacion = DateTime.Now
        };

        await unitOfWork.Reservas.AddAsync(reserva);

        reserva.Cliente = cliente;
        reserva.Mesa = mesaDisponible;

        return reserva;
    }

    public async Task EliminarReservaAsync(Guid reservaId)
    {
        var reserva = await unitOfWork.Reservas.GetAsync(reservaId);

        if (reserva is null)
            return;

        var mesa = await unitOfWork.Mesas.GetAsync(reserva.MesaId);
        mesa.EstaDisponible = true;
        await unitOfWork.Mesas.UpdateAsync(mesa);

        await unitOfWork.Reservas.DeleteAsync(reservaId);
        await ReasignarMesasLiberadasAsync();
    }

    public async Task<PagedResult<Espera>> ListarClientesEnEsperaAsync(int page, int pageSize)
    {
        return await unitOfWork.Esperas.GetPagedAsync(page, pageSize);
    }

    private async Task ReasignarMesasLiberadasAsync()
    {
        var esperas = (await unitOfWork.Esperas.GetAllAsync())
            .Where(e => e.Estado == EstadoEspera.EnEspera)
            .ToList();
        var reservas = await unitOfWork.Reservas.GetAllAsync();
        var mesas = await unitOfWork.Mesas.GetAllAsync();
        var mesasOcupadas = reservas
            .Where(r => r.Estado == EstadoDeReserva.Confirmada)
            .Select(r => r.MesaId)
            .ToHashSet();
        var mesasDisponibles = mesas
            .Where(m => m.EstaDisponible && !mesasOcupadas.Contains(m.Id))
            .OrderBy(m => m.Capacidad)
            .ToList();

        foreach (var espera in esperas)
        {
            var cliente = await unitOfWork.Clientes.GetAsync(espera.ClienteId);
            if (cliente == null) continue;
            var mesa = mesasDisponibles.FirstOrDefault(m => m.Capacidad >= espera.CantidadCubiertos);
            if (mesa != null)
            {
                var reserva = reservas.FirstOrDefault(r => r.ClienteId == espera.ClienteId && r.FechaReserva == espera.FechaReserva && r.Estado == EstadoDeReserva.EnEspera);
                if (reserva != null)
                {
                    reserva.MesaId = mesa.Id;
                    reserva.Estado = EstadoDeReserva.Confirmada;
                    await unitOfWork.Reservas.UpdateAsync(reserva);
                }
                espera.Estado = EstadoEspera.Atendida;
                await unitOfWork.Esperas.UpdateAsync(espera);
                mesasDisponibles.Remove(mesa);
            }
        }
    }
}
