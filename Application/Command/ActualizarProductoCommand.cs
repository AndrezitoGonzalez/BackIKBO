using MediatR;

namespace InventarioPerecederos.Application.Commands
{
    public class ActualizarProductoCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public DateTime FechaCaducidad { get; set; }
        public int CantidadInicial { get; set; }
        public string Estado { get; set; }
        public decimal PrecioUnitario { get; set; }

        // Constructor vacío necesario para la deserialización
        public ActualizarProductoCommand() { }

        // Constructor con parámetros para el uso interno de la clase
        public ActualizarProductoCommand(int idProducto, string nombre, string descripcion, string categoria, DateTime fechaCaducidad, int cantidadInicial, string estado, decimal precioUnitario)
        {
            Id = idProducto;
            Nombre = nombre;
            Descripcion = descripcion;
            Categoria = categoria;
            FechaCaducidad = fechaCaducidad;
            CantidadInicial = cantidadInicial;
            Estado = estado;
            PrecioUnitario = precioUnitario;
        }
    }
}
