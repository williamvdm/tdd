using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tdd.Server.Context;
using tdd.Server.Models;
using tdd.Server.Extensions;
using tdd.Server.Models.DTO;
using System.ComponentModel;
using System;

namespace tdd.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnderzoekController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public OnderzoekController(DatabaseContext context)
        {
            _context = context;
        }

        // Route: /api/onderzoek
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetOnderzoeken()
        {
            var onderzoeken = await _context.Onderzoeken.ToListAsync();

            return Ok(onderzoeken);
        }

        // Route: /api/onderzoek/{onderzoekid}
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetOnderzoekByIdAsync([FromRoute] string id)
        {
            var onderzoek = await _context.Onderzoeken.FirstOrDefaultAsync((onderzoek) => onderzoek.Id.ToString() == id);

            if (onderzoek == null)
            {
                return NotFound("Onderzoek niet gevonden.");
            }

            return Ok(onderzoek);
        }

        // Route: /api/onderzoek/{onderzoekid}/vraag/add
        [HttpPost]
        [Route("{id}/vraag/add")]
        public async Task<IActionResult> AddQuestionToOnderzoek([FromRoute] string id, VraagModel vraag)
        {
            var onderzoek = await _context.Onderzoeken
                .Include(o => o.Vragen)  // Include Vragen for eager loading
                .FirstOrDefaultAsync(onderzoek => onderzoek.Id.ToString() == id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (onderzoek == null)
            {
                return NotFound("Onderzoek niet gevonden.");
            }

            VraagModel postVraag = new VraagModel
            {
                OnderzoekID = Guid.Parse(id),
                Vraag = vraag.Vraag
            };

            if (onderzoek.Vragen == null)
            {
                onderzoek.Vragen = new List<VraagModel>();
            }

            onderzoek.Vragen.Add(postVraag);

            try
            {
                await _context.SaveChangesAsync();
                return Ok(postVraag);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Handle concurrency conflict, for example, return a conflict response.
                // You can log the exception details for further investigation.
                return Conflict("Concurrency conflict. The entity has been modified by another user.");
            }
        }

        // Route: /api/onderzoek/{onderzoekid}/vraag/{vraagid}/antwoord/{antwoordid}
        [HttpGet]
        [Route("{id}/vraag/{vraagid}/antwoord/{antwoordid}")]
        public async Task<IActionResult> GetAntwoordByIdAsync([FromRoute] string id, [FromRoute] int vraagid, [FromRoute] int antwoordid)
        {
            var onderzoek = await _context.Onderzoeken.FirstOrDefaultAsync((onderzoek) => onderzoek.Id.ToString() == id);

            if (onderzoek == null)
            {
                return NotFound("Onderzoek niet gevonden.");
            }

            var vraag = onderzoek.Vragen?.Find((vraag) => vraag.VraagID == vraagid);

            if (vraag == null)
            {
                return NotFound("Vraag niet gevonden.");
            }

            var antwoord = vraag.Antwoorden?.Find((antwoord) => antwoord.AntwoordID == antwoordid);

            if (antwoord == null)
            {
                return NotFound("Antwoord niet gevonden.");
            }

            return Ok(antwoord);
        }

        // Route /api/onderzoek/create
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateOnderzoek(OnderzoekModelDTO onderzoek)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            OnderzoekModel postOnderzoek = new OnderzoekModel();

            postOnderzoek.Id = Guid.NewGuid();
            postOnderzoek.Beschrijving = onderzoek.Beschrijving;
            postOnderzoek.BedrijfMail = onderzoek.BedrijfMail;
            postOnderzoek.Begindatum = onderzoek.Begindatum;
            postOnderzoek.Einddatum = onderzoek.Einddatum;
            postOnderzoek.Locatie = onderzoek.Locatie;
            postOnderzoek.BeloningBeschrijving = onderzoek.BeloningBeschrijving;
            postOnderzoek.Titel = onderzoek.Titel;

            if (await _context.Onderzoeken.AnyAsync(onderzoek => onderzoek.Id == postOnderzoek.Id))
            {
                return BadRequest("Onderzoek bestaat al.");
            }

            _context.Add(postOnderzoek);
            await _context.SaveChangesAsync();

            return Ok(onderzoek);
        }


        // Route: /api/Onderzoek/{onderzoekid}/delete
        [HttpDelete]
        [Route("{onderzoekid}/delete")]
        public async Task<IActionResult> DeleteBedrijf([FromRoute] string onderzoekid)
        {
            var onderzoek = await _context.Onderzoeken.FirstOrDefaultAsync(onderzoek => onderzoek.Id.ToString() == onderzoekid);

            if (onderzoek == null)
            {
                return NotFound("Onderzoek niet gevonden.");
            }

            _context.Onderzoeken.Remove(onderzoek);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // Route: api/onderzoek/bedrijf/{bedrijfsmail}
        [HttpGet]
        [Route("bedrijf/{bedrijfsmail}")]
        public async Task<IActionResult> GetOnderzoekenVanBedrijf([FromRoute] string bedrijfsmail)
        {
            var onderzoeken = await _context.Onderzoeken
                .Where(onderzoek => onderzoek.BedrijfMail == bedrijfsmail)
                .ToListAsync();

            return Ok(onderzoeken);
        }

        // Route: api/onderzoek/{onderzoekid}/contactpersoon
        [HttpGet]
        [Route("{id}/contactpersoon")]
        public async Task<IActionResult> GetContactpersoon([FromRoute] string id)
        {
            var contactpersonen = _context.Onderzoeken.Where(onderzoek => onderzoek.Id.ToString() == id).ToList();

            return Ok(contactpersonen);
        }

        // Route: api/onderzoek/{onderzoekid}/trackinggegevens
        [HttpGet]
        [Route("{id}/trackinggegegvens")]
        public async Task<IActionResult> GetTrackingGegevens([FromRoute] string id)
        {
            var onderzoek = _context.Onderzoeken.Where(onderzoek => onderzoek.Id.ToString() == id).First();

            return Ok(onderzoek.TrackingGegevens?.Data);
        }

        // Route: api/onderzoek/{onderzoekid}/vragen
        [HttpGet]
        [Route("{onderzoekid}/vragen")]
        public async Task<IActionResult> GetVragenFromOnderzoek([FromRoute] string onderzoekid)
        {
            var vragen = _context.Vragen
                .Where(vraag => vraag.OnderzoekID.Equals(Guid.Parse(onderzoekid)))
                .ToList();

            return Ok(vragen);
        }
    }
}
