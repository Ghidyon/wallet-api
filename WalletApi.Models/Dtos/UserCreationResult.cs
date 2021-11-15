using Microsoft.AspNetCore.Identity;
using WalletApi.Models.Entities;

namespace WalletApi.Models.Dtos
{
    public class UserCreationResult
    {
        public IdentityResult Result { get; set; }
        public User User { get; set; }
    }
}
