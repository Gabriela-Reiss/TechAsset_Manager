using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechAssetManager.Models;
using TechAssetManager.Repositories.Implementations;
using TechAssetManager.Repositories.Interfaces;

namespace TechAssetManager.Controllers
{
    public class AtivosController : Controller
    {
        private readonly IAtivoRepository _repository;
        private readonly ICategoriaRepository _categoriaRepository;

        public AtivosController(IAtivoRepository repository, ICategoriaRepository categoriaRepository)
        {
            _repository = repository;
            _categoriaRepository = categoriaRepository;
        }

        public async Task<IActionResult> ListagemAtivos()
        {
            return View(await _repository.GetAllAtivosAsync());
        }


        [HttpGet]
        public async Task<IActionResult> CreateAtivo()
        {
            var categorias = await _categoriaRepository.GetAllCategoriesAsync();
            ViewBag.Categorias = new SelectList(categorias, "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAtivo(Ativo ativo)
        {
            if (!ModelState.IsValid)
            {
                var categorias = await _categoriaRepository.GetAllCategoriesAsync();
                ViewBag.Categorias = new SelectList(categorias, "Id", "Nome");
                return View(ativo);
            }

            await _repository.CreateAtivoAsync(ativo);
            return RedirectToAction(nameof(ListagemAtivos));
        }

        [HttpGet]
        public async Task<IActionResult> EditAtivo(int id)
        {
            var ativo = await _repository.GetByIdAsync(id);
            if (ativo == null)
                return NotFound();

            var categorias = await _categoriaRepository.GetAllCategoriesAsync();

            ViewBag.Categorias = new SelectList(
                categorias,
                "Id",
                "Nome",
                ativo.CategoriaId 
            );

            return View(ativo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAtivo(Ativo ativo)
        {
            if (!ModelState.IsValid)
            {
                var categorias = await _categoriaRepository.GetAllCategoriesAsync();

                ViewBag.Categorias = new SelectList(
                    categorias,
                    "Id",
                    "Nome",
                    ativo.CategoriaId
                );

                return View(ativo);
            }

            await _repository.UpdateAtivoAsync(ativo);
            return RedirectToAction(nameof(ListagemAtivos));
        }

        [HttpGet]
        public async Task<ActionResult> DeleteAtivo(int id)
        {
            var ativo = await _repository.GetByIdAsync(id);
            if (ativo == null) return NotFound();
            return View(ativo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ConfirmDeleteAtivo(int id)
        {
            var ativo = await _repository.GetByIdAsync(id);
            if (ativo == null) return NotFound();
            await _repository.RemoveAtivoAsync(id);
            return RedirectToAction("ListagemAtivos");
        }



    }
}
