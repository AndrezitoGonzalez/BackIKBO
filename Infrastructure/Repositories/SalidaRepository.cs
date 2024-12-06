using InventarioPerecederos.Application.Interfaces;
using InventarioPerecederos.Core.Entities;
using InventarioPerecederos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventarioPerecederos.Infrastructure.Repositories
{
    public class SalidaRepository : ISalidaRepository
    {
        private readonly AppDbContext _context;

        public SalidaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Salida> GetSalidaByIdAsync(int id)
        {
            return await _context.Salidas.FindAsync(id);
        }

        public async Task<List<Salida>> GetAllSalidasAsync()
        {
            return await _context.Salidas.ToListAsync();
        }

        public async Task AddSalidaAsync(Salida salida)
        {
            await _context.Salidas.AddAsync(salida);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSalidaAsync(Salida salida)
        {
            _context.Salidas.Update(salida);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSalidaAsync(int id)
        {
            var salida = await _context.Salidas.FindAsync(id);
            if (salida != null)
            {
                _context.Salidas.Remove(salida);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Salida>> GetSalidasByProductoIdAsync(int productoId)
        {
            return await _context.Salidas
                .Where(s => s.IdProducto == productoId)
                .ToListAsync();
        }
    }
}
