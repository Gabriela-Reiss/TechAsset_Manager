using Microsoft.EntityFrameworkCore;
using TechAssetManager.Data.Context;
using TechAssetManager.Models;
using TechAssetManager.Repositories.Interfaces;

namespace TechAssetManager.Repositories.Implementations
{
    public class AtivoRepository : IAtivoRepository
    {
        private readonly TechAssetContext _context;

        public AtivoRepository(TechAssetContext context)
        {
            _context = context;
        }
        public async Task CreateAtivoAsync(Ativo ativo)
        {
            await _context.Ativos.AddAsync(ativo);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Categoria>> GetAllCategoriesAsync()
        {
            return await _context.Categorias.ToListAsync();
        }

        public async Task<IEnumerable<Ativo>> GetAllAtivosAsync()
        {
            return await _context.Ativos.Include(a => a.Categoria)
                .ToListAsync();
        }

        public async Task<Ativo> GetByIdAsync(int id)
        {
            return await _context.Ativos.FindAsync(id);
        }

        public async Task RemoveAtivoAsync(int id)
        {
            var ativo = await _context.Ativos.FindAsync(id);
            if (ativo != null) { 
                _context.Ativos.Remove(ativo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAtivoAsync(Ativo ativo)
        {
            _context.Ativos.Update(ativo);
            await _context.SaveChangesAsync();
        }

        
    }
}
