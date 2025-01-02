using AutoMapper;
using Evimden.BusinessLayer.Interfaces.ProfileInterfaces;
using Evimden.CoreLayer.Common.Enums;
using Evimden.CoreLayer.Concrete.LocationEntities;
using Evimden.CoreLayer.Concrete.ProfileEntities;
using Evimden.CoreLayer.DTOs.ProfileDTOs;
using Evimden.CoreLayer.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Evimden.BusinessLayer.Services.ProfileServices
{
    public class SellerApprovalService : Service<SellerApproval, SellerApprovalDto>, ISellerApprovalService
    {
        public SellerApprovalService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<SellerApproval> logger) : base(unitOfWork, mapper, logger)
        {
        }

        public async Task<SellerApprovalDto> GetApprovalBySellerIdAsync(Guid id)
        {
            try
            {
                var approval = await _unitOfWork.Repository<SellerApproval>().Where(a => a.SellerId == id).FirstOrDefaultAsync();
                if (approval != null)
                {
                    return _mapper.Map<SellerApprovalDto>(approval);
                }
                else
                {
                    _logger.LogError($"{id} için kayıt bulunamadı.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"GetApprovalBySellerIdAsync metodu hata oluşturdu. Hata: {ex.Message}");
                throw ex;
            }

        }

        public async Task<List<SellerApprovalDto>> GetPendingRequests()
        {
            var requests = await _unitOfWork.Repository<SellerApproval>().Where(a => a.ApprovalStatus == RequestStatusEnum.Bekliyor).ToListAsync();
            return _mapper.Map<List<SellerApprovalDto>>(requests);
        }

        public async Task ResponseToSellerRequest(Guid id, bool response)
        {
            var request = await _unitOfWork.Repository<SellerApproval>().GetByIdAsync(id);
            if (request != null)
            {
                request.ApprovalStatus = response ? RequestStatusEnum.Onaylandı : RequestStatusEnum.Reddedildi;
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}