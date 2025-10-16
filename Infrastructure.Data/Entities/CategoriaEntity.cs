namespace Infrastructure.Data.Entities;

public class CategoriaEntity
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public int? HorasAnticipacionReserva { get; set; }
    public ICollection<ClienteEntity> Clientes { get; set; } = null!;
}
