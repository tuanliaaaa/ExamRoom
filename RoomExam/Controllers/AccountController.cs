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
using System.Runtime.CompilerServices;

namespace RoomExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IEmail _email;
        private IConfiguration _config;
        private readonly ILogger<AccountController> _logger;
        private readonly IUser<User> _user;
        public AccountController(IEmail email, IConfiguration config, ILogger<AccountController> logger, IUser<User> user)
        {
            _config = config;
            _logger = logger;
            _user = user;
            _email = email;
        }
        private User UserRegiester(RegisterUserModel userLogin)
        {
            var currentUsers = _user.SearchUser(o => o.Email.Equals(userLogin.Email)|| o.Username.Equals(userLogin.Username)).Result;
            if (currentUsers.IsNullOrEmpty())
            {
                return null;
            }
            var currentUser = currentUsers.First();
            return currentUser;
        }
        private User Authenticate(UserLoginModel userLogin)
        {
            var currentUsers = _user.SearchUser(o => o.Username.Equals(userLogin.Username)&& o.Password.Equals(userLogin.Password)).Result;
            if (currentUsers.IsNullOrEmpty())
            {
                return null;
            }
            var currentUser = currentUsers.First();
            return currentUser;
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
        [AllowAnonymous]
        [HttpPost]
        [Route("~/api/Regiester")]
        public async Task<IActionResult> Regiester([FromBody] RegisterUserModel userRegister)
        {
            var user = UserRegiester(userRegister);
            if (user == null)
            {
                int i = 0;
                User newUser = new User()
                {
                    Email = userRegister.Email,
                    Password = userRegister.Password,
                    Username = userRegister.Username,
                    Status = false,
                    IsDelete = false
                };
                i = await _user.AddUser(newUser);
                if (i == 0)
                {
                    return NotFound("Tao tai khoan that bai");
                }

                user = UserRegiester(userRegister);
                SendMailModel mailLoginUser = new SendMailModel()
                {
                    To = user.Email,
                    From = _config["EmailUsername"],
                    Body = "https://localhost:7143/api/CrackAccount/" + Convert.ToInt32(user.UserID)
                };
                _email.SendEmail(mailLoginUser);
                return Ok("vui long check mail");
            }
            return NotFound("UserName or Email da ton tai");
            
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("~/api/CrackAccount/{UserId?}")]
        public async Task<IActionResult> LoginByMail(int UserID)
        {
            int i = 0;
            User user = await _user.GetUser(UserID);
            user.Status = true;
            i = await _user.UpdateUser(user);
            return Ok("da kich hoat thanh cong tai khoan");
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("~/api/Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginModel userLoginPost)
        {

            var user = Authenticate(userLoginPost);
            if (user == null)
            {
                return NotFound("User Not Found");
            }
            if (user.Status == true)
            {
                string Token = Generate(user);
                return Ok(Token);
            }
            SendMailModel mailLoginUser = new SendMailModel()
            {
                To = user.Email,
                From = _config["EmailUsername"],
                Body = "https://localhost:7143/api/CrackAccount/" + Convert.ToInt32(user.UserID)
            };
            _email.SendEmail(mailLoginUser);
            return Ok("vui long check mail va kich hoat tai khoan");
        }
    }
}
