namespace Alten_Gonzalez.Models
{
    public class Negozio
    {
            private static Negozio instance;
            private List<Prodotti> prodottiDisponibili;
            private Negozio()
            {
                prodottiDisponibili = new List<Prodotti>();
        }
        public static Negozio GetInstance()
        {
            if (instance == null)
            {
                instance = new Negozio();
            }
            return instance;
        }

        /*public void AggiungiProdotto(Prodotti prodotto)
        {
            prodottiDisponibili.Add(prodotto);
        }

        public void RimuoviProdotto(Prodotti prodotto)
        {
            prodottiDisponibili.Remove(prodotto);
        }

        public List<Prodotti> GetProdottiDisponibili()
        {
            return prodottiDisponibili;
        }*/
    }
}
