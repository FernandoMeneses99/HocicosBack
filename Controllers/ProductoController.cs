using Microsoft.AspNetCore.Mvc;
using HocicosBack.Repositorios.Interfaz;
using HocicosBack.Models;



namespace HocicosBack.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductosRepository _repository;

        public ProductosController(IProductosRepository repository)
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
            var productos = await _repository.GetProductos();
            return Ok(productos);
        }

        [HttpGet("{id}")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetProductos(int id)

        {
            var productos = await _repository.GetProductosByID(id);
            if (productos == null) return NotFound();
            return Ok(productos);
        }

        [HttpPost]
        public async Task<IActionResult> PostProductos([FromBody] Productos productos)
        {

            var result = await _repository.PostProductos(productos);
            if (result) return CreatedAtAction(nameof(GetProductos), new { id = productos.ProductoID}, productos);
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpDateProductos(int id, [FromBody] Productos productos)
        {
            if (id != productos.ProductoID) return BadRequest();
            var result = await _repository.UpdateProductos(productos);
            if (result) return Ok();
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductos(int id)
        {
            var result = await _repository.DeleteProductos(id);
            if (result) return NoContent();
            return NotFound();
        }
    }
}

