using MediatR;

namespace InventarioPerecederos.Application.Commands
{
    public class EliminarProductoCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public EliminarProductoCommand(int idProducto)
        {
            Id = idProducto;
        }
    }
}
