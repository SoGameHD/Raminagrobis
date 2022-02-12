using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DAL.DAL;
using Raminagrobis.DAL.Depot;

namespace Raminagrobis.METIER.Metier
{
    public class Liaison_METIER
    {
        public int ID_produit { get; set; }
        public int ID_fournisseur { get; set; }

        public Liaison_METIER(int id_produit, int id_fournisseur) => (ID_produit, ID_fournisseur) = (id_produit, id_fournisseur);

        #region Insert
        public void Insert()
        {
            Liaison_DAL Liaison = new Liaison_DAL(ID_produit, ID_fournisseur);

            var depotLiaison = new LiaisonDepot_DAL();

            depotLiaison.Insert(Liaison);
        }
        #endregion

    }
}
