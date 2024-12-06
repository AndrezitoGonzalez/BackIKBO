using MediatR;
using InventarioPerecederos.Infrastructure.Data;
using InventarioPerecederos.Core.Entities;
using InventarioPerecederos.Application.Commands;

namespace InventarioPerecederos.Application.Handlers
{
    public class CrearProductoHandler : IRequestHandler<CrearProductoCommand, int>
    {
        private readonly AppDbContext _context;

        public CrearProductoHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CrearProductoCommand request, CancellationToken cancellationToken)
        {
            var producto = new Producto
            {
                Nombre = request.Nombre,
                Descripcion = request.Descripcion,
                Categoria = request.Categoria,
                FechaCaducidad = request.FechaCaducidad,
                CantidadInicial = request.CantidadInicial,
                Estado = request.Estado,
                PrecioUnitario = request.PrecioUnitario
            };

            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            return producto.Id;
        }
    }
}
