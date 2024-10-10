using Microsoft.AspNetCore.Mvc;
using HocicosBack.Repositorios.Interfaz;
using HocicosBack.Models;


namespace HocicosBack.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class PagosController : ControllerBase
    {
        private readonly IPagosRepository _repository;

        public PagosController(IPagosRepository repository)
        {
            _repository = repository;
        }
        //poner los estados a todos los enpoid
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetPagos()
        {
            var pagos = await _repository.GetPagos();
            return Ok(pagos);
        }

        [HttpGet("{id}")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetPagos(int id)

        {
            var pagos = await _repository.GetPagosByID(id);
            if (pagos == null) return NotFound();
            return Ok(pagos);
        }

        [HttpPost]
        public async Task<IActionResult> PostClientes([FromBody] Pagos pagos)
        {

            var result = await _repository.PostPagos(pagos);
            if (result) return CreatedAtAction(nameof(GetPagos), new { id = pagos.PagoId }, pagos);
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePagos(int id, [FromBody] Pagos pagos)
        {
            if (id != pagos.PagoId) return BadRequest();
            var result = await _repository.UpdatePagos(pagos);
            if (result) return Ok();
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePagos(int id)
        {
            var result = await _repository.DeletePagos(id);
            if (result) return NoContent();
            return NotFound();
        }
    }
}