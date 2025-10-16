namespace Domain.Models;

public enum EstadoEspera
{
    EnEspera,
    Atendida,
    Cancelada
}

public class Espera
{
    public Guid Id { get; set; }
    public Guid ClienteId { get; set; }
    public DateOnly FechaReserva { get; set; }
    public int CantidadCubiertos { get; set; }
    public DateTime FechaCreacion { get; set; }
    public EstadoEspera Estado { get; set; } = EstadoEspera.EnEspera;
}
