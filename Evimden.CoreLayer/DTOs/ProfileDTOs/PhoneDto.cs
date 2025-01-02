namespace Evimden.CoreLayer.DTOs.ProfileDTOs
{
    public class PhoneDto : BaseDto
    {
        public Guid PhoneId { get; set; }
        public Guid UserId { get; set; }
        public string PhoneNumber { get; set; }
    }
}
