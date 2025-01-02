using Evimden.CoreLayer.Abstract;

namespace Evimden.CoreLayer.DTOs.IdentityDTOs
{
    public class CustomUserClaimDto : IDtoModel
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}
