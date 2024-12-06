using InventarioPerecederos.Core.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace InventarioPerecederos.Application.Interfaces
{
    public interface IEntradaRepository
    {
        // Método para obtener una entrada por su ID
        Task<Entrada> GetEntradaByIdAsync(int id);

        // Método para obtener todas las entradas
        Task<List<Entrada>> GetAllEntradasAsync();

        // Método para agregar una nueva entrada
        Task AddEntradaAsync(Entrada entrada);

        // Método para actualizar una entrada
        Task UpdateEntradaAsync(Entrada entrada);

        // Método para eliminar una entrada
        Task DeleteEntradaAsync(int id);

        // Método para obtener las entradas de un producto específico
        Task<List<Entrada>> GetEntradasByProductoIdAsync(int productoId);
    }
}
