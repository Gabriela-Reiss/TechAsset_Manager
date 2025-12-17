using TechAssetManager.Models;

namespace TechAssetManager.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {

        Task<IEnumerable<Categoria>> GetAllCategoriesAsync();
        Task<Categoria> GetByIdAsync(int id);

        Task CreateCategoryAsync (Categoria categoria);

        Task RemoveCategoryAsync (int id);

        Task UpdateCategoryAsync (Categoria categoria);
    }
}
