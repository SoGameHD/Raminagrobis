using System;
using Xunit;

namespace Raminagrobis.DAL.Tests
{
    public class FournisseursDepot_DAL_Tests
    {
        #region FournisseursDepot_DAL_Test_Insert
        [Fact]
        public void FournisseursDepot_DAL_Test_Insert()
        {
            int id = 1;
            string societe = "Asus Company";
            bool civilite = true;
            string nom = "Brant";
            string prenom = "Jacques";
            string email = "asus@email.com";
            string adresse = "74 Avenue Asus Company";
            bool actif = true;

            var fournisseur = new Fournisseurs_DAL(id, societe, civilite, nom, prenom, email, adresse, actif);
            var repo = new FournisseursDepot_DAL();

            repo.Insert(fournisseur);

            Assert.NotNull(fournisseur);
            Assert.Equal(id, fournisseur.ID);
            Assert.Equal(societe, fournisseur.Societe);
            Assert.Equal(nom, fournisseur.Nom);
            Assert.Equal(prenom, fournisseur.Prenom);
            Assert.Equal(email, fournisseur.Email);
            Assert.Equal(adresse, fournisseur.Adresse);
            Assert.Equal(actif, fournisseur.Actif);
        }
        #endregion

        #region FournisseursDepot_DAL_Test_GetAll
        [Fact]
        public void FournisseursDepot_DAL_Test_GetAll()
        {
            var repo = new FournisseursDepot_DAL();
            var fournisseur = repo.GetAll();

            Assert.NotNull(fournisseur);
        }
        #endregion

        #region FournisseursDepot_DAL_Test_GetByID
        [Fact]
        public void FournisseursDepot_DAL_Test_GetByID()
        {
            int id = 1;

            var repo = new FournisseursDepot_DAL();
            var fournisseur = repo.GetByID(id);

            Assert.NotNull(fournisseur);
            Assert.Equal(id, fournisseur.ID);
        }
        #endregion

        #region FournisseursDepot_DAL_Test_Update
        [Fact]
        public void FournisseurDepot8DAL_Test_Update()
        {
            int id = 1;
            string societe = "Acer Company";
            bool civilite = false;
            string nom = "Test";
            string prenom = "Update";
            string email = "acer@email.com";
            string adresse = "18 Avenue Acer Company";
            bool actif = false;

            var fournisseur = new Fournisseurs_DAL(id, societe, civilite, nom, prenom, email, adresse, actif);
            var repo = new FournisseursDepot_DAL();

            repo.Update(fournisseur);

            Assert.NotNull(fournisseur);
            Assert.Equal(id, fournisseur.ID);
            Assert.Equal(societe, fournisseur.Societe);
            Assert.Equal(nom, fournisseur.Nom);
            Assert.Equal(prenom, fournisseur.Prenom);
            Assert.Equal(email, fournisseur.Email);
            Assert.Equal(adresse, fournisseur.Adresse);
            Assert.Equal(actif, fournisseur.Actif);
        }
        #endregion

        #region FournisseursDepot_DAL_Test_Delete
        [Fact]
        public void FournisseursDepot_DAL_Test_Delete()
        {
            int id = 1;

            var repo = new FournisseursDepot_DAL();
            var fournisseur = repo.GetByID(id);

            repo.Delete(fournisseur);

            Assert.Throws<Exception>(() => repo.GetByID(fournisseur.ID));
        }
        #endregion
    }
}
