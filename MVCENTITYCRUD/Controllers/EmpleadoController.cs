using Microsoft.AspNetCore.Mvc;
using MVCENTITYCRUD.Data;
using MVCENTITYCRUD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace MVCENTITYCRUD.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly AppDBContext _appDBContext;
        public EmpleadoController(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        private async Task CargarRolesAsync()
        {
            ViewData["Roles"] = await _appDBContext.Roles.ToListAsync();
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            List<Empleado> lista = await _appDBContext.Empleados
                .Include(e => e.Rol) 
                .ToListAsync();
            return View(lista);
        }  
        [HttpGet]
        public async Task<IActionResult> Nuevo()
        {
            await CargarRolesAsync();
            return View();
        }  
        [HttpPost]
        public async Task<IActionResult> Nuevo(Empleado empleado)
        {
            await _appDBContext.Empleados.AddAsync(empleado);
            await _appDBContext.SaveChangesAsync();
            
            return RedirectToAction(nameof(Lista));
        } 
        
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            await CargarRolesAsync();
            Empleado empleado = await _appDBContext.Empleados.FirstAsync(e => e.IdEmpleado == id);
            
            return View(empleado);
        }  
        [HttpPost]
        public async Task<IActionResult> Editar(Empleado empleado)
        {
            _appDBContext.Empleados.Update(empleado);
            await _appDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }
        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            Empleado empleado = await _appDBContext.Empleados.FirstAsync(e => e.IdEmpleado == id);

            _appDBContext.Empleados.Remove(empleado);
            await _appDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

    }
}
