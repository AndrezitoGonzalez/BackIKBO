using MediatR;
using Microsoft.AspNetCore.Mvc;
using InventarioPerecederos.Application.Commands;
using InventarioPerecederos.Application.Queries;

namespace InventarioPerecederos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ObtenerProducto")]
        public async Task<IActionResult> ObtenerProducto()
        {
            var productos = await _mediator.Send(new ObtenerProductosQuery());
            return Ok(productos);
        }

        [HttpPost("CrearProducto")]
        public async Task<IActionResult> CrearProducto([FromBody] CrearProductoCommand command)
        {
            var productoId = await _mediator.Send(command);
            return CreatedAtAction(nameof(ObtenerProducto), new { id = productoId }, null);
        }
        // Endpoint para actualizar un producto
        [HttpPut("ActualizarProducto/{id}")]
        public async Task<IActionResult> ActualizarProducto(int id, [FromBody] ActualizarProductoCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("El ID del producto no coincide.");
            }

            // Llama al handler para actualizar el producto de manera asincrónica
            var resultado = await _mediator.Send(command);
            if (!resultado)
            {
                return NotFound("Producto no encontrado.");
            }

            return NoContent(); // Código 204 (actualización exitosa sin contenido adicional)
        }

        // Endpoint para eliminar un producto
        [HttpDelete("EliminarProducto/{id}")]
        public async Task<IActionResult> EliminarProducto(int id)
        {
            // Crea el comando para eliminar el producto
            var command = new EliminarProductoCommand(id);

            // Llama al handler para eliminar el producto de manera asincrónica
            var resultado = await _mediator.Send(command);
            if (!resultado)
            {
                return NotFound("Producto no encontrado.");
            }

            return NoContent(); // Código 204 (eliminación exitosa sin contenido adicional)
        }
    }
}
