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

        // Route: /api/onderzoek
        [HttpGet]
        [Route("/")]
        public async Task<IActionResult> GetOnderzoeken()
        {
            var onderzoeken = await _context.Onderzoeken.AllAsync((onderzoek) => true);

            return Ok(onderzoeken);
        }

        // Route: /api/onderzoek/{onderzoekid}
        [HttpGet]
        [Route("/{id}")]
        public async Task<IActionResult> GetOnderzoekByIdAsync([FromRoute] string id)
        {
            var onderzoek = await _context.Onderzoeken.FirstOrDefaultAsync((onderzoek) => onderzoek.Id.ToString() == id);

            if (onderzoek == null)
            {
                return NotFound("Onderzoek niet gevonden.");
            }

            return Ok(onderzoek);
        }

        // Route: /api/onderzoek/{onderzoekid}/vraag/{vraagid}/antwoord/{antwoordid}
        [HttpGet]
        [Route("/{id}/vraag/{vraagid}/antwoord/{antwoordid}")]
        public async Task<IActionResult> GetAntwoordByIdAsync([FromRoute] string id, [FromRoute] string vraagid, [FromRoute] string antwoordid)
        {
            var onderzoek = await _context.Onderzoeken.FirstOrDefaultAsync((onderzoek) => onderzoek.Id.ToString() == id);

            if (onderzoek == null)
            {
                return NotFound("Onderzoek niet gevonden.");
            }

            var vraag = onderzoek.Vragen?.Find((vraag) => vraag.VraagID.ToString() == vraagid);

            if (vraag == null)
            {
                return NotFound("Vraag niet gevonden.");
            }

            var antwoord = vraag.Antwoorden?.Find((antwoord) => antwoord.AntwoordID.ToString() == antwoordid);

            if (antwoord == null)
            {
                return NotFound("Antwoord niet gevonden.");
            }

            return Ok(antwoord);
        }

        // Route /api/onderzoek/create
        [HttpPost]
        [Route("/create")]
        public async Task<IActionResult> CreateOnderzoek(OnderzoekModel onderzoek)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            OnderzoekModel postOnderzoek = new OnderzoekModel();
            postOnderzoek.Id = onderzoek.Id;
            postOnderzoek.Beschrijving = onderzoek.Beschrijving;
            postOnderzoek.Bedrijf = onderzoek.Bedrijf;
            postOnderzoek.Begindatum = onderzoek.Begindatum;
            postOnderzoek.Einddatum = onderzoek.Einddatum;
            postOnderzoek.Locatie = onderzoek.Locatie;
            postOnderzoek.BeloningBeschrijving = onderzoek.BeloningBeschrijving;
            postOnderzoek.Titel = onderzoek.Titel;
            postOnderzoek.OnderzoekSoort = onderzoek.OnderzoekSoort;
            postOnderzoek.Vragen = onderzoek.Vragen;

            if (await _context.Onderzoeken.AnyAsync(onderzoek => onderzoek.Id == postOnderzoek.Id))
            {
                return BadRequest("Onderzoek bestaat al.");
            }

            _context.Add(postOnderzoek);
            await _context.SaveChangesAsync();

            return Created();
        }
    }
}
