using Alten_Gonzalez.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alten_Gonzalez.Controllers
{
    public class UtentiController : Controller
    {
		private readonly ECOMMERCEContext _context;
		public UtentiController(ECOMMERCEContext context)
		{
			_context = context;
		}
		public IActionResult Index()
        {
            return View();
        }
        public IActionResult NuovoUtente()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NuovoUtente(string Nome)
        {
			var nuovoRecord = new Utenti();
			nuovoRecord.Id = _context.Utentis.Any() ? _context.Utentis.Max(c => c.Id + 1) : 0;
			nuovoRecord.Nome = Nome;
            var carrelloAssociato = new Carrelli();
			carrelloAssociato.Id = _context.Carrellis.Any() ? _context.Carrellis.DefaultIfEmpty().Max(c => c.Id + 1) : 0;
            carrelloAssociato.IdUtente = nuovoRecord.Id;
			_context.Utentis.Add(nuovoRecord);
            _context.Carrellis.Add(carrelloAssociato);
			_context.SaveChanges();
            return RedirectToAction("ElencoUtenti");
		}
        public IActionResult ElencoUtenti()
        {
            return View(_context.Utentis.ToList());
        }
    }
}
