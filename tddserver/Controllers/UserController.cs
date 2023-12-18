using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using tdd.Server.Context;
using tdd.Server.Models;

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
        public async Task<IActionResult> GetAsync()
        {
            // Error handling wanneer een user geen toegang heeft tot deze functie
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        // Route: /api/User/GetUserById/{id}
        [HttpGet]
        [Route("GetUserById/{id}")]
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

        // Route: /api/User/PostUser
        [HttpPost]
        [Route("RegisterUser")]
        public async Task<IActionResult> RegisterUserAsync(UserModel obj)
        {
            // Error handling wanneer een user bestaat toevoegen
            UserModel postUser = new UserModel();
            postUser.Achternaam = obj.Achternaam;
            postUser.Voornaam = obj.Voornaam;

            _context.Users.Add(postUser);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // Route: /api/User/PutUser
        [HttpPut]
        [Route("EditUser/{id}")]
        public async Task<IActionResult> EditUserByIdAsync([FromRoute] string id, UserModel obj)
        {
            // Functionaliteit om een User aan te passen
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
    }
}
