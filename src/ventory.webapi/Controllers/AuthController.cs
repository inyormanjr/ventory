using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ventory.application.models;
using ventory.application.Services.Users;

namespace ventory.webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            this._userService = userService;
            
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUserAsync([FromBody] NewUserModel newUserModel)
        {
            if (await _userService.RegisterUserAsync(newUserModel))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}