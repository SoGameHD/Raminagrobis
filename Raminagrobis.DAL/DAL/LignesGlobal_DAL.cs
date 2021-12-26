using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class LignesGlobal_DAL
    {
        public int ID_panier { get; set;  }
        public int Quantite { get; set; }
        public int ID_produit { get; set; }
        public int ID { get; set; }

        public LignesGlobal_DAL(int id_panier, int quantite, int id_produit) => (ID_panier, Quantite, ID_produit) = (id_panier, quantite, id_produit);

        public LignesGlobal_DAL(int id, int id_panier, int quantite, int id_produit) => (ID, ID_panier, Quantite, ID_produit) = (id, id_panier, quantite, id_produit);
    }
}
