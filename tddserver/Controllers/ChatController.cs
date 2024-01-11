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
    public class ChatController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ChatController(DatabaseContext context)
        {
            _context = context;
        }

        // Route: /api/chat
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetChatberichten()
        {
            var berichten = _context.Berichten.ToList();

            return Ok(berichten);
        }
    }
}