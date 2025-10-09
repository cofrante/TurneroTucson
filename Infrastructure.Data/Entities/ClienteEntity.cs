namespace Infrastructure.Data.Entities;

internal class ClienteEntity
{
    public Guid Id { get; set; }
    public string Nombre { get; set; } = null!;
    public int CategoriaId { get; set; }
    public CategoriaEntity Categoria { get; set; } = null!;
}
