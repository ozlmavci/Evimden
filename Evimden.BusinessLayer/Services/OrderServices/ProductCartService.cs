using AutoMapper;
using Evimden.BusinessLayer.Interfaces.OrderInterfaces;
using Evimden.CoreLayer.Concrete.OrderEntities;
using Evimden.CoreLayer.DTOs.OrderDTOs;
using Evimden.CoreLayer.Repository;
using Microsoft.Extensions.Logging;

namespace Evimden.BusinessLayer.Services.OrderServices
{
    public class ProductCartService : Service<ProductCart, ProductCartDto>, IProductCartService
    {
        public ProductCartService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ProductCart> logger) : base(unitOfWork, mapper, logger)
        {
        }
    }
}
