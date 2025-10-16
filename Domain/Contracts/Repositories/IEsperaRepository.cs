using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Pagination;

namespace Domain.Contracts.Repositories;

public interface IEsperaRepository
{
    Task<Espera> GetAsync(Guid id);
    Task<IEnumerable<Espera>> GetAllAsync();
    Task<PagedResult<Espera>> GetPagedAsync(int page, int pageSize);
    Task AddAsync(Espera espera);
    Task UpdateAsync(Espera espera);
    Task DeleteAsync(Guid id);
}
