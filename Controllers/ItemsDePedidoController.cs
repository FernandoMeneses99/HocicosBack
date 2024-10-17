using Microsoft.AspNetCore.Mvc;
using HocicosBack.Repositorios.Interfaz;
using HocicosBack.Models;


namespace HocicosBack.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class ItemsPedidoController : ControllerBase
    {
        private readonly IItemsDePedidoRepository _repository;

        public ItemsPedidoController(IItemsDePedidoRepository repository)
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
            var itemsDePedidos = await _repository.GetItemsDePedido();
            return Ok(itemsDePedidos);
        }

        [HttpGet("{id}")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetItemsDePedidoByID(int id)
        {
            var cliente = await _repository.GetItemDePedidoByID(id);
            if (cliente == null) return NotFound();
            return Ok(cliente);
    }
    }
}