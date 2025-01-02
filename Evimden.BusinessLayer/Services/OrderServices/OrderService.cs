using AutoMapper;
using Evimden.BusinessLayer.Interfaces.OrderInterfaces;
using Evimden.CoreLayer.Concrete.OrderEntities;
using Evimden.CoreLayer.DTOs.OrderDTOs;
using Evimden.CoreLayer.Repository;
using Microsoft.Extensions.Logging;

namespace Evimden.BusinessLayer.Services.OrderServices
{
    public class OrderService : Service<Order, OrderDto>, IOrderService
    {
        public OrderService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<Order> logger) : base(unitOfWork, mapper, logger)
        {
        }
    }
}
