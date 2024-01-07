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
    public class RoleController : ControllerBase
    {
        private readonly UserContext _context;

        public RoleController(UserContext context)
        {
            _context = context;
        }

        // Route: /api/Rol/rollen
        [HttpGet]
        [Route("rollen")]
        public async Task<IActionResult> GetRollen()
        {
            var rollen = _context.UserRoleMachtiging.ToList();

            return Ok(rollen);
        }

        // Route: /api/Rol/{rolnaam}/machtigingen
        [HttpGet]
        [Route("{rolnaam}/machtigingen")]
        public async Task<IActionResult> GetRolMachtigingenAsync([FromRoute] string rolnaam)
        {
            var rol = _context.UserRoleMachtiging.Where((rol) => rol.Role == rolnaam).ToList();

            if (rol.Count() == 0)
            {
                return NotFound("Rol niet gevonden.");
            }
            else if (rol.Count() != 1)
            {
                return StatusCode(500);
            }

            return Ok(rol.First().Machtigingingen);
        }
    }
}