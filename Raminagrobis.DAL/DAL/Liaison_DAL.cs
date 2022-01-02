using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class Liaison_DAL
    {
        public int ID_produit { get; set; }
        public int ID_fournisseur { get; set; }

        public Liaison_DAL(int id_produit, int id_fournisseur) => (ID_produit, ID_fournisseur) = (id_produit, id_fournisseur);
    }
}