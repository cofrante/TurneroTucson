using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Pagination;

namespace Domain.Contracts.Repositories;

public interface IReservaRepository
{
    Task<Reserva> GetAsync(Guid id);
    Task<IEnumerable<Reserva>> GetAllAsync();
    Task<PagedResult<Reserva>> GetPagedAsync(int page, int pageSize);
    Task AddAsync(Reserva reserva);
    Task UpdateAsync(Reserva reserva);
    Task DeleteAsync(Guid id);
}
