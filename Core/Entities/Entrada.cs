namespace InventarioPerecederos.Core.Entities
{
    public class Entrada
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public DateTime FechaEntrada { get; set; }
        public int Cantidad { get; set; }
        public string Proveedor { get; set; }
        public decimal PrecioTotal { get; set; }
        public Producto Producto { get; set; }
    }
}
