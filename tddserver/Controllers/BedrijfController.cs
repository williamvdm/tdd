using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tdd.Server.Context;
using tdd.Server.Models;
using tdd.Server.Extensions;
using tdd.Server.Models.DTO;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Newtonsoft.Json;

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

        // Route: /api/Bedrijf/RegisterBedrijf
        [HttpPost]
        [Route("RegisterBedrijf")]
        public async Task<IActionResult> BedrijfRegister(BedrijfModelDTO bedrijf)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var existingBedrijf = await _context.Bedrijven.FirstOrDefaultAsync(b => b.Bedrijfsmail == bedrijf.Bedrijfsmail);

                if (existingBedrijf != null)
                {
                    return BadRequest("email bestaat al.");
                }

                BedrijfModel postBedrijf = new BedrijfModel
                {
                    Bedrijfsmail = bedrijf.Bedrijfsmail,
                    Password = bedrijf.Password,
                    Informatie = bedrijf.Informatie,
                    Locatie = bedrijf.Locatie,
                    Link = bedrijf.Link,
                    Verified = true,
                    Provider = bedrijf.Provider,
                };

                _context.Bedrijven.Add(postBedrijf);
                await _context.SaveChangesAsync();

                // Generate JWT token
                var bedrijfTokenHandler = new JwtSecurityTokenHandler();
                var bedrijfKey = Encoding.ASCII.GetBytes("Xëí²]Ã½ö3ð,åòiôñÐã:ßn¦ét¬ÆP)Æ6|4RÐ¤²ónóÿR[8ÔÃø¯®?1/¿sÜíÿmN`Å/e!Ïf§6à2úMÏÉÒì¡.tpÁH+XZ°úwk5Vóíìò¯±÷elBÖâ·mtTÁÎq(êï`¥Ñ-î¨èVOÙñÂX©8v");
                var bedrijfTokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Email, postBedrijf.Bedrijfsmail),
                        new Claim("Informatie", postBedrijf.Informatie),
                        new Claim("Locatie", JsonConvert.SerializeObject(postBedrijf.Locatie)),
                        new Claim("Link", postBedrijf.Link),

                    }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(bedrijfKey), SecurityAlgorithms.HmacSha256Signature)
                };

                var bedrijfToken = bedrijfTokenHandler.CreateToken(bedrijfTokenDescriptor);
                var bedrijfTokenString = bedrijfTokenHandler.WriteToken(bedrijfToken);

                return Ok(new { Token = bedrijfTokenString });
            }
                catch (Exception exception)
            {
                return StatusCode(500, $"Internal server error {exception}");
            }
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
