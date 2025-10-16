using Domain.Contracts.Repositories;
using Domain.Models;
using Infrastructure.Data.Entities;
using Infrastructure.Data.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class ClienteRepository(ApplicationDbContext context) : IClienteRepository
{
    public async Task<Cliente> GetAsync(Guid id)
    {
        var entity = await context.Clientes.Include(c => c.Categoria).FirstOrDefaultAsync(c => c.Id == id);
        return entity?.ToDomain();
    }

    public async Task<IEnumerable<Cliente>> GetAllAsync()
    {
        var entities = await context.Clientes.Include(c => c.Categoria).ToListAsync();
        return entities.Select(e => e.ToDomain());
    }
}
