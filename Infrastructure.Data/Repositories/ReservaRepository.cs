using Domain.Contracts.Repositories;
using Domain.Models;
using Infrastructure.Data.Mappers;
using Microsoft.EntityFrameworkCore;
using Domain.Pagination;

namespace Infrastructure.Data.Repositories;

public class ReservaRepository(ApplicationDbContext context) : IReservaRepository
{
    public async Task<Reserva> GetAsync(Guid id)
    {
        var entity = await context.Reservas
            .Include(r => r.Cliente)
            .Include(r => r.Mesa)
            .FirstOrDefaultAsync(r => r.Id == id);
        return entity?.ToDomain();
    }

    public async Task<IEnumerable<Reserva>> GetAllAsync()
    {
        var entities = await context.Reservas
            .Include(r => r.Cliente)
            .Include(r => r.Mesa)
            .ToListAsync();
        return entities.Select(e => e.ToDomain());
    }

    public async Task<PagedResult<Reserva>> GetPagedAsync(int page, int pageSize)
    {
        var query = context.Reservas.Include(r => r.Cliente).AsQueryable();
        var total = await query.CountAsync();
        var items = await query
            .OrderBy(r => r.FechaReserva)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return new PagedResult<Reserva>(items.Select(e => e.ToDomain()).ToList(), total, page, pageSize);
    }

    public async Task AddAsync(Reserva reserva)
    {
        var entity = reserva.ToEntity();
        await context.Reservas.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Reserva reserva)
    {
        var entity = await context.Reservas.FirstOrDefaultAsync(r => r.Id == reserva.Id);
        if (entity != null)
        {
            entity.Estado = reserva.Estado;
            context.Reservas.Update(entity);
            await context.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await context.Reservas.FirstOrDefaultAsync(r => r.Id == id);
        if (entity != null)
        {
            context.Reservas.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
