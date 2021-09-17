using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NZSBH.Api.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZSBH.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _config;

        public TokenController(IConfiguration configuration)
        {
            _config = configuration;
        }

        [HttpPost]
        public IActionResult CreateToken([FromBody] LoginModel loginModel) {
            IActionResult response = Unauthorized();

            UserModel model = Authenticate(loginModel);
            if (model != null) {
                string tokenString = BuildToken();
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private string BuildToken()
        {
            var sKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:ServerSecret"]));
            var creds = new SigningCredentials(sKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _config["JWT:Issuer"],
                _config["JWT:Issuer"],
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        private UserModel Authenticate(LoginModel loginModel)
        {
            if (loginModel.UserName == "kevin" && loginModel.Password == "AZERTY") {
                return new UserModel() { 
                    Name = "kevin",
                    Email = "kevin.derudder@elmos.be"
                };
            }

            return null;
        }
    }
}
