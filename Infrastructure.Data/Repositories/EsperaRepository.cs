using Domain.Contracts.Repositories;
using Domain.Models;
using Infrastructure.Data.Entities;
using Infrastructure.Data.Mappers;
using Microsoft.EntityFrameworkCore;
using Domain.Pagination;

namespace Infrastructure.Data.Repositories;

public class EsperaRepository(ApplicationDbContext context) : IEsperaRepository
{
    public async Task<Espera> GetAsync(Guid id)
    {
        var entity = await context.Set<EsperaEntity>().FirstOrDefaultAsync(e => e.Id == id);
        return entity?.ToDomain();
    }

    public async Task<IEnumerable<Espera>> GetAllAsync()
    {
        var entities = await context.Set<EsperaEntity>().ToListAsync();
        return entities.Select(e => e.ToDomain());
    }

    public async Task<PagedResult<Espera>> GetPagedAsync(int page, int pageSize)
    {
        var query = context.Esperas.Include(e => e.Cliente).AsQueryable();
        var total = await query.CountAsync();
        var items = await query
            .OrderBy(e => e.FechaReserva)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return new PagedResult<Espera>(items.Select(e => e.ToDomain()).ToList(), total, page, pageSize);
    }

    public async Task AddAsync(Espera espera)
    {
        var entity = espera.ToEntity();
        await context.Set<EsperaEntity>().AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Espera espera)
    {
        var entity = await context.Set<EsperaEntity>().FirstOrDefaultAsync(e => e.Id == espera.Id);
        if (entity != null)
        {
            entity.Estado = espera.Estado;
            context.Set<EsperaEntity>().Update(entity);
            await context.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await context.Set<EsperaEntity>().FirstOrDefaultAsync(e => e.Id == id);
        if (entity != null)
        {
            context.Set<EsperaEntity>().Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
