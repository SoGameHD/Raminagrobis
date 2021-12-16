using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DAL;
using Raminagrobis.DTO;
using Raminagrobis.METIER;

namespace Raminagrobis.METIER.Services
{
    public class Produits_Services
    {
        #region GetAll
        public List<Produits_METIER> GetAll()
        {
            var result = new List<Produits_METIER>();
            var depot = new ProduitsDepot_DAL();
            foreach (var item in depot.GetAll())
            {
                result.Add(new Produits_METIER(item.ID, item.Reference, item.Libelle, item.Marque, item.Actif));
            }
            return result;
        }
        #endregion

        #region GetByID
        public Produits_METIER GetByID(int id)
        {
            var depot = new ProduitsDepot_DAL();
            var produits = depot.GetByID(id);
            return new Produits_METIER(produits.ID, produits.Reference, produits.Libelle, produits.Marque, produits.Actif);
        }
        #endregion

        #region Insert
        public void Insert(Produits_DTO input)
        {
            var produits = new Produits_DAL(input.Reference, input.Libelle, input.Marque, input.Actif);
            var depot = new ProduitsDepot_DAL();
            depot.Insert(produits);
        }
        #endregion

        #region Edit
        public void Edit(int id, Produits_DTO input)
        {
            var produits = new Produits_DAL(id, input.Reference, input.Libelle, input.Marque, input.Actif);
            var depot = new ProduitsDepot_DAL();
            depot.Update(produits);
        }
        #endregion

        #region Delete
        public void Delete(int id)
        {
            Fournisseurs_DAL produits;
            FournisseursDepot_DAL depot = new FournisseursDepot_DAL();
            produits = depot.GetByID(id);
            depot.Delete(produits);
        }
        #endregion
    }
}
