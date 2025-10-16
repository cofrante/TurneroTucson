using Domain.Models;

namespace Infrastructure.Data.Entities;

public class ReservaEntity
{
    public Guid Id { get; init; }
    public Guid ClienteId { get; init; }
    public ClienteEntity Cliente { get; set; } = null!;
    public DateOnly FechaReserva { get; init; }
    public int MesaId { get; set; }
    public MesaEntity Mesa { get; set; } = null!;
    public EstadoDeReserva Estado { get; set; }
    public DateTime FechaCreacion { get; init; }
}
