namespace InventarioPerecederos.Core.Entities
{
    public class Salida
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public DateTime FechaSalida { get; set; }
        public int Cantidad { get; set; }
        public string MotivoSalida { get; set; }
        public decimal PrecioTotal { get; set; }
        public Producto Producto { get; set; }
    }
}
