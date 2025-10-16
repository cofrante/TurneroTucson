using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Contracts.Repositories;

public interface IMesaRepository
{
    Task<Mesa> GetAsync(int id);
    Task<IEnumerable<Mesa>> GetAllAsync();
    Task UpdateAsync(Mesa mesa);
}
