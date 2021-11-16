using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalletApi.Models.Dtos;
using WalletApi.Models.Entities;
using WalletApi.Services.Interfaces;

namespace WalletApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IdentityContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public UserController(IdentityContext context,
            UserManager<User> userManager, 
            IUserService userService,
            IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserDto userDto)
        {
            if (userDto == null) return BadRequest("Empty user details!");

            var userCreationResult = await _userService.CreateUserAsync(userDto);

            if (!userCreationResult.Result.Succeeded)
            {
                foreach (var error in userCreationResult.Result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                    
                return BadRequest(ModelState);
            }

            var viewUserDetails = new ViewUserDto
            {
                UserId = userCreationResult.User.Id,
                Username = userCreationResult.User.UserName,
                Email = userCreationResult.User.Email,
                WalletId = userCreationResult.Wallet.Id,
                Balance = userCreationResult.Wallet.Balance
            };
            
            return Ok(viewUserDetails);
        }
    }
}
