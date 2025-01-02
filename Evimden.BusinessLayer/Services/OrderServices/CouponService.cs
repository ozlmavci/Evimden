using AutoMapper;
using Evimden.BusinessLayer.Interfaces.OrderInterfaces;
using Evimden.CoreLayer.Concrete.OrderEntities;
using Evimden.CoreLayer.DTOs.OrderDTOs;
using Evimden.CoreLayer.Repository;
using Microsoft.Extensions.Logging;

namespace Evimden.BusinessLayer.Services.OrderServices
{
    public class CouponService : Service<Coupon, CouponDto>, ICouponService
    {
        public CouponService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<Coupon> logger) : base(unitOfWork, mapper, logger)
        {
        }
    }
}
