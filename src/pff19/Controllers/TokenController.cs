using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using pff19.DataAccess.Models;
using pff19.DataAccess.Repositories;
using pff19.DataAccess.Utils;
using pff19.Utiles;

namespace pff19.Controllers
{

    [Route("api/[controller]")]
    public class TokenController : ApiControllerBase
    {
        private readonly IConfiguration _config;
        private readonly UsersRepository _usersRepository;

        public TokenController(IConfiguration config, UsersRepository usersRepository)
        {
            _config = config;
            _usersRepository = usersRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken([FromBody]LoginModel login)
        {
            IActionResult response = Unauthorized();
            var user = Authenticate(login);

            if (user != null)
            {
                var tokenString = BuildToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private string BuildToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                expires: DateTime.Now.AddYears(10),
                signingCredentials: creds,
                claims: new[] { new Claim(Constants.UserIdClameType, user.Id.ToString()) });

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User Authenticate(LoginModel login)
        {
            var user = _usersRepository.GetAll().FirstOrDefault(u => string.Equals(login.Mail, u.Mail, StringComparison.InvariantCultureIgnoreCase));

            if (user != null && PasswordHelper.ValidatePassword(login.Password, user))
            {
                return user;
            }
            return null;
        }

        public class LoginModel
        {
            public string Mail { get; set; }
            public string Password { get; set; }
        }

    }
}
