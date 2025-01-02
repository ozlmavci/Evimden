namespace Evimden.CoreLayer.DTOs.ProfileDTOs
{
    public class AddressDto : BaseDto
    {
        public Guid AddressId { get; set; }
        public Guid UserId { get; set; }
        public Guid PhoneId { get; set; }
        public int CountryId { get; set; } = 90;
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string? AddressText { get; set; }
        public bool IsFavorite { get; set; }
    }
}
