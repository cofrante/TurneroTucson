using Domain.Models;

namespace Infrastructure.Data.Entities;

public class EsperaEntity
{
    public Guid Id { get; set; }
    public Guid ClienteId { get; set; }
    public ClienteEntity Cliente { get; set; }
    public DateOnly FechaReserva { get; set; }
    public int CantidadCubiertos { get; set; }
    public DateTime FechaCreacion { get; set; }
    public EstadoEspera Estado { get; set; }
}
