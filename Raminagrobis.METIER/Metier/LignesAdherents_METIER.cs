using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DAL.DAL;
using Raminagrobis.DAL.Depot;

namespace Raminagrobis.METIER.Metier
{
    public class LignesAdherents_METIER
    {
        public int ID_ligne_global { get; set; }
        public int Quantite { get; set; }
        public int ID_produit { get; set; }
        public int ID_commande { get; set; }

        public LignesAdherents_METIER(int id_ligne_global, int quantite) => (ID_ligne_global, Quantite) = (id_ligne_global, quantite);

        public LignesAdherents_METIER(int id_produit, int id_commande, int id_ligne_global, int quantite) => (ID_produit, ID_commande, ID_ligne_global, Quantite) = (id_produit, id_commande, id_ligne_global, quantite);

        #region Insert
        public void Insert()
        {

            LignesAdherents_DAL lignesAdherents = new LignesAdherents_DAL(ID_ligne_global, Quantite);

            var depotAdherents = new LignesAdherentsDepot_DAL();

            lignesAdherents = depotAdherents.Insert(lignesAdherents);

            ID_produit = lignesAdherents.ID_produit;
            ID_commande = lignesAdherents.ID_commande;
        }
        #endregion

        #region Delete
        public void Delete()
        {
            LignesAdherents_DAL lignesAdherents = new LignesAdherents_DAL(ID_ligne_global, Quantite);

            var depotAdherents = new LignesAdherentsDepot_DAL();

            depotAdherents.Delete(lignesAdherents);
        }
        #endregion

        #region Update
        public void Update()
        {
            LignesAdherents_DAL lignesAdherents = new LignesAdherents_DAL(ID_ligne_global, Quantite);

            var depotAdherents = new LignesAdherentsDepot_DAL();

            depotAdherents.Update(lignesAdherents);
        }
        #endregion
    }
}