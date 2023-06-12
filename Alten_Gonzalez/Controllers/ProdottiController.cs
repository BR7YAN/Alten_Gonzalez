using Alten_Gonzalez.Models;
using Microsoft.AspNetCore.Mvc;

namespace Alten_Gonzalez.Controllers
{
    public class ProdottiController : Controller
    {

        private readonly ECOMMERCEContext _context;
        public ProdottiController(ECOMMERCEContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NuovoProdotto()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NuovoProdotto(string Nome, string Prezzo)
        {
            var nuovoRecord = new Prodotti();
			nuovoRecord.Id = _context.Prodottis.Any() ? _context.Prodottis.Max(c => c.Id + 1) : 0;
			nuovoRecord.Nome = Nome;
            nuovoRecord.Prezzo = (float)Convert.ToDouble(Prezzo);
            _context.Prodottis.Add(nuovoRecord);
            _context.SaveChanges();
            return View();
        }
        public IActionResult ElencoProdotti()
        {
            return View(_context.Prodottis.ToList());
        }
    }
}
