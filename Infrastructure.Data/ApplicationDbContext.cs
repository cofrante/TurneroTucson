using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

internal class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
        
    }

    public DbSet<ClienteEntity> Clientes { get; set; }
    public DbSet<CategoriaEntity> Categorias { get; set; }
    public DbSet<MesaEntity> Mesas { get; set; }
    public DbSet<ReservaEntity> Reservas { get; set; }
}
