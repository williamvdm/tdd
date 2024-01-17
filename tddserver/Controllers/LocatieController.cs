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
    public class LocatieController : ControllerBase
    {
        private readonly DbContextInterface _context;

        public LocatieController(DbContextInterface context)
        {
            _context = context;
        }

        // Route: /api/locatie
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetLocaties()
        {
            var locaties = _context.Locaties.ToList();

            return Ok(locaties);
        }
    }
}