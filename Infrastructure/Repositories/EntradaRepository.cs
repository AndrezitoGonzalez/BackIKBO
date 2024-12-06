using InventarioPerecederos.Application.Interfaces;
using InventarioPerecederos.Core.Entities;
using InventarioPerecederos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventarioPerecederos.Infrastructure.Repositories
{
    public class EntradaRepository : IEntradaRepository
    {
        private readonly AppDbContext _context;

        public EntradaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Entrada> GetEntradaByIdAsync(int id)
        {
            return await _context.Entradas.FindAsync(id);
        }

        public async Task<List<Entrada>> GetAllEntradasAsync()
        {
            return await _context.Entradas.ToListAsync();
        }

        public async Task AddEntradaAsync(Entrada entrada)
        {
            await _context.Entradas.AddAsync(entrada);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEntradaAsync(Entrada entrada)
        {
            _context.Entradas.Update(entrada);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEntradaAsync(int id)
        {
            var entrada = await _context.Entradas.FindAsync(id);
            if (entrada != null)
            {
                _context.Entradas.Remove(entrada);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Entrada>> GetEntradasByProductoIdAsync(int productoId)
        {
            return await _context.Entradas
                .Where(e => e.IdProducto == productoId)
                .ToListAsync();
        }
    }
}
