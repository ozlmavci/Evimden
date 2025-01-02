using Evimden.CoreLayer.Abstract;

namespace Evimden.CoreLayer.DTOs.IdentityDTOs
{
    public class CustomUserDto : IDtoModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string? NormalizedUserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string? PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string? Password { get; set; }
        public string? NewPassword { get; set; }
    }
}
