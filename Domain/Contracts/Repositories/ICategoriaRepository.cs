using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Contracts.Repositories;

public interface ICategoriaRepository
{
    Task<Categoria> GetAsync(int id);
    Task<IEnumerable<Categoria>> GetAllAsync();
}
