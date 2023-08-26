using Microsoft.AspNetCore.Identity;

namespace EShopperAPI.Domain.Entities.Identities
{
    public class AppUser : IdentityUser<string>
    {
        public string Name { get; set; }
        public string SurName { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
    }
}
