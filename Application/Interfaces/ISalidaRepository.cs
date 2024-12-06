using InventarioPerecederos.Core.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace InventarioPerecederos.Application.Interfaces
{
    public interface ISalidaRepository
    {
        // Método para obtener una salida por su ID
        Task<Salida> GetSalidaByIdAsync(int id);

        // Método para obtener todas las salidas
        Task<List<Salida>> GetAllSalidasAsync();

        // Método para agregar una nueva salida
        Task AddSalidaAsync(Salida salida);

        // Método para actualizar una salida
        Task UpdateSalidaAsync(Salida salida);

        // Método para eliminar una salida
        Task DeleteSalidaAsync(int id);

        // Método para obtener las salidas de un producto específico
        Task<List<Salida>> GetSalidasByProductoIdAsync(int productoId);
    }
}
