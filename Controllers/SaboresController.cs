using Microsoft.AspNetCore.Mvc;
using HocicosBack.Repositorios.Interfaz;
using HocicosBack.Models;



namespace HocicosBack.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class SaboresController : ControllerBase
    {
        private readonly ISaboresRepository _repository;

        public SaboresController(ISaboresRepository repository)
        {
            _repository = repository;
        }
        //poner los estados a todos los enpoid
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetSabores()
        {
            var Sabores = await _repository.GetSabores();
            return Ok(Sabores);
        }

        [HttpGet("{id}")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetSabores(int id)

        {
            var sabores = await _repository.GetSaboresByID(id);
            if (sabores == null) return NotFound();
            return Ok(sabores);
        }

        [HttpPost]
        public async Task<IActionResult> PostSabores([FromBody] Sabores sabores)
        {

            var result = await _repository.PostSabores(sabores);
            if (result) return CreatedAtAction(nameof(GetSabores), new { id = sabores.SaborID }, sabores);
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpDateSabores(int id, [FromBody] Sabores sabores)
        {
            if (id != sabores.SaborID) return BadRequest();
            var result = await _repository.UpdateSabores(sabores);
            if (result) return Ok();
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSabores(int id)
        {
            var result = await _repository.DeleteSabores(id);
            if (result) return NoContent();
            return NotFound();
        }
    }
}

