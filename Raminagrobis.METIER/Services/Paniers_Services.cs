using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DAL;
using Raminagrobis.METIER;
using Raminagrobis.DTO;

namespace Raminagrobis.METIER.Services
{
    public class Paniers_Services
    {
        #region GetAll
        public static List<Paniers_METIER> GetAll()
        {
            var result = new List<Paniers_METIER>();
            var depot = new PaniersDepot_DAL();
            foreach (var item in depot.GetAll())
            {
                result.Add(new Paniers_METIER(item.ID, item.Libelle));
            }
            return result;
        }
        #endregion

        #region GetByID
        public static Fournisseurs_METIER GetByID(int id)
        {
            var depot = new FournisseursDepot_DAL();
            var adherent = depot.GetByID(id);
            return new Fournisseurs_METIER(adherent.ID, adherent.Societe, adherent.Civilite, adherent.Nom, adherent.Prenom, adherent.Email, adherent.Adresse, adherent.Actif);
        }
        #endregion

        #region Insert
        public static void Insert(Paniers_DTO input)
        {
            var paniers = new Paniers_DAL(input.Libelle);
            var depot = new PaniersDepot_DAL();
            depot.Insert(paniers);
        }
        #endregion

        #region Edit
        public static void Edit(int id, Paniers_DTO input)
        {
            var paniers = new Paniers_DAL(id, input.Libelle);
            var depot = new PaniersDepot_DAL();
            depot.Update(paniers);
        }
        #endregion

        #region Delete
        public static void Delete(int id)
        {
            Paniers_DAL paniers;
            PaniersDepot_DAL depot = new PaniersDepot_DAL();
            paniers = depot.GetByID(id);
            depot.Delete(paniers);
        }
        #endregion
    }
}
