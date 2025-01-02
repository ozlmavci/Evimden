using AutoMapper;
using Evimden.BusinessLayer.Interfaces;
using Evimden.CoreLayer.Abstract;
using Evimden.CoreLayer.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Evimden.BusinessLayer.Services
{
    public class Service<TEntity, TDto> : IService<TEntity, TDto>
         where TEntity : class, IEntity
         where TDto : class, IDtoModel
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        protected readonly ILogger<TEntity> _logger;

        public Service(IUnitOfWork unitOfWork, IMapper mapper, ILogger<TEntity> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<TDto> AddAsync(TDto dto)
        {
            try
            {
                var entity = _mapper.Map<TEntity>(dto);
                await _unitOfWork.Repository<TEntity>().AddAsync(entity);
                await _unitOfWork.SaveChangesAsync();
                return _mapper.Map<TDto>(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"AddAsync: Kayıt oluşturulamadı. Hata: {ex.Message}");
                throw ex;
            }
        }

        public async Task AddRangeAsync(List<TDto> dtos)
        {
            try
            {
                var entities = _mapper.Map<List<TEntity>>(dtos);
                await _unitOfWork.Repository<TEntity>().AddRangeAsync(entities);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"AddRangeAsync: Kayıt oluşturulamadı. Hata: {ex.Message}");
                throw ex;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var entity = await _unitOfWork.Repository<TEntity>().GetByIdAsync(id);
                _unitOfWork.Repository<TEntity>().Delete(entity);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"DeleteAsync: {id} id'li kayıt silinemedi. Hata: {ex.Message}");
                throw ex;
            }
        }

        public async void DeleteRange(List<TDto> dtos)
        {
            try
            {
                var entities = _mapper.Map<List<TEntity>>(dtos);
                _unitOfWork.Repository<TEntity>().DeleteRange(entities);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"DeleteRange: Kayıtlar silinemedi. Hata: {ex.Message}");
                throw ex;
            }
        }

        public async Task<List<TDto>> GetAllAsync()
        {
            try
            {
                var entities = await _unitOfWork.Repository<TEntity>().GetAll().ToListAsync();
                if (!entities.Any())
                {
                    _logger.LogWarning($"GetAllAsync: Kayıt bulunamadı.");
                    return null;
                }
                return _mapper.Map<List<TDto>>(entities);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"GetAllAsync: Kayıtlar listelenemedi. Hata: {ex.Message}");
                throw ex;
            }
        }

        public async Task<TDto> GetByIdAsync(Guid id)
        {
            try
            {
                var entity = await _unitOfWork.Repository<TEntity>().GetByIdAsync(id);
                if (entity == null)
                {
                    _logger.LogWarning($"GetByIdAsync: {id} id'li kayıt bulunamadı.");
                    return null;
                }
                return _mapper.Map<TDto>(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"GetByIdAsync: {id} id'li kayıt listelenemedi. Hata: {ex.Message}");
                throw ex;
            }
        }

        public async Task<TDto> GetByIntIdAsync(int id)
        {
            try
            {
                var entity = await _unitOfWork.Repository<TEntity>().GetByIntIdAsync(id);
                if (entity == null)
                {
                    _logger.LogWarning($"GetByIntIdAsync: {id} id'li kayıt bulunamadı.");
                    return null;
                }
                return _mapper.Map<TDto>(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"GetByIntIdAsync: {id} id'li kayıt listelenemedi. Hata: {ex.Message}");
                throw ex;
            }
        }

        public async Task UpdateAsync(TDto dto)
        {
            try
            {
                var entity = _mapper.Map<TEntity>(dto);
                _unitOfWork.Repository<TEntity>().Update(entity);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"UpdateAsync: Kayıt güncellenemedi. Hata: {ex.Message}");
                throw ex;
            }
        }
    }
}
