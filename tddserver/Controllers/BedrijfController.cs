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
        private readonly DatabaseContext _context;

        public BedrijfController(DatabaseContext context)
        {
            _context = context;
        }

        // Route: /api/Bedrijf/{bedrijfsmail}
        [HttpGet]
        [Route("{bedrijfsmail}")]
        public async Task<IActionResult> GetBedrijfByMail([FromRoute] string bedrijfsmail)
        {
            var bedrijf = await _context.Bedrijven.FirstOrDefaultAsync((bedrijf) => bedrijf.Bedrijfsmail.Equals(bedrijfsmail));

            if (bedrijf == null)
            {
                return NotFound("Bedrijf bestaat niet.");
            }

            return Ok(bedrijf);
        }

        // Route: /api/Bedrijf/registreer
        [HttpPost]
        [Route("registreer")]
        public async Task<IActionResult> RegistreerBedrijf(BedrijfModel obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BedrijfModel postBedrijf = new BedrijfModel();
            postBedrijf.Provider = obj.Provider;
            postBedrijf.Bedrijfsmail = obj.Bedrijfsmail;
            postBedrijf.Verified = obj.Verified;
            postBedrijf.Locatie = obj.Locatie;
            postBedrijf.Informatie = obj.Informatie;
            postBedrijf.contactpersonen = obj.contactpersonen;
            postBedrijf.Link = obj.Link;
            postBedrijf.onderzoeken = obj.onderzoeken;

            if (await _context.Bedrijven.AnyAsync(bedrijf => bedrijf.Bedrijfsmail == obj.Bedrijfsmail))
            {
                return BadRequest("Email bestaat al");
            }

            _context.Bedrijven.Add(postBedrijf);
            await _context.SaveChangesAsync();

            return Created();
        }

        // Route: /api/Bedrijf/{bedrijfsmail}/delete
        [HttpDelete]
        [Route("{bedrijfsmail}/delete")]
        public async Task<IActionResult> DeleteBedrijf([FromRoute] string bedrijfsmail)
        {
            var bedrijf = await _context.Bedrijven.FirstOrDefaultAsync(bedrijf => bedrijf.Bedrijfsmail == bedrijfsmail);

            if (bedrijf == null)
            {
                return NotFound("Bedrijf niet gevonden.");
            }

            _context.Bedrijven.Remove(bedrijf);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // Route: /api/Bedrijf/{bedrijfsmail}/update
        [HttpPut]
        [Route("{bedrijfsmail}/update")]
        public async Task<IActionResult> UpdateBedrijf([FromRoute] string bedrijfsmail, BedrijfModel bedrijf)
        {
            var gevondenBedrijf = await _context.Bedrijven.FirstOrDefaultAsync(bedrijf => bedrijf.Bedrijfsmail == bedrijfsmail);

            if (gevondenBedrijf == null)
            {
                return NotFound("Bedrijf is niet gevonden. Aanmaken kunt u met een andere route doen, lees de docs.");
            }

            _context.Remove(gevondenBedrijf);

            gevondenBedrijf.Provider = bedrijf.Provider;
            gevondenBedrijf.Bedrijfsmail = bedrijf.Bedrijfsmail;
            gevondenBedrijf.Informatie = bedrijf.Informatie;
            gevondenBedrijf.Locatie = bedrijf.Locatie;
            gevondenBedrijf.Link = bedrijf.Link;
            gevondenBedrijf.Verified = bedrijf.Verified;
            gevondenBedrijf.contactpersonen = bedrijf.contactpersonen;
            gevondenBedrijf.onderzoeken = bedrijf.onderzoeken;

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
