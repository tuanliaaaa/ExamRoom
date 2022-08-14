using DataAccess.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Org.BouncyCastle.Asn1.Ocsp;
using DataAccess.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace RoomExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IEmail _email;
        private IConfiguration _config;
        private readonly ILogger<LoginController> _logger;
        private readonly IUser<User> _user;
        public LoginController(IEmail email,IConfiguration config, ILogger<LoginController> logger, IUser<User> user)
        {
            _config = config;
            _logger = logger;   
            _user = user;
            _email = email;
        }
        private User Authenticate(EmailModel userLogin)
        {
            var currentUsers = _user.SearchUser(o => o.Email.Equals(userLogin.Email)).Result;
            if (currentUsers.IsNullOrEmpty())
            {
                return null;
            }
            var currentUser = currentUsers.First();
            return currentUser;
            
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("~/api/Login")]
        
        public async Task<IActionResult> Login([FromBody] EmailModel userLogin)
        {

            var user = Authenticate(userLogin);
            if(user==null)
            {
                int  i = 0;
                User newUser = new User()
                {
                    Email = userLogin.Email,
                    Status = false,
                    IsDelete = false
                };
                i = await _user.AddUser(newUser);
                if(i==0)
                {
                    return NotFound("Email Not Found");
                }
            }
             user = Authenticate(userLogin);
            SendMailModel mailLoginUser = new SendMailModel()
            {
                To = user.Email,
                From = _config["EmailUsername"],
                Body = "https://localhost:7143/api/LoginByMail/" + Convert.ToInt32(user.UserID)
            };
            _email.SendEmail(mailLoginUser);
            return Ok("vui long check mail");
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("~/api/LoginByMail/{UserId?}")]
        public async Task<IActionResult> LoginByMail(int UserID)
        {
            User  user = await _user.GetUser(UserID);
            if(user != null)
            {
                string Token = Generate(user);
                return Ok(Token);
            }
            return NotFound("Email Login False");
        }
        private string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                   
                     new Claim("Email", user.Email)

                 };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(15),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
