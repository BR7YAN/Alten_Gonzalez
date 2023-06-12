using Alten_Gonzalez.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Alten_Gonzalez.Controllers
{
    public class CarrelloController : Controller
    {
        private readonly ECOMMERCEContext _context;
        public CarrelloController(ECOMMERCEContext context)
        {
            _context = context;
        }
        public IActionResult Acquisto() 
        {
            ViewBag.Utenti = new SelectList(_context.Utentis, "Id", "Nome");
            ViewBag.Prodotti = new SelectList(_context.Prodottis, "Id", "Nome");
            return View();
        }
        [HttpPost]
        public IActionResult Acquisto(int idShopper, int idProdotto)
        {
            Console.WriteLine(idShopper);
            Console.WriteLine(idProdotto);
            var nuovoRecord = new ProdottiCarrello();
            nuovoRecord.Id = _context.ProdottiCarrellos.Any() ? _context.ProdottiCarrellos.Max(c => c.Id + 1) : 0;
            var query = from c in _context.Carrellis
                              join e in _context.Utentis on c.IdUtente equals e.Id
                              where e.Id == idShopper
                              select c.Id;
            nuovoRecord.IdCarrello = query.FirstOrDefault();
            nuovoRecord.IdProdotto = idProdotto;
            _context.ProdottiCarrellos.Add(nuovoRecord);
            _context.SaveChanges();
            return RedirectToAction("MostraCarrello", query.FirstOrDefault());
        }
        public IActionResult MostraCarrello(int idCarrello)
        {
            var query = from r in _context.ProdottiCarrellos
                        join p in _context.Prodottis on r.IdProdotto equals p.Id
                        where r.IdCarrello == idCarrello
                        select new { Id = p.Id, Nome = p.Nome };
            ViewBag.Elenco = query.ToList(); 
            return View();
        }
    }
}
