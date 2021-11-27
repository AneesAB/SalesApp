using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SalesWebApi.Models;
using SalesWebApi.Repository;

namespace SalesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private ILoginRepository _loginRepository;

        public LoginController(IConfiguration config, ILoginRepository loginRepository)
        {
            _config = config;
            _loginRepository = loginRepository;
        }

        //Iactionresult of login
        [AllowAnonymous]
        [HttpGet("{userName}/{password}")]
        public IActionResult Login(string UserName, string password)
        {
            IActionResult response = Unauthorized();
            //Authenticate the user
            var user = AuthenticateUser(UserName, password);

            //validate
            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new
                {
                    UName = user.Username,
                    rId = user.UserType,
                    token = tokenString
                });
            }
            return response;
        }

        private string GenerateJSONWebToken(Login login)
        {
            //security key
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            //signing credential
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                null,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private Login AuthenticateUser(string userName, string password)
        {
            //access the repository
            Login User = _loginRepository.GetUser(userName, password);
          

            if (User != null)
            {
                return User;
            }
            return null;

        }

        #region get User by name and password

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        [Route("getuser/{un}/{pwd}")]
        public async Task<IActionResult> GetUserByNamePassword(string un, string pwd)
        {
            try
            {
                var User = _loginRepository.GetUserByPassword(un, pwd);
                if (User == null)
                {
                    return NotFound();
                }
                return Ok(User);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        #endregion
    }
}
