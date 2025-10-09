namespace Infrastructure.Data.Entities;

internal class CategoriaEntity
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public int? HorasAnticipacionReserva { get; set; }
    public ICollection<ClienteEntity> Clientes { get; set; } = null!;
}
