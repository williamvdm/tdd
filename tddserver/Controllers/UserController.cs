using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tdd.Server.Context;
using tdd.Server.Models;
using tdd.Server.Extensions;
using Microsoft.AspNetCore.Identity;

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
        [Authorize(Roles = "admin")]
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
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // use jwt token authentication here
            // Error handling wanneer een user bestaat toevoegen

            UserModel postUser = new UserModel();
            postUser.Achternaam = obj.Achternaam;
            postUser.Voornaam = obj.Voornaam;

            if(await _context.Users.AnyAsync(user => user.Email == obj.Email))
            {
                return BadRequest("Email bestaat al");
            }

            postUser.Email = obj.Email;

            if(obj.GeboorteDatum.CalculateAge() < 18)
            {
                postUser.GeboorteDatum = obj.GeboorteDatum;
                postUser.Verzorger = obj.Verzorger;
            }

            postUser.VoorkeurBenadering = obj.VoorkeurBenadering;

            _context.Users.Add(postUser);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // Route: /api/User/EditUser/{id}
        [HttpPut]
        [Route("EditUser/{id}"), Authorize]
        public async Task<IActionResult> EditUserByIdAsync([FromRoute] string id, UserModel obj)
        {
            // Functionaliteit om een User aan te passen met error handling

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
            // Error handling

            var user = await _context.Users.FirstOrDefaultAsync(user => user.Id.ToString() == id);
            if (user == null)
            {
                return NotFound("User not found");
            }

            _context.Remove(user);

            await _context.SaveChangesAsync(); 

            return Ok();
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
