using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCENTITYCRUD.Data;
using MVCENTITYCRUD.Models;

namespace MVCENTITYCRUD.Controllers
{
    public class ClienteController : Controller
    {
        private readonly AppDBContext _appDBContext;
        public ClienteController(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            List<Cliente> lista = await _appDBContext.Clientes.ToListAsync();
            return View(lista);
        }
        [HttpGet]
        public IActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Nuevo(Cliente cliente)
        {
            await _appDBContext.Clientes.AddAsync(cliente);
            await _appDBContext.SaveChangesAsync();

            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            Cliente cliente = await _appDBContext.Clientes.FirstAsync(e => e.IdCliente == id);

            return View(cliente);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(Cliente cliente)
        {
            _appDBContext.Clientes.Update(cliente);
            await _appDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }
        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            Cliente cliente = await _appDBContext.Clientes.FirstAsync(e => e.IdCliente == id);

            _appDBContext.Clientes.Remove(cliente);
            await _appDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }
    }
}
