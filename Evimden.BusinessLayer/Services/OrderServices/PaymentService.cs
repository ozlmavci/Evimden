using AutoMapper;
using Evimden.BusinessLayer.Interfaces.OrderInterfaces;
using Evimden.CoreLayer.Concrete.OrderEntities;
using Evimden.CoreLayer.DTOs.OrderDTOs;
using Evimden.CoreLayer.Repository;
using Microsoft.Extensions.Logging;

namespace Evimden.BusinessLayer.Services.OrderServices
{
    public class PaymentService : Service<Payment, PaymentDto>, IPaymentService
    {
        public PaymentService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<Payment> logger) : base(unitOfWork, mapper, logger)
        {
        }
    }
}
