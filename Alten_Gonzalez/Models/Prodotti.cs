using System;
using System.Collections.Generic;

namespace Alten_Gonzalez.Models
{
    public partial class Prodotti
    {
        public Prodotti()
        {
            ProdottiCarrellos = new HashSet<ProdottiCarrello>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public double Prezzo { get; set; }

        public virtual ICollection<ProdottiCarrello> ProdottiCarrellos { get; set; }
    }
}