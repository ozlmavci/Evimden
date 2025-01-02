using Evimden.CoreLayer.Abstract;

namespace Evimden.CoreLayer.Repository
{
    public interface IUnitOfWork : IDisposable //Bellekten temizlemek için.
    {
        IGenericRepository<T> Repository<T>() where T : class, IEntity; //Repository'lerin oluşturulması.
        Task<int> SaveChangesAsync(); //Database işlemlerini kaydetmek için.
    }
}
