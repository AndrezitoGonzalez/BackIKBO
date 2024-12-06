using MediatR;
using InventarioPerecederos.Core.Entities;

namespace InventarioPerecederos.Application.Queries
{
    public class ObtenerProductosQuery : IRequest<List<Producto>>
    {
    }
}
