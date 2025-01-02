using Evimden.CoreLayer.Concrete.ProfileEntities;
using Evimden.CoreLayer.DTOs.ProfileDTOs;

namespace Evimden.BusinessLayer.Interfaces.ProfileInterfaces
{
    public interface ISellerApprovalService : IService<SellerApproval, SellerApprovalDto>
    {
        Task<SellerApprovalDto> GetApprovalBySellerIdAsync(Guid id);
        Task<List<SellerApprovalDto>> GetPendingRequests();
        Task ResponseToSellerRequest(Guid id, bool response);
    }
}
