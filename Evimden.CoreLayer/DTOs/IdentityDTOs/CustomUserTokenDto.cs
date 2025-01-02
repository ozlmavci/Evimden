using Evimden.CoreLayer.Abstract;

namespace Evimden.CoreLayer.DTOs.IdentityDTOs
{
    public class CustomUserTokenDto : IDtoModel
    {
        public Guid UserId { get; set; }
        public string LoginProvider { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
