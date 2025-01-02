using Evimden.CoreLayer.Abstract;

namespace Evimden.BusinessLayer.Interfaces
{
    public interface IService<TEntity, TDto>
            where TEntity : class, IEntity
            where TDto : class, IDtoModel
    {
        Task<TDto> GetByIdAsync(Guid id);
        Task<TDto> GetByIntIdAsync(int id);
        Task<List<TDto>> GetAllAsync();
        Task<TDto> AddAsync(TDto dto);
        Task UpdateAsync(TDto dto);
        Task DeleteAsync(Guid id);
        Task AddRangeAsync(List<TDto> dtos);
        void DeleteRange(List<TDto> dtos);
    }
}
