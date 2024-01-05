using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tdd.Server.Context;
using tdd.Server.Models;
using tdd.Server.Extensions;

namespace tdd.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnderzoekController : ControllerBase
    {
        private readonly OnderzoekContext _context;

        public OnderzoekController(OnderzoekContext context)
        {
            _context = context;
        }
    }
}
