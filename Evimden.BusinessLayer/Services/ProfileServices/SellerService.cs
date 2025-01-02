using AutoMapper;
using Evimden.BusinessLayer.Interfaces.ProfileInterfaces;
using Evimden.CoreLayer.Concrete.ProfileEntities;
using Evimden.CoreLayer.DTOs.ProfileDTOs;
using Evimden.CoreLayer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Evimden.BusinessLayer.Services.ProfileServices
{
    public class SellerService : Service<Seller, SellerDto>, ISellerService
    {
        public SellerService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<Seller> logger) : base(unitOfWork, mapper, logger)
        {
        }

        public async Task SellerBannedStatusChangeAsync(Guid id)
        {
            var seller = await GetByIdAsync(id);
            if (seller != null )
            {
                seller.IsBanned = !seller.IsBanned;
                seller.UpdatedDate = DateTime.Now;
                await UpdateAsync(seller);
            }
        }

        /// <summary>
        /// Kullanıcı ID'sine göre satıcıyı getirir.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>SellerDto</returns>
        public async Task<SellerDto> GetSellerByUserIdAsync(Guid userId)
        {
            try
            {
                var seller = await _unitOfWork.Repository<Seller>().GetAll().FirstOrDefaultAsync(s => s.UserId == userId);
                if (seller == null)
                {
                    _logger.LogWarning($"GetSellerByUserIdAsync: Kullanıcıya ait satıcı bilgisi bulunamadı. UserId: {userId}");
                    return null;
                }
                return _mapper.Map<SellerDto>(seller);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"GetSellerByUserIdAsync: Satıcı bilgisi getirilemedi. Hata: {ex.Message}");
                throw ex;
            }
        }

        /// <summary>
        /// Kullanıcı ID'sine göre satıcı ID'sini getirir.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Guid</returns>
        public async Task<Guid> GetSellerIdByUserIdAsync(Guid userId)
        {
            try
            {
                var seller = await GetSellerByUserIdAsync(userId);
                if (seller == null)
                {
                    _logger.LogWarning($"GetSellerIdByUserIdAsync: Kullanıcıya ait satıcı ID bilgisi bulunamadı. UserId: {userId}");
                    return Guid.Empty;
                }
                return seller.UserId;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"GetSellerIdByUserIdAsync: Satıcı ID'si getirilemedi. Hata: {ex.Message}");
                throw ex;
            }

        }

        public async Task<SellerDto> CreateShopForAdmin(Guid userId)
        {
            try
            {
                var seller = new SellerDto
                {
                    UserId = userId,
                    IsBanned = false,
                    IsActive = true,
                    About = "Evimden sistemi tarafından oluşturulmuştur.",
                    CityId = 34,
                    DistrictId = 467,
                    CountryId = 90,
                    ShopName = "Evimden Mağazası",
                    Tckn = "12345678901",
                    Vkn = "1234567890",
                    ShopImagePath = "shopdefault.jpg",
                    IsApproved = true
                };
                var sellerDto = await AddAsync(seller);
                return sellerDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"CreateShopForAdmin: Mağaza oluşturulamadı. Hata: {ex.Message}");
                throw ex;
            }
        }

    }
}
