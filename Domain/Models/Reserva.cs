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
    public Cliente Cliente { get; set; } = null!;
    public DateOnly FechaReserva { get; init; }
    public int MesaId { get; set; }
    public Mesa Mesa { get; set; } = null!;
    public EstadoDeReserva Estado { get; set; }
    public DateTime FechaCreacion { get; init; }
}