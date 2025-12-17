using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TechAssetManager.Data.Context;
using TechAssetManager.Models;
using TechAssetManager.Repositories.Interfaces;

namespace TechAssetManager.Repositories.Implementations
{
    public class CategoriaRepository : ICategoriaRepository
    {

        private readonly TechAssetContext _context;

        public CategoriaRepository(TechAssetContext context)
        {
            _context = context;
        }
        

        public async Task CreateCategoryAsync(Categoria categoria)
        {
             await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Categoria>> GetAllCategoriesAsync()
        {
            return await _context.Categorias.ToListAsync();
        }

        public async Task<Categoria> GetByIdAsync(int id)
        {
            return await _context.Categorias.FindAsync(id);
            
            
        }

        public async Task RemoveCategoryAsync(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria != null) { 
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateCategoryAsync(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            await _context.SaveChangesAsync();
        }
    }
}
