using System;
using Raminagrobis.DAL;

namespace Raminagrobis.METIER
{
    public class Fournisseurs_METIER
    {
        public string Societe { get; set; }
        public bool Civilite { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Adresse { get; set; }
        public bool Actif { get; set; }

        private int ID { get; set; }

        public Fournisseurs_METIER(string societe, bool civilite, string nom, string prenom, string email, string adresse, bool actif) => (Societe, Civilite, Nom, Prenom, Email, Adresse, Actif) = (societe, civilite, nom, prenom, email, adresse, actif);

        #region Insert
        public void Insert()
        {
            Fournisseurs_DAL fournisseur = new Fournisseurs_DAL(Societe, Civilite, Nom, Prenom, Email, Adresse, Actif);

            var depotfournisseur = new FournisseursDepot_DAL();

            fournisseur = depotfournisseur.Insert(fournisseur);

            ID = fournisseur.ID;
        }
        #endregion

        #region Delete
        public void Delete()
        {
            Fournisseurs_DAL fournisseur = new Fournisseurs_DAL(ID, Societe, Civilite, Nom, Prenom, Email, Adresse, Actif);
            var depotfournisseur = new FournisseursDepot_DAL();
            depotfournisseur.Delete(fournisseur);
        }
        #endregion

        #region Update
        public void Update()
        {
            Fournisseurs_DAL fournisseur = new Fournisseurs_DAL(ID, Societe, Civilite, Nom, Prenom, Email, Adresse, Actif);
            var depotfournisseur = new FournisseursDepot_DAL();
            depotfournisseur.Update(fournisseur);
        }
        #endregion
    }
}