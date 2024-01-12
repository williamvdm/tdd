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

namespace tdd.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public UserController(DatabaseContext context)
        {
            _context = context;
        }

        // Route: /api/User/GetUserList
        [HttpGet]
        [Route("GetUserList")]
        // [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetUserListAsync()
        {
            // Error handling wanneer een user geen toegang heeft tot deze functie

            var users = await _context.Users.ToListAsync();


            return Ok(users);
        }

        // Route: /api/User/GetUserById/{id}
        [HttpGet]
        [Route("GetUserById/{id}"), Authorize]
        public async Task<IActionResult> GetUserByIdAsync([FromRoute] string id)
        {
            // Error handling wanneer een user geen toegang heeft tot deze functie

            var user = await _context.Users.FirstOrDefaultAsync((user) => user.Id.ToString() == id);

            if (user == null)
            {
                return BadRequest("Gebruiker bestaat niet");
            }

            return Ok(user);
        }

        // Route: /api/User/RegisterUser
        [HttpPost]
        [Route("RegisterUser")]
        public async Task<IActionResult> RegisterUserAsync(UserModel obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserModel postUser = new UserModel();
            postUser.Id = Guid.NewGuid();
            postUser.Achternaam = obj.Achternaam;
            postUser.Voornaam = obj.Voornaam;
            postUser.Password = obj.Password;
            postUser.Telefoon = obj.Telefoon ?? "";

            if (await _context.Users.AnyAsync(user => user.Email == obj.Email))
            {
                return BadRequest("Email bestaat al");
            }

            if (await _context.Users.AnyAsync(user => user.Voornaam == postUser.Voornaam && user.Achternaam == postUser.Achternaam))
            {
                return BadRequest("Voornaam-achternaam combinatie bestaat al, dus als je niet Jan Jansen heet, hoepel dan maar op");
            }

            postUser.Email = obj.Email;
            postUser.ToestemmingBenadering = obj.ToestemmingBenadering;
            postUser.Provider = obj.Provider;
            postUser.IdentityHash = obj.IdentityHash;
            postUser.Role = obj.Role;

            if (obj.IsAdult || obj.Beperking.Any((b) => b.BeperkingNaam.Contains("verstandelijke beperking")))
            {
                postUser.IsAdult = obj.IsAdult;
                postUser.Verzorger = obj.Verzorger;
            }

            postUser.VoorkeurBenadering = obj.VoorkeurBenadering;
            postUser.Aandoening = obj.Aandoening;
            postUser.Beperking = obj.Beperking;
            postUser.Beschikbaarheid = obj.Beschikbaarheid;
            postUser.Adres = obj.Adres;

            _context.Users.Add(postUser);
            await _context.SaveChangesAsync();

            // Generate JWT token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = System.Text.Encoding.ASCII.GetBytes("Xëí²]Ã½ö3ð,åòiôñÐã:ßn¦ét¬ÆP)Æ6|4RÐ¤²ónóÿR[8ÔÃø¯®?1/¿sÜíÿmN`Å/e!Ïf§6à2úMÏÉÒì¡.tpÁH+XZ°úwk5Vóíìò¯±÷elBÖâ·mtTÁÎq(êï`¥Ñ-î¨èVOÙñÂX©8v");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, postUser.Id.ToString()),
                    new Claim(ClaimTypes.Email, postUser.Email),
                    new Claim(ClaimTypes.MobilePhone, postUser.Telefoon),
                    // Add more claims as needed
                }),
                Expires = DateTime.UtcNow.AddHours(1), // Token expiration time
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new { Token = tokenString });
        }

        // Route: /api/User/EditUser/{id}
        [HttpPut]
        [Route("EditUser/{id}")]//, Authorize]
        public async Task<IActionResult> EditUserByIdAsync([FromRoute] string id, UserModel obj)
        {
            // TODO: Functionaliteit om een User aan te passen met error handling

            UserModel? user = await _context.Users.FirstOrDefaultAsync((user) => user.Id.ToString() == id);

            if (user == null)
            {
                return NotFound("Gebruiker niet gevonden");
            }

            user.Achternaam = obj.Achternaam;
            user.Voornaam = obj.Voornaam;

            await _context.SaveChangesAsync();

            return Ok();
        }

        // Route: /api/User/DeleteUser/{id}
        [HttpDelete]
        [Route("DeleteUser/{id}"), Authorize]
        public async Task<IActionResult> DeleteUserByIdAsync([FromRoute] string id)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(user => user.Id.ToString() == id);

                if (user == null)
                {
                    return NotFound("User not found");
                }

                _context.Remove(user);

                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception)
            {
                // Error handling
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("SetUserRole/{id}")]
        public async Task<IActionResult> SetUserRoleByIdAsync([FromRoute] string id, string role)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Id.ToString() == id);
            if (user == null)
            {
                return NotFound("User not found");
            }

            user.Role = role;

            return Ok();
        }
    }
}
