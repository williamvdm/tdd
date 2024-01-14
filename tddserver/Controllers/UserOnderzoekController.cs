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
    public class UserOnderzoekController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public UserOnderzoekController(DatabaseContext context)
        {
            _context = context;
        }

        // Route: /api/UserOnderzoek/register/user/{userid}/onderzoek/{onderzoekid}
        [HttpGet]
        [Route("register/user/{userid}/onderzoek/{onderzoekid}")]
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
        [Route("unregister/user/{userid}/onderzoek/{onderzoekid}")]
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
    }
}