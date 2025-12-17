using TechAssetManager.Models;

namespace TechAssetManager.Repositories.Interfaces
{
    public interface IAtivoRepository
    {
        Task<IEnumerable<Ativo>> GetAllAtivosAsync();
        Task<Ativo> GetByIdAsync(int id);

        Task CreateAtivoAsync(Ativo ativo);

        Task<IEnumerable<Categoria>> GetAllCategoriesAsync();

        Task RemoveAtivoAsync(int id);

        Task UpdateAtivoAsync(Ativo ativo);
    }
}
