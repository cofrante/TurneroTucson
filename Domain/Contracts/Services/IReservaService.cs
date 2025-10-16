namespace Domain.Contracts.Services;

using Domain.Models;
using Domain.Pagination;
using System.Threading.Tasks;

public interface IReservaService
{
    Task<Reserva> GetReservaAsync(Guid reservaId);
    Task<PagedResult<Reserva>> ListarReservasAsync(int page, int pageSize);
    Task<Reserva> RegistrarReservaAsync(Guid clienteId, DateOnly fechaReserva, int cantidadCubiertos);
    Task EliminarReservaAsync(Guid reservaId);
    Task<PagedResult<Espera>> ListarClientesEnEsperaAsync(int page, int pageSize);
}