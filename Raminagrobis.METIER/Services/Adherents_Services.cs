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
    public class Adherents_Services
    {
        #region GetAll
        public static List<Adherents_METIER> GetAll()
        {
            var result = new List<Adherents_METIER>();
            var depot = new AdherentDepot_DAL();
            foreach (var item in depot.GetAll())
            {
                result.Add(new Adherents_METIER(item.ID, item.Societe, item.Civilite, item.Nom, item.Prenom, item.Email, item.Date_adhesion, item.Actif));
            }
            return result;
        }
        #endregion

        #region GetByID
        public static Adherents_METIER GetByID(int id)
        {
            var depot = new AdherentDepot_DAL();
            var adherent = depot.GetByID(id);
            return new Adherents_METIER(adherent.ID, adherent.Societe, adherent.Civilite, adherent.Nom, adherent.Prenom, adherent.Email, adherent.Date_adhesion, adherent.Actif);
        }
        #endregion

        #region Insert
        public static void Insert(Adherent_DTO input)
        {
            var adherent = new Adherent_DAL(input.Societe, input.Civilite, input.Nom, input.Prenom, input.Email, input.Date_adhesion, input.Actif);
            var depot = new AdherentDepot_DAL();
            depot.Insert(adherent);
        }
        #endregion

        #region Edit
        public static void Edit(int id, Adherent_DTO input)
        {
            var adherent = new Adherent_DAL(id, input.Societe, input.Civilite, input.Nom, input.Prenom, input.Email, input.Date_adhesion, input.Actif);
            var depot = new AdherentDepot_DAL();
            depot.Update(adherent);
        }
        #endregion

        #region Delete
        public static void Delete(int id)
        {
            Adherent_DAL adherent;
            AdherentDepot_DAL depot = new AdherentDepot_DAL();
            adherent = depot.GetByID(id);
            depot.Delete(adherent);
        }
        #endregion
    }
}
