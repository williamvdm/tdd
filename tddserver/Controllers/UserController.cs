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
