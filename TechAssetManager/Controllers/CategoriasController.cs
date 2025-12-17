using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechAssetManager.Models;
using TechAssetManager.Repositories.Interfaces;

namespace TechAssetManager.Controllers;

public class CategoriasController : Controller
{

    private readonly ICategoriaRepository _repository;

    public CategoriasController(ICategoriaRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> ListagemCategorias()
    {
        return View(await _repository.GetAllCategoriesAsync());
    }

    [HttpGet]
    public IActionResult CreateCategoria()
    {
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateCategoria(Categoria categoria)
    {
        if (ModelState.IsValid)
        {
            await _repository.CreateCategoryAsync(categoria);
            return RedirectToAction("ListagemCategorias");
        }

        return View(categoria);
    }

    [HttpGet]
    public async Task<IActionResult> EditCategoria(int id)
    {
        if (id == null) return NotFound();
        var categoria = await _repository.GetByIdAsync(id);
        if (categoria == null) return NotFound();
        return View(categoria);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> EditCategoria(int id, Categoria categoria)
    {
        if (id != categoria.Id) return NotFound();
        if (ModelState.IsValid)
        {
            try
            {
                await _repository.UpdateCategoryAsync(categoria);
                return RedirectToAction("ListagemCategorias");
            }
            catch (DbUpdateConcurrencyException)
            {

                return NotFound();
            }   
                
            
        }
        return View(categoria);
    }

    [HttpGet]
    public async Task<ActionResult> DeleteCategoria(int id)
    {
        var categoria = await _repository.GetByIdAsync(id);
        if (categoria == null) return NotFound();
        return View(categoria);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> ConfirmDeleteCategoria(int id)
    {
        var categoria = await _repository.GetByIdAsync(id);
        if (categoria == null) return NotFound();
        await _repository.RemoveCategoryAsync(id);
        return RedirectToAction("ListagemCategorias");
    }


}
