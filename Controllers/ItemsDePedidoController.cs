using Microsoft.AspNetCore.Mvc;
using HocicosBack.Repositorios.Interfaz;
using HocicosBack.Models;


namespace HocicosBack.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class ItemsPedidoController : ControllerBase
    {
        private readonly IItemsPedidoRepository _repository;

        public ItemsPedidoController(IEnviosRepository repository)
        {
            _repository = repository;
        }
        //poner los estados a todos los enpoid
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetItemsDePedido()
        {
            var envios = await _repository.GetItemsDePedido();
            return Ok(envios);
        }

        [HttpGet("{id}")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetItemsPedido(int id)

        {
            var items = await _repository.GetItemsPedidoByID(id);
            if (items == null) return NotFound();
            return Ok(items);
        }

        [HttpPost]
        public async Task<IActionResult> PostItemsPedido([FromBody] ItemsDePedido items)
        {

            var result = await _repository.PostItemsPedido(items);
            if (result) return CreatedAtAction(nameof(GetEnvios), new { id = items.itemsDePedidoByID }, itemsDePedidoID);
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