using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletApi.Models.Dtos;

namespace WalletApi.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserCreationResult> CreateUserAsync(UserDto userDto);
    }
}
