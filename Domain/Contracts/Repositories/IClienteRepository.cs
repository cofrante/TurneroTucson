using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Contracts.Repositories;

public interface IClienteRepository
{
    Task<Cliente> GetAsync(Guid id);
    Task<IEnumerable<Cliente>> GetAllAsync();
}
