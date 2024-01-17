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
using System.Text.Json;
using System.Net.Http.Json;

namespace tdd.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOnderzoekController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public UserOnderzoekController(DatabaseContext context)
        {
            _context = context;
        }

        // Route: /api/UserOnderzoek/register/user/{userid}/onderzoek/{onderzoekid}
        [HttpGet]
        [Route("register/UserOnderzoek/{userid}/onderzoek/{onderzoekid}")]
        public async Task<IActionResult> LinkUserToOnderzoek([FromRoute] string userid, [FromRoute] string onderzoekid)
        {
            var onderzoek = await _context.Onderzoeken.FirstOrDefaultAsync((onderzoek) => onderzoek.Id.ToString() == onderzoekid);

            if (onderzoek == null)
            {
                return NotFound("Onderzoek niet gevonden.");
            }

            var user = await _context.Users.FirstOrDefaultAsync((user) => user.Id.ToString() == userid);

            if (user == null)
            {
                return NotFound("User niet gevonden.");
            }

            if (onderzoek.Deelnemers == null)
            {
                onderzoek.Deelnemers = [];
            }

            // onderzoek.Deelnemers kan hier niet null zijn.

            if (user.Onderzoeken == null)
            {
                user.Onderzoeken = [];
            }

            // user.Onderzoeken kan hier niet null zijn.

            onderzoek.Deelnemers?.Add(user);
            user.Onderzoeken?.Add(onderzoek);

            _context.Attach(onderzoek);
            _context.Attach(user);

            _context.Entry(user).State = EntityState.Modified;
            _context.Entry(onderzoek).State = EntityState.Modified;

            _context.Entry(onderzoek).Collection(o => o.Deelnemers).IsModified = true;
            _context.Entry(user).Collection(u => u.Onderzoeken).IsModified = true;

            await _context.SaveChangesAsync();

            return Ok("Link gemaakt.");
        }

        // Route: /api/UserOnderzoek/unregister/user/{userid}/onderzoek/{onderzoekid}
        [HttpGet]
        [Route("unregister/UserOnderzoek/{userid}/onderzoek/{onderzoekid}")]
        public async Task<IActionResult> UnLinkUserToOnderzoek([FromRoute] string userid, [FromRoute] string onderzoekid)
        {
            var onderzoek = await _context.Onderzoeken
                .Include(o => o.Deelnemers)
                .FirstOrDefaultAsync(o => o.Id.ToString() == onderzoekid);

            if (onderzoek == null)
            {
                return NotFound("Onderzoek niet gevonden.");
            }

            var user = await _context.Users
                .Include(u => u.Onderzoeken)
                .FirstOrDefaultAsync(u => u.Id.ToString() == userid);

            if (user == null)
            {
                return NotFound("User niet gevonden.");
            }

            if (!onderzoek.Deelnemers.Contains(user) || !user.Onderzoeken.Contains(onderzoek))
            {
                return StatusCode(500);
            }

            onderzoek.Deelnemers.Remove(user);
            user.Onderzoeken.Remove(onderzoek);

            await _context.SaveChangesAsync();

            return Ok();
        }

        // Route: /api/UserOnderzoek/GetUsers/{onderzoekid}
        [HttpGet]
        [Route("get/UserOnderzoek/GetUsers/{onderzoekid}")]
        public async Task<IActionResult> GetUsersForOnderzoek([FromRoute] string onderzoekid)
        {
            var deelnemers = new List<UserModel>();
            var users = await _context.Users.ToListAsync();

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
            };

            foreach (var currentUser in users)
            {
                var user = await _context.Users.Include(o => o.Onderzoeken).Where((user) => user.Id.ToString() == currentUser.Id.ToString()).SingleOrDefaultAsync();
                
                if (user == null)
                {
                    continue;
                }
                if (user.Onderzoeken.Exists((onderzoek) => onderzoek.Id.ToString() == onderzoekid))
                {
                    deelnemers.Add(user);
                }
            }

            var serializedOnderzoekenUsers = JsonSerializer.Serialize(deelnemers, options);
            
            return new ContentResult
            {
                Content = serializedOnderzoekenUsers,
                ContentType = "application/json",
                StatusCode = 200
            };
        }

        // Route: /api/UserOnderzoek/GetOnderzoeken/{userid}/{onlyactive}
        [HttpGet]
        [Route("get/UserOnderzoek/GetOnderzoeken/{userid}/{onlyactive}")]
        public async Task<IActionResult> GetOnderzoekenForUser([FromRoute] string userid, [FromRoute] string onlyactive)
        {
            var user = await _context.Users.Include(o => o.Onderzoeken).Where((user) => user.Id.ToString() == userid).SingleOrDefaultAsync();
            
            if (user == null)
            {
                return NotFound("User niet gevonden.");
            }

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
            };

            if (onlyactive == "yes")
            {
                return Ok(user.Onderzoeken.Where(onderzoek => onderzoek.Begindatum < DateOnly.FromDateTime(DateTime.Now) && onderzoek.Einddatum > DateOnly.FromDateTime(DateTime.Now)));
            }
            else
            {
                var serializedUserOnderzoeken = JsonSerializer.Serialize(user.Onderzoeken, options);
                return new ContentResult
                {
                    Content = serializedUserOnderzoeken,
                    ContentType = "application/json",
                    StatusCode = 200
                };
            }
        }
    }
}