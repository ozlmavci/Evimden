using Evimden.CoreLayer.Concrete.ProfileEntities;
using Evimden.CoreLayer.DTOs.ProfileDTOs;

namespace Evimden.BusinessLayer.Interfaces.ProfileInterfaces
{
    public interface ISellerService : IService<Seller, SellerDto>
    {
        Task SellerBannedStatusChangeAsync(Guid id);
        Task<SellerDto> GetSellerByUserIdAsync(Guid userId);
        Task<Guid> GetSellerIdByUserIdAsync(Guid userId);
        Task<SellerDto> CreateShopForAdmin(Guid userId);
    }
}
