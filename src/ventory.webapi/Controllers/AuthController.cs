using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ventory.application.models;
using ventory.application.Services.Users;
using ventory.webapi.Helpers;

namespace ventory.webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration configuration;

        public AuthController(IUserService userService, IConfiguration configuration)
        {
            this._userService = userService;
            this.configuration = configuration;
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

        //implement login
        [HttpPost("login")]
        public async Task<IActionResult> LoginUserAsync([FromBody] LoginModel loginModel)
        {
            var userResponseModel = await _userService.LoginUserAsync(loginModel);
            if (userResponseModel == null)
            {
                return Unauthorized();
            }

            var token = JWTHelper.CreateToken(userResponseModel, configuration);
            return Ok(token);
        }
    }
}