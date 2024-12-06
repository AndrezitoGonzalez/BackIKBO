using MediatR;
using InventarioPerecederos.Application.Commands;
using InventarioPerecederos.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace InventarioPerecederos.Application.Handlers
{
    public class EliminarProductoHandler : IRequestHandler<EliminarProductoCommand, bool>
    {
        private readonly IProductoRepository _productoRepository;

        public EliminarProductoHandler(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<bool> Handle(EliminarProductoCommand request, CancellationToken cancellationToken)
        {
            // Obtiene el producto por ID de manera asincrónica
            var producto = await _productoRepository.GetProductoByIdAsync(request.Id);
            if (producto == null)
                return false;  // Si no se encuentra el producto, retornamos falso

            // Llama al repositorio para eliminar el producto de manera asincrónica
            await _productoRepository.DeleteProductoAsync(request.Id);
            return true;  // Retorna true si la eliminación fue exitosa
        }
    }
}
