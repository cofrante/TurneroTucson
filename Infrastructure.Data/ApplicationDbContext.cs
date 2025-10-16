using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ReservaEntity>()
            .HasOne(r => r.Cliente)
            .WithMany(c => c.Reservas)
            .HasForeignKey(r => r.ClienteId);

        modelBuilder.Entity<ReservaEntity>()
            .HasOne(r => r.Mesa)
            .WithMany(c => c.Reservas)
            .HasForeignKey(r => r.MesaId);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<ClienteEntity> Clientes { get; set; }
    public DbSet<CategoriaEntity> Categorias { get; set; }
    public DbSet<MesaEntity> Mesas { get; set; }
    public DbSet<ReservaEntity> Reservas { get; set; }
    public DbSet<EsperaEntity> Esperas { get; set; }

}
