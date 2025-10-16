using Domain.Contracts.Repositories;
using Domain.Models;
using Infrastructure.Data.Entities;
using Infrastructure.Data.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class CategoriaRepository(ApplicationDbContext context) : ICategoriaRepository
{
    public async Task<Categoria> GetAsync(int id)
    {
        var entity = await context.Categorias.FirstOrDefaultAsync(c => c.Id == id);
        return entity?.ToDomain();
    }

    public async Task<IEnumerable<Categoria>> GetAllAsync()
    {
        var entities = await context.Categorias.ToListAsync();
        return entities.Select(e => e.ToDomain());
    }
}
