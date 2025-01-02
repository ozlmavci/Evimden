using Evimden.CoreLayer.Abstract;

namespace Evimden.CoreLayer.DTOs.IdentityDTOs
{
    public class CustomUserLoginDto : IDtoModel
    {
        public Guid UserId { get; set; }
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
    }
}
