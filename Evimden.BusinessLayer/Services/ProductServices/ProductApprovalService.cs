using AutoMapper;
using Evimden.BusinessLayer.Interfaces.ProductInterfaces;
using Evimden.CoreLayer.Concrete.ProductEntities;
using Evimden.CoreLayer.DTOs.ProductDTOs;
using Evimden.CoreLayer.Repository;
using Microsoft.Extensions.Logging;

namespace Evimden.BusinessLayer.Services.ProductServices
{
    public class ProductApprovelService : Service<ProductApproval, ProductApprovalDto>, IProductApprovalService
    {
        public ProductApprovelService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ProductApproval> logger) : base(unitOfWork, mapper, logger)
        {
        }
    }
}
