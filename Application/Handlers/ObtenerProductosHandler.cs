using MediatR;
using InventarioPerecederos.Infrastructure.Data;
using InventarioPerecederos.Core.Entities;
using InventarioPerecederos.Application.Queries;
using Microsoft.EntityFrameworkCore;

namespace InventarioPerecederos.Application.Handlers
{
    public class ObtenerProductosHandler : IRequestHandler<ObtenerProductosQuery, List<Producto>>
    {
        private readonly AppDbContext _context;

        public ObtenerProductosHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Producto>> Handle(ObtenerProductosQuery request, CancellationToken cancellationToken)
        {
            return await _context.Productos.ToListAsync();
        }
    }
}
