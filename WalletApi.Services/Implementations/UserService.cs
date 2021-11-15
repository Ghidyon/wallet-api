using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using System.Threading.Tasks;
using WalletApi.Models.Dtos;
using WalletApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WalletApi.Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using WalletApi.Models.Entities;

namespace WalletApi.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly ILoggerService _loggerService;

        public UserService(IUnitOfWork unitOfWork,
            UserManager<User> userManager,
            IMapper mapper,
            ILoggerService loggerService)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
            _loggerService = loggerService;
        }

        public async Task<UserCreationResult> CreateUserAsync([FromBody] UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);

            var createdUserResult = await _userManager.CreateAsync(user, userDto.Password);

            return new UserCreationResult {
                Result = createdUserResult,
                User = user
            };
        }
    }
}
