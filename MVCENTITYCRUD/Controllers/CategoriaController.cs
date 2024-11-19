using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCENTITYCRUD.Data;
using MVCENTITYCRUD.Models;

namespace MVCENTITYCRUD.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly AppDBContext _appDBContext;
        public CategoriaController(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        [HttpGet]


        public async Task<IActionResult> Lista()
        {
            List<Categoria> categoria = await _appDBContext.Categorias.ToListAsync();
            return View(categoria);
        }
        [HttpGet]
        public IActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Nuevo(Categoria categoria)
        {
            await _appDBContext.Categorias.AddAsync(categoria);
            await _appDBContext.SaveChangesAsync();

            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            Categoria categoria = await _appDBContext.Categorias.FirstAsync(e => e.IdCategoria == id);

            return View(categoria);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(Categoria categoria)
        {
            _appDBContext.Categorias.Update(categoria);
            await _appDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }
        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            Categoria categoria = await _appDBContext.Categorias.FirstAsync(e => e.IdCategoria == id);

            _appDBContext.Categorias.Remove(categoria);
            await _appDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }


    }
}
