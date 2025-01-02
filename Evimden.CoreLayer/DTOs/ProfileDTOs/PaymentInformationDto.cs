namespace Evimden.CoreLayer.DTOs.ProfileDTOs
{
    public class PaymentInformationDto : BaseDto
    {
        public Guid PaymentInformationId { get; set; }
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
        public int Cvv { get; set; }
    }
}
