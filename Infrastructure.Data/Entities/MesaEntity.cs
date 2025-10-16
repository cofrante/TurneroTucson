namespace Infrastructure.Data.Entities;

public class MesaEntity
{
    public int Id { get; set; }
    public int Capacidad { get; set; }
    public bool EstaDisponible { get; set; }
    public ICollection<ReservaEntity> Reservas { get; set; } = [];
}
