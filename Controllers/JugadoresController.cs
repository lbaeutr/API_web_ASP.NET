using api_psp.Models;
using api_psp.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_psp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JugadoresController : ControllerBase
    {
        private readonly JugadorService _jugadorService;

        public JugadoresController(JugadorService jugadorService)
        {
            _jugadorService = jugadorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Jugador>>> GetJugadores()
        {
            var jugadores = await _jugadorService.GetAllAsync();
            return Ok(jugadores);
        }

        [HttpGet("top5")]
        public async Task<ActionResult<List<Jugador>>> GetTop5()
        {
            var jugadores = await _jugadorService.GetTop5JugadoresAsync();
            return Ok(jugadores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Jugador>> GetJugador(string id)
        {
            var jugador = await _jugadorService.GetByIdAsync(id);
            if (jugador == null) return NotFound();
            return Ok(jugador);
        }

        [HttpPost]
        public async Task<IActionResult> CrearJugador(Jugador jugador)
        {
            await _jugadorService.CreateAsync(jugador);
            return CreatedAtAction(nameof(GetJugador), new { id = jugador.Id }, jugador);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarJugador(string id, Jugador jugador)
        {
            var existingJugador = await _jugadorService.GetByIdAsync(id);
            if (existingJugador == null) return NotFound();

            await _jugadorService.UpdateAsync(id, jugador);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarJugador(string id)
        {
            var jugador = await _jugadorService.GetByIdAsync(id);
            if (jugador == null) return NotFound();

            await _jugadorService.DeleteAsync(id);
            return NoContent();
        }
    }
}
