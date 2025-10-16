using Infrastructure.Data.Entities;
using Domain.Models;

namespace Infrastructure.Data.Mappers;

public static class Mappers
{
    // EsperaEntity <-> Espera
    public static EsperaEntity ToEntity(this Espera espera)
    {
        return new EsperaEntity
        {
            Id = espera.Id,
            ClienteId = espera.ClienteId,
            FechaReserva = espera.FechaReserva,
            CantidadCubiertos = espera.CantidadCubiertos,
            FechaCreacion = espera.FechaCreacion,
            Estado = espera.Estado
        };
    }

    public static Espera ToDomain(this EsperaEntity entity)
    {
        return new Espera
        {
            Id = entity.Id,
            ClienteId = entity.ClienteId,
            FechaReserva = entity.FechaReserva,
            CantidadCubiertos = entity.CantidadCubiertos,
            FechaCreacion = entity.FechaCreacion,
            Estado = entity.Estado
        };
    }

    // ReservaEntity <-> Reserva
    public static ReservaEntity ToEntity(this Reserva reserva)
    {
        return new ReservaEntity
        {
            Id = reserva.Id,
            ClienteId = reserva.ClienteId,
            FechaReserva = reserva.FechaReserva,
            MesaId = reserva.MesaId,
            Estado = reserva.Estado,
            FechaCreacion = reserva.FechaCreacion
        };
    }

    public static Reserva? ToDomain(this ReservaEntity? entity)
    {
        if (entity is null) return null;
        return new Reserva
        {
            Id = entity.Id,
            ClienteId = entity.ClienteId,
            FechaReserva = entity.FechaReserva,
            MesaId = entity.MesaId,
            Mesa = entity.Mesa.ToDomain(),
            Cliente = entity.Cliente.ToDomain(),
            Estado = entity.Estado,
            FechaCreacion = entity.FechaCreacion
        };
    }

    // ClienteEntity <-> Cliente
    public static ClienteEntity ToEntity(this Cliente cliente, CategoriaEntity categoria)
    {
        return new ClienteEntity
        {
            Id = cliente.Id,
            Nombre = cliente.Nombre,
            CategoriaId = categoria.Id,
            Categoria = categoria
        };
    }

    public static Cliente ToDomain(this ClienteEntity entity)
    {
        return new Cliente
        {
            Id = entity.Id,
            Nombre = entity.Nombre,
            Categoria = entity.Categoria.ToDomain()
        };
    }

    // CategoriaEntity <-> Categoria
    public static CategoriaEntity ToEntity(this Categoria categoria)
    {
        return new CategoriaEntity
        {
            Id = categoria.Id,
            Nombre = categoria.Nombre,
            HorasAnticipacionReserva = categoria.HorasAnticipacionReserva
        };
    }

    public static Categoria? ToDomain(this CategoriaEntity? entity)
    {
        if (entity is null) return null;
        return new Categoria
        {
            Id = entity.Id,
            Nombre = entity.Nombre,
            HorasAnticipacionReserva = entity.HorasAnticipacionReserva
        };
    }

    // MesaEntity <-> Mesa
    public static MesaEntity ToEntity(this Mesa mesa)
    {
        return new MesaEntity
        {
            Id = mesa.Id,
            Capacidad = mesa.Capacidad,
            EstaDisponible = mesa.EstaDisponible
        };
    }

    public static Mesa? ToDomain(this MesaEntity? entity)
    {
        if (entity is null) return null;
        return new Mesa
        {
            Id = entity.Id,
            Capacidad = entity.Capacidad,
            EstaDisponible = entity.EstaDisponible
        };
    }
}
