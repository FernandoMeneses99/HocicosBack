using Microsoft.AspNetCore.Mvc;
using HocicosBack.Repositorios.Interfaz;
using HocicosBack.Models;


namespace HocicosBack.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class ItemsDePedidosController : ControllerBase
    {
        private readonly IItemsDePedidosRepository _repository;

        public ItemsDePedidosController(IItemsDePedidosRepository repository)
        {
            _repository = repository;
        }
        //poner los estados a todos los enpoid
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetItemsPedido()
        {
            var envios = await _repository.GetItemsDePedidos();
            return Ok(envios);
        }

        [HttpGet("{id}")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetItemsPedido(int id)

        {
            var envios = await _repository.GetItemsDePedidosByID(id);
            if (envios == null) return NotFound();
            return Ok(envios);
        }

        [HttpPost]
        public async Task<IActionResult> PostItemsPedido([FromBody] ItemsDePedido itemsDePedido)
        {

            var result = await _repository.PostItemsDePedidos(itemsDePedido);
            if (result) return CreatedAtAction(nameof(GetItemsPedido), new { id = itemsDePedido. ItemDePedidoID}, itemsDePedido);
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpDateItemsPedido(int id, [FromBody] ItemsDePedido itemsDePedido)
        {
            if (id != itemsDePedido.ItemDePedidoID) return BadRequest();
            var result = await _repository.UpdateItemsDePedidos(itemsDePedido);
            if (result) return Ok();
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemsDePedidos(int id)
        {
            var result = await _repository.DeleteItemsDePedidos(id);
            if (result) return NoContent();
            return NotFound();
        }
    }
}
