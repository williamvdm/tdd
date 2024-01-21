using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tdd.Server.Context;
using tdd.Server.Models;
using tdd.Server.Extensions;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using tdd.Server.Models.DTO;
using System.Text;
using System;
using System.Linq;

namespace tdd.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public AuthController(DatabaseContext context)
        {
            _context = context;
        }

        // Route: /api/Auth/LoginUser
        [HttpPost]
        [Route("LoginUser")]
        public async Task<IActionResult> LoginUserAsync(UserLoginModelDto obj)
        {
            if (obj == null)
            {
                return Unauthorized();
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == obj.Email && u.Password == obj.Password);

            var bedrijf = await _context.Bedrijven.FirstOrDefaultAsync(b => b.Bedrijfsmail == obj.Email && b.Password == obj.Password);

            if (user != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("rruFEXF3sJfb/HZn9UBCepB7X+Kzm+1JbpWDmezQAh/bcaKZhOmalWsu6b83pshBPDJY2CqKslacIAABW2EEQ6i9EKJa7kSFdwYV0IrSO6phMDvZ3kco9rpuQYZhLbAk2/g73BO8rtYh2jBTYYJo8TT8hUTRAdUZTk8VdpgQNt9UdB6bGJtDigdkdTbaib/w");

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.GivenName, user.Voornaam),
                        new Claim(ClaimTypes.Surname, user.Achternaam),
                        new Claim(ClaimTypes.MobilePhone, user.Telefoon ?? ""),
                        new Claim(ClaimTypes.DateOfBirth, user.IsAdult ? "Adult" : "NotAdult"),
                        new Claim(ClaimTypes.Role, user.Role),
                        new Claim("type", "gebruiker"),
                    }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                return Ok(new { Token = tokenString });
            }
            else if (bedrijf != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("rruFEXF3sJfb/HZn9UBCepB7X+Kzm+1JbpWDmezQAh/bcaKZhOmalWsu6b83pshBPDJY2CqKslacIAABW2EEQ6i9EKJa7kSFdwYV0IrSO6phMDvZ3kco9rpuQYZhLbAk2/g73BO8rtYh2jBTYYJo8TT8hUTRAdUZTk8VdpgQNt9UdB6bGJtDigdkdTbaib/w");

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, bedrijf.Bedrijfsmail),
                        new Claim(ClaimTypes.Email, bedrijf.Bedrijfsmail),
                        new Claim("Informatie", bedrijf.Informatie),
                        new Claim("type", "bedrijf"),
                    }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                return Ok(new { Token = tokenString });
            }
            else
            {
                return BadRequest("Gebruikersnaam of wachtwoord is ongeldig.");
            }
        }
    }
}
