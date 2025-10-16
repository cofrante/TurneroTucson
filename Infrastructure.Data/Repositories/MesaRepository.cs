using Domain.Contracts.Repositories;
using Domain.Models;
using Infrastructure.Data.Entities;
using Infrastructure.Data.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class MesaRepository(ApplicationDbContext context) : IMesaRepository
{
    public async Task<Mesa> GetAsync(int id)
    {
        var entity = await context.Mesas.FirstOrDefaultAsync(m => m.Id == id);
        return entity?.ToDomain();
    }

    public async Task<IEnumerable<Mesa>> GetAllAsync()
    {
        var entities = await context.Mesas.ToListAsync();
        return entities.Select(e => e.ToDomain());
    }

    public async Task UpdateAsync(Mesa mesa)
    {
        var entity = await context.Mesas.FirstOrDefaultAsync(m => m.Id == mesa.Id);
        if (entity != null)
        {
            entity.EstaDisponible = mesa.EstaDisponible;
            entity.Capacidad = mesa.Capacidad;
            context.Mesas.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
