using Microsoft.AspNetCore.Mvc;
using HocicosBack.Repositorios.Interfaz;
using HocicosBack.Models;


namespace HocicosBack.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class IPedidosController : ControllerBase
    {
        private readonly IPedidosRepository _repository;

        public IPedidosController(IPedidosRepository repository)
        {
            _repository = repository;
        }
        //poner los estados a todos los enpoid
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetPedido()
        {
            var envios = await _repository.GetPedidos();
            return Ok(envios);
        }

        [HttpGet("{id}")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetPedido(int id)

        {
            var pedidos = await _repository.GetPedidosByID(id);
            if (pedidos == null) return NotFound();
            return Ok(pedidos);
        }

        [HttpPost]
        public async Task<IActionResult> PostPedido([FromBody] Pedidos pedidos)
        {

            var result = await _repository.PostPedidos(pedidos);
            if (result) return CreatedAtAction(nameof(GetPedido), new { id = pedidos.PedidoID }, pedidos);
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpDatePedido(int id, [FromBody] Pedidos pedidos)
        {
            if (id != pedidos.PedidoID) return BadRequest();
            var result = await _repository.UpdatePedidos(pedidos);
            if (result) return Ok();
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedidos(int id)
        {
            var result = await _repository.DeletePedidos(id);
            if (result) return NoContent();
            return NotFound();
        }
    }
}
