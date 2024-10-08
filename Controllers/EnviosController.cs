using Microsoft.AspNetCore.Mvc;
using HocicosBack.Repositorios.Interfaz;
using HocicosBack.Models;


namespace HocicosBack.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class EnviosController : ControllerBase
    {
        private readonly IEnviosRepository _repository;

        public EnviosController(IEnviosRepository repository)
        {
            _repository = repository;
        }
        //poner los estados a todos los enpoid
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetEnvios()
        {
            var envios = await _repository.GetEnvios();
            return Ok(envios);
        }

        [HttpGet("{id}")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetEnvios(int id)

        {
            var envios = await _repository.GetEnviosByID(id);
            if (envios == null) return NotFound();
            return Ok(envios);
        }

        [HttpPost]
        public async Task<IActionResult> PostEnvios([FromBody] Envios envios)
        {

            var result = await _repository.PostEnvios(envios);
            if (result) return CreatedAtAction(nameof(GetEnvios), new { id = envios.EnvíoID }, envios);
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpDateEnvios(int id, [FromBody] Envios envios)
        {
            if (id != envios.EnvíoID) return BadRequest();
            var result = await _repository.UpdateEnvios(envios);
            if (result) return Ok();
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIDEnvios(int id)
        {
            var result = await _repository.DeleteEnvios(id);
            if (result) return NoContent();
            return NotFound();
        }
    }
}
