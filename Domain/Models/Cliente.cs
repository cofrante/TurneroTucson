namespace Domain.Models;

public class Cliente
{
    public Guid Id { get; set; }
    public string Nombre { get; set; } = null!;
    public Categoria Categoria { get; set; } = null!;
}
