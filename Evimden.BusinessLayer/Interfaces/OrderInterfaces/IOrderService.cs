using Evimden.CoreLayer.Concrete.OrderEntities;
using Evimden.CoreLayer.DTOs.OrderDTOs;

namespace Evimden.BusinessLayer.Interfaces.OrderInterfaces
{
    public interface IOrderService : IService<Order, OrderDto>
    {
    }
}
