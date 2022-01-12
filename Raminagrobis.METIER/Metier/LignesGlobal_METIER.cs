using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DAL.DAL;

namespace Raminagrobis.METIER.Metier
{
    public class LignesGlobal_METIER
    {
        public int ID_panier { get; set; }
        public int Quantite { get; set; }
        public int ID_produit { get; set; }
        public int ID { get; set; }


        public LignesGlobal_METIER(int id_panier, int quantite, int id_produit) => (ID_panier, Quantite, ID_produit) = (id_panier, quantite, id_produit);

        #region Insert
        public void Insert()
        {
            LignesGlobal_DAL LignesGlobal = new LignesGlobal_DAL(ID_panier, Quantite, ID_produit);

            var depotLignesGlobal = new LignesGlobalDepot_DAL();

            LignesGlobal = depotLignesGlobal.Insert(LignesGlobal);

            ID = LignesGlobal.ID;
        }
        #endregion

        #region Delete
        public void Delete()
        {
            LignesGlobal_DAL LignesGlobal = new LignesGlobal_DAL(ID_panier, Quantite, ID_produit);

            var depotLignesGlobal = new LignesGlobalDepot_DAL();
            depotLignesGlobal.Delete(LignesGlobal);
        }
        #endregion

        #region Update
        public void Update()
        {
            LignesGlobal_DAL LignesGlobal = new LignesGlobal_DAL(ID_panier, Quantite, ID_produit);

            var depotLignesGlobal = new LignesGlobalDepot_DAL();
            depotLignesGlobal.Update(LignesGlobal);
        }
        #endregion
    }
}