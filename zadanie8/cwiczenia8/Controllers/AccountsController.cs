using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using cwiczenia8.DTO;
using cwiczenia8.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace cwiczenia8.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly _2019SBDContext _context;

        public AccountsController (IConfiguration configuration, _2019SBDContext context)
        {
            _configuration = configuration;
            _context = context;
        }
        
        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login(LoginDTO loginScheme)
        {
            User user = _context.Users.ToList().First(e => e.Login == loginScheme.Login);

            if ( user != null )
            {
                var password = new PasswordHasher<User>().VerifyHashedPassword(user, user.Password, loginScheme.Password);
                
                if (password == PasswordVerificationResult.Success)
                {
                    
                    return Ok(new
                    {
                        appTocken = new JwtSecurityTokenHandler().WriteToken(GenerateToken(loginScheme.Login, loginScheme.Password) ),
                        refreshToken = Guid.NewGuid()
                    });
                }
            }
            
            return NotFound( "User not found" );

        }

        [HttpPost("refreshToken")]
        public IActionResult RefreshToken(string token)
        {

            var user = _context.Users.ToList()
                .FirstOrDefault(e => e.Token.ToString() == token);

            if (user != null)
            {
                if ( user.ExpireTime < user.TokenTime )
                {
                    var refreshToken = Guid.NewGuid();
                    user.Token = refreshToken;

                    _context.Update(user);

                    _context.SaveChanges();
                    return Ok("Token refreshed");
                }
            }

            return BadRequest();

        }

        private JwtSecurityToken GenerateToken(string login, string passsword)
        {
            
            Claim[] claims =
            {
                new Claim(ClaimTypes.NameIdentifier, login),
                new Claim(ClaimTypes.Name, "s20613"),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "Doctor")
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey( Encoding.UTF8.GetBytes( _configuration["Secret"] ) );
            SigningCredentials credentials = new SigningCredentials( key, SecurityAlgorithms.HmacSha256 );

            JwtSecurityToken token = new JwtSecurityToken(
                "http://localhost:54076",
                "http://localhost:54076",
                claims,
                DateTime.Now.AddMinutes( 10 ),
                signingCredentials: credentials

            );

            return token;
        }

    }
}
