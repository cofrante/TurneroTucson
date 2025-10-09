namespace Domain.Models;

public class Categoria
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public int? HorasAnticipacionReserva { get; set; }
}
