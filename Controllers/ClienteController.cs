using Microsoft.AspNetCore.Mvc;
using Sales_Management.Context;
using Sales_Management.Models;

namespace Sales_Management.Controllers
{
    public class ClienteController : Controller
    {
     
        private readonly AppDbContext _context;

        public ClienteController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var clientes = _context.Clients.ToList();
            return View(clientes);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = _context.Clients.Find(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Criar([Bind("ClienteId, Nome, Sobrenome, Endereco, Email, NumeroTelefone, DataNascimento")] ClientModel cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = _context.Clients.Find(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ClienteId, Nome, Sobrenome, Endereco, Email, NumeroTelefone, DataNascimento")] ClientModel cliente)
        {
            if (id != cliente.ClientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(cliente);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = _context.Clients.Find(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int id)
        {
            var cliente = _context.Clients.Find(id);
            _context.Clients.Remove(cliente!);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
