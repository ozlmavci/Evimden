using AutoMapper;
using Evimden.BusinessLayer.Interfaces.OrderInterfaces;
using Evimden.CoreLayer.Concrete.OrderEntities;
using Evimden.CoreLayer.DTOs.OrderDTOs;
using Evimden.CoreLayer.Repository;
using Microsoft.Extensions.Logging;

namespace Evimden.BusinessLayer.Services.OrderServices
{
    public class CartService : Service<Cart, CartDto>, ICartService
    {
        public CartService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<Cart> logger) : base(unitOfWork, mapper, logger)
        {
        }
    }
}
