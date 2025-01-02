using Evimden.CoreLayer.Abstract;
using Evimden.CoreLayer.Repository;
using Evimden.DataAccessLayer.Concrete;

namespace Evimden.DataAccessLayer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EvimdenDbContext _context;
        public UnitOfWork(EvimdenDbContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IGenericRepository<T> Repository<T>() where T : class, IEntity
        {
            return new GenericRepository<T>(_context);
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
