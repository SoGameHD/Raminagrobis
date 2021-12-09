using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DAL;

namespace Raminagrobis.METIER
{
    public class Adherents_METIER
    {
        public string Societe { get; set; }
        public bool Civilite { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public DateTime Date_adhesion { get; set; }
        public Boolean Actif { get; set; }

        private int ID { get; set; }
        public Adherents_METIER(string societe, bool civilite, string nom, string prenom, string email, DateTime dateAdhesion, Boolean actif) => (Societe, Civilite, Nom, Prenom, Email, Date_adhesion, Actif) = (societe, civilite, nom, prenom, email, dateAdhesion, actif);
        public Adherents_METIER(int id, string societe, bool civilite, string nom, string prenom, string email, DateTime dateAdhesion, Boolean actif) => (ID, Societe, Civilite, Nom, Prenom, Email, Date_adhesion, Actif) = (id, societe, civilite, nom, prenom, email, dateAdhesion, actif);


        #region Insert
        public void Insert()
        {
            Adherent_DAL Adherent = new Adherent_DAL(Societe, Civilite, Nom, Prenom, Email, Date_adhesion, Actif);
            var depotAdherent = new AdherentDepot_DAL();
            Adherent = depotAdherent.Insert(Adherent);

            ID = Adherent.ID;
        }
        #endregion

        #region Delete
        public void Delete()
        {
            Adherent_DAL Adherent = new Adherent_DAL(ID, Societe, Civilite, Nom, Prenom, Email, Date_adhesion, Actif);
            var depotAdherent = new AdherentDepot_DAL();
            depotAdherent.Delete(Adherent);
        }
        #endregion

        #region Update
        public void Update()
        {
            Adherent_DAL Adherent = new Adherent_DAL(ID, Societe, Civilite, Nom, Prenom, Email, Date_adhesion, Actif);
            var depotAdherent = new AdherentDepot_DAL();
            depotAdherent.Update(Adherent);
        }
        #endregion
    }
}