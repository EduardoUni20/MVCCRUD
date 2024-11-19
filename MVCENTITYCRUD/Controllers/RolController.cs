using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCENTITYCRUD.Data;
using MVCENTITYCRUD.Models;

namespace MVCENTITYCRUD.Controllers
{
    public class RolController : Controller
    {
        private readonly AppDBContext _appDBContext;
        public RolController(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            List<Rol> lista = await _appDBContext.Roles.ToListAsync();
            return View(lista);
        }
        [HttpGet]
        public IActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Nuevo(Rol rol)
        {
            await _appDBContext.Roles.AddAsync(rol);
            await _appDBContext.SaveChangesAsync();

            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            Rol rol = await _appDBContext.Roles.FirstAsync(e => e.IdRol == id);

            return View(rol);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(Rol rol)
        {
            _appDBContext.Roles.Update(rol);
            await _appDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }
        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            Rol rol = await _appDBContext.Roles.FirstAsync(e => e.IdRol == id);

            _appDBContext.Roles.Remove(rol);
            await _appDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }
    }
}
