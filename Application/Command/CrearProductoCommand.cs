using MediatR;

namespace InventarioPerecederos.Application.Commands
{
    public class CrearProductoCommand : IRequest<int>
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public DateTime FechaCaducidad { get; set; }
        public int CantidadInicial { get; set; }
        public string Estado { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
