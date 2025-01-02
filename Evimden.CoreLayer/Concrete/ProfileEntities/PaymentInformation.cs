using Evimden.CoreLayer.Concrete.OrderEntities;

namespace Evimden.CoreLayer.Concrete.ProfileEntities
{
    public class PaymentInformation : BaseEntity
    {
        public Guid PaymentInformationId { get; set; }
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
        public int Cvv { get; set; }

        public List<Payment> Payments { get; set; }
    }
}
