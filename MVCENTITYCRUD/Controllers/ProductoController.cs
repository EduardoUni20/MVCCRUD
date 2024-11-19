using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCENTITYCRUD.Data;
using MVCENTITYCRUD.Models;

namespace MVCENTITYCRUD.Controllers
{
    public class ProductoController : Controller
    {
        private readonly AppDBContext _appDBContext;
        public ProductoController(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        private async Task CargarCategoriasAsync()
        {

            ViewData["Categorias"] = await _appDBContext.Categorias.ToListAsync();
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            List<Producto> lista = await _appDBContext.Productos
                .Include(e => e.Categoria)
                .ToListAsync();
            return View(lista);
        }
        [HttpGet]
        public async Task<IActionResult> Nuevo()
        {
            await CargarCategoriasAsync();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Nuevo(Producto producto)
        {
            await _appDBContext.Productos.AddAsync(producto);
            await _appDBContext.SaveChangesAsync();

            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            await CargarCategoriasAsync();

            Producto producto = await _appDBContext.Productos.FirstAsync(e => e.IdProducto == id);

            return View(producto);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(Producto producto)
        {
            _appDBContext.Productos.Update(producto);
            await _appDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }
        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            Producto producto = await _appDBContext.Productos.FirstAsync(e => e.IdProducto == id);

            _appDBContext.Productos.Remove(producto);
            await _appDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }
    }
}
