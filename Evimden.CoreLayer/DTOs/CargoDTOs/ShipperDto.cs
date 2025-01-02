namespace Evimden.CoreLayer.DTOs.CargoDTOs
{
    public class ShipperDto : BaseDto
    {
        public Guid ShipperId { get; set; }
        public int CountryId { get; set; } = 90;
        public string ShipperName { get; set; }
        public string? ContactName { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? ApiUrl { get; set; }
        public string? ApiKey { get; set; }
    }
}
