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

        // Route: /api/User/PostUser
        [HttpPost]
        [Route("PostUser")]
        public async Task<IActionResult> PostAsync(UserModel obj)
        {
            // Error handling wanneer een user bestaat toevoegen
            UserModel postUser = new UserModel();
            postUser.Achternaam = obj.Achternaam;
            postUser.Voornaam = obj.Voornaam;

            _context.Users.Add(postUser);
            await _context.SaveChangesAsync();

            return Ok(postUser);
        }

        // Route: /api/User/PutUser
        [HttpPut]
        [Route("PutUser")]
        public async Task<IActionResult> PutAsync(UserModel obj)
        {
            // Functionaliteit om een User aan te passen
            UserModel user = await _context.FindAsync(obj.Id);

            if(user == null)
            {
                return Ok(user);
            }

            await _context.SaveChangesAsync();

            return Ok(user);
        }
    }
}
