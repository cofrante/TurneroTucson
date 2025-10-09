using Domain.Models;

namespace Infrastructure.Data.Entities;

internal class ReservaEntity
{
    public Guid Id { get; init; }
    public Guid ClienteId { get; init; }
    public ClienteEntity Cliente { get; set; } = null!;
    public DateOnly FechaReserva { get; init; }
    public int? NumeroMesa { get; set; }
    public EstadoDeReserva Estado { get; set; }
    public DateTime FechaCreacion { get; init; }
}
