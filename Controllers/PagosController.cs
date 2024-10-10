using Microsoft.AspNetCore.Mvc;
using HocicosBack.Repositorios.Interfaz;
using HocicosBack.Models;


namespace HocicosBack.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class PagosController : ControllerBase
    {
        private readonly IClientesRepository _repository;

        public PagosController(IClientesRepository repository)
        {
            _repository = repository;
        }
        //poner los estados a todos los enpoid
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetClientes()
        {
            var clientes = await _repository.GetClientes();
            return Ok(clientes);
        }

        [HttpGet("{id}")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetClientes(int id)

        {
            var cliente = await _repository.GetClientesByID(id);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> PostClientes([FromBody] Clientes clientes)
        {

            var result = await _repository.PostClientes(clientes);
            if (result) return CreatedAtAction(nameof(GetClientes), new { id = clientes.ClienteID }, clientes);
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClientes(int id, [FromBody] Clientes clientes)
        {
            if (id != clientes.ClienteID) return BadRequest();
            var result = await _repository.UpdateClientes(clientes);
            if (result) return Ok();
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientes(int id)
        {
            var result = await _repository.DeleteClientes(id);
            if (result) return NoContent();
            return NotFound();
        }
    }
}