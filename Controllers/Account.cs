using System;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Warehouse_Management_System.DataTransferObjects.AccountDTOs;
using Warehouse_Management_System.DataTransferObjects.AccountDTOS;
using Warehouse_Management_System.Interfaces;
using Warehouse_Management_System.Models;

namespace Warehouse_Management_System.Controllers
{   
    [Route("api/account")]
    [ApiController]
    public class Account : ControllerBase
    {   
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        public Account(UserManager<AppUser> userManager,ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]

        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            try {
                    if(!ModelState.IsValid)
                    return BadRequest(ModelState);

                    var appUser = new AppUser
                    {
                        UserName = registerDTO.UserName,
                        Email = registerDTO.Email
                    };

                    var createdUser = await _userManager.CreateAsync(appUser, registerDTO.Password);

                    if(createdUser.Succeeded)
                    {
                        var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
                        if (roleResult.Succeeded)
                        {
                            return Ok(
                                new UserDTO
                                {
                                    UserName = appUser.UserName,
                                    Email = appUser.Email,
                                    Token = _tokenService.CreateToken(appUser)

                                }
                            );
                        }
                        else
                        {
                            return StatusCode(500, roleResult.Errors);
                        }
                    }
                    else
                    {
                        return StatusCode(500, createdUser.Errors);
                    }
             }
             catch ( Exception e)
             {
                return StatusCode(500, e);
             }
        }

    }
}