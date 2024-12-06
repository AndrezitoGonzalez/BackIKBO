namespace InventarioPerecederos.Core.Entities
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public DateTime FechaCaducidad { get; set; }
        public int CantidadInicial { get; set; }
        public string Estado { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
