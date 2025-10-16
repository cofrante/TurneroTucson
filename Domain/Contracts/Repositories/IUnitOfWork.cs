using System.Threading.Tasks;

namespace Domain.Contracts.Repositories;

public interface IUnitOfWork
{
    IReservaRepository Reservas { get; }
    IEsperaRepository Esperas { get; }
    IClienteRepository Clientes { get; }
    IMesaRepository Mesas { get; }
    ICategoriaRepository Categorias { get; }
    Task SaveChangesAsync();
}
