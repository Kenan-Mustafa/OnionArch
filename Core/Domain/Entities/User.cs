using Microsoft.AspNetCore.Identity;
using System.ComponentModel;

namespace Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string Fullname { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpireDate{ get; set; }
    }
}
