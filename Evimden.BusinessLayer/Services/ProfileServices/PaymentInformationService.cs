using AutoMapper;
using Evimden.BusinessLayer.Interfaces.ProfileInterfaces;
using Evimden.CoreLayer.Concrete.ProfileEntities;
using Evimden.CoreLayer.DTOs.ProfileDTOs;
using Evimden.CoreLayer.Repository;
using Microsoft.Extensions.Logging;

namespace Evimden.BusinessLayer.Services.ProfileServices
{
    public class PaymentInformationService : Service<PaymentInformation, PaymentInformationDto>, IPaymentInformationService
    {
        public PaymentInformationService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<PaymentInformation> logger) : base(unitOfWork, mapper, logger)
        {
        }
    }
}
