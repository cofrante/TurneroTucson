using Domain.Contracts.Repositories;

namespace Infrastructure.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public IReservaRepository Reservas { get; }
    public IEsperaRepository Esperas { get; }
    public IClienteRepository Clientes { get; }
    public IMesaRepository Mesas { get; }
    public ICategoriaRepository Categorias { get; }

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        Reservas = new ReservaRepository(_context);
        Esperas = new EsperaRepository(_context);
        Clientes = new ClienteRepository(_context);
        Mesas = new MesaRepository(_context);
        Categorias = new CategoriaRepository(_context);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
