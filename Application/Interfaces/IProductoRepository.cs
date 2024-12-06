using InventarioPerecederos.Core.Entities;

namespace InventarioPerecederos.Application.Interfaces
{
    public interface IProductoRepository
    {
        // Método para obtener un producto por su ID
        Task<Producto> GetProductoByIdAsync(int id);

        // Método para obtener todos los productos almacenados
        Task<List<Producto>> GetAllProductosAsync();

        // Método para agregar un nuevo producto
        Task AddProductoAsync(Producto producto);

        // Método para actualizar un producto existente
        Task UpdateProductoAsync(Producto producto);

        // Método para eliminar un producto
        Task DeleteProductoAsync(int id);

        // Método para obtener productos por su fecha de caducidad (puede ser útil para listar productos a punto de caducar)
        Task<List<Producto>> GetProductosByFechaCaducidadAsync(DateTime fecha);
    }
}
