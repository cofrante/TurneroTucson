namespace Domain.Models;

public enum EstadoDeReserva
{
    Confirmada,
    EnEspera,
    Cancelada
}

public class Reserva
{
    public Guid Id { get; init; }
    public Guid ClienteId { get; init; }
    public DateOnly FechaReserva { get; init; }
    public int? NumeroMesa { get; set; }
    public EstadoDeReserva Estado { get; set; }
    public DateTime FechaCreacion { get; init; }
}