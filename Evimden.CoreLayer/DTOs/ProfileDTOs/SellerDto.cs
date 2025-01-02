namespace Evimden.CoreLayer.DTOs.ProfileDTOs
{
    public class SellerDto : BaseDto
    {
        public Guid SellerId { get; set; }
        public Guid UserId { get; set; }
        public int CountryId { get; set; } = 90;
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string ShopName { get; set; }
        public string Tckn { get; set; }
        public string Vkn { get; set; }
        public string ShopImagePath { get; set; }
        public string About { get; set; }
        public bool IsApproved { get; set; } = false;
        public bool IsBanned { get; set; } = false;
    }
}
