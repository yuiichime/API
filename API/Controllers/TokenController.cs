
using Infrastructure.CrossCutting.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    public class TokenController : BaseController
    {
        readonly IConfiguration _config;
        readonly UserService _userService;
        public TokenController(IConfiguration config, UserService userService)
        {
            _config = config;
            _userService = userService;
        }

        [Route("Token")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GenerateToken(AuthUser user)
        {
            try
            {
                if (_userService.ValidateUser(user))
                {
                    var authenticatedUser = _userService.GetByLogin(user.Login);
                    var tokenHandler = new JwtSecurityTokenHandler();

                    var key = Encoding.ASCII.GetBytes(_config.GetSection("Settings:TokenSecurity").Value);

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.Name, authenticatedUser.Login.ToString()),
                            new Claim(ClaimTypes.Role, authenticatedUser.Role.ToString())
                        }),
                        Expires = DateTime.UtcNow.AddHours(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var token = tokenHandler.CreateToken(tokenDescriptor);

                    return new OkObjectResult(tokenHandler.WriteToken(token));
                }

                return new UnauthorizedResult();

            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }
    }
}
