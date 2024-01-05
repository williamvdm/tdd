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
    public class BedrijfController : ControllerBase
    {
        private readonly BedrijfContext _context;

        public BedrijfController(BedrijfContext context)
        {
            _context = context;
        }
    }
}
