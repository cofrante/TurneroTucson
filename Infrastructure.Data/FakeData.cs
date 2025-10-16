using Infrastructure.Data.Entities;

namespace Infrastructure.Data;

public static class FakeData
{
    public static void Load(ApplicationDbContext context)
    {
        var categorias = new List<CategoriaEntity>
        {
            new() { Id = 1, Nombre = "Classic", HorasAnticipacionReserva = 96 },
            new() { Id = 2, Nombre = "Gold", HorasAnticipacionReserva = 72 },
            new() { Id = 3, Nombre = "Platinum", HorasAnticipacionReserva = 48 },
            new() { Id = 4, Nombre = "Diamond", HorasAnticipacionReserva = null }
        };

        if (!context.Categorias.Any())
        {
            context.Categorias.AddRange(categorias);
        }

        if (!context.Mesas.Any())
        {
            var mesas = new List<MesaEntity>();
            mesas.AddRange(Enumerable.Range(1, 18).Select(i => new MesaEntity { Id = i, Capacidad = 2, EstaDisponible = true }));
            mesas.AddRange(Enumerable.Range(19, 15).Select(i => new MesaEntity { Id = i, Capacidad = 4, EstaDisponible = true }));
            mesas.AddRange(Enumerable.Range(34, 7).Select(i => new MesaEntity { Id = i, Capacidad = 6, EstaDisponible = true }));
            context.Mesas.AddRange(mesas);
        }

        if (!context.Clientes.Any())
        {
            var classic = categorias.First(c => c.Nombre == "Classic");
            var gold = categorias.First(c => c.Nombre == "Gold");
            var platinum = categorias.First(c => c.Nombre == "Platinum");
            var diamond = categorias.First(c => c.Nombre == "Diamond");
            var clientes = new List<ClienteEntity>
            {
                new() { Id = Guid.Parse("FE00E43F-802F-4607-A41B-AB79AF19E6AC"), Nombre = "Classic ol' Hamon", CategoriaId = classic.Id },
                new() { Id = Guid.Parse("658DB445-C365-4B8D-853A-5F8B9086ACE7"), Nombre = "Gold Experience", CategoriaId = gold.Id },
                new() { Id = Guid.Parse("56CA8229-DB97-4051-80E1-E4A489C614FD"), Nombre = "Star Platinum", CategoriaId = classic.Id },
                new() { Id = Guid.Parse("93E8DECD-79CD-4F47-BBC5-C61254E3B856"), Nombre = "Crazy Diamond", CategoriaId = diamond.Id },
            };
            context.Clientes.AddRange(clientes);
        }
        
        context.SaveChanges();
    }
}
