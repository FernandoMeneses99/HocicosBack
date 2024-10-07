using Microsoft.AspNetCore.Mvc;
using HocicosBack.Repositorios.Interfaz;
using HocicosBack.Models;


namespace HocicosBack.Controller
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedoresController : ControllerBase
    {
        private readonly IProveedoresRepository _repository;

        public ProveedoresController(IProveedoresRepository repository)
        {
            _repository = repository;
        }
        //poner los estados a todos los enpoid
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetProveedores()
        {
            var proveedor = await _repository.GetProveedores();
            return Ok(proveedor);
        }

        [HttpGet("{id}")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetProveedor(int id)

        {
            var proveedores= await _repository.GetProveedoresByID(id);
            if (proveedores == null) return NotFound();
            return Ok(proveedores);
        }

        [HttpPost]
        public async Task<IActionResult> PostProveedores([FromBody] Proveedores proveedores)
        {
           
            var result = await _repository.PostProveedores(proveedores);
            if (result) return CreatedAtAction(nameof(GetProveedores), new { id = proveedores.ID_Proveedor }, proveedores);
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpDateProveedores(int id, [FromBody] Proveedores  proveedores) 
        {
            if (id != proveedores.ID_Proveedor) return BadRequest();
            var result = await _repository.UpdateProveedores(proveedores);
            if (result) return Ok();
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIDProveedor(int id)
        {
            var result = await _repository.DeleteProveedores (id);
            if (result) return NoContent();
            return NotFound();
        }
    }
}
