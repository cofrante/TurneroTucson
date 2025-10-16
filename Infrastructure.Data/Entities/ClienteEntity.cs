namespace Infrastructure.Data.Entities;

public class ClienteEntity
{
    public Guid Id { get; set; }
    public string Nombre { get; set; } = null!;
    public int CategoriaId { get; set; }
    public CategoriaEntity Categoria { get; set; } = null!;
    public ICollection<ReservaEntity> Reservas { get; set; } = [];
}
