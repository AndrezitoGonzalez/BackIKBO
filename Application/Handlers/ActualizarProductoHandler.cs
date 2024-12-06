using MediatR;
using InventarioPerecederos.Application.Commands;
using InventarioPerecederos.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace InventarioPerecederos.Application.Handlers
{
    public class ActualizarProductoHandler : IRequestHandler<ActualizarProductoCommand, bool>
    {
        private readonly IProductoRepository _productoRepository;

        public ActualizarProductoHandler(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<bool> Handle(ActualizarProductoCommand request, CancellationToken cancellationToken)
        {
            var producto = await _productoRepository.GetProductoByIdAsync(request.Id);

            if (producto == null)
                return false;

            // Actualizar las propiedades del producto
            producto.Nombre = request.Nombre;
            producto.Descripcion = request.Descripcion;
            producto.Categoria = request.Categoria;
            producto.CantidadInicial = request.CantidadInicial;
            producto.PrecioUnitario = request.PrecioUnitario;
            producto.Estado = request.Estado;
            producto.FechaCaducidad = request.FechaCaducidad;

            await _productoRepository.UpdateProductoAsync(producto);
            return true;
        }
    }
}
