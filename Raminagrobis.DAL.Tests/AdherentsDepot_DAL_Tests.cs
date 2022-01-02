using System;
using Xunit;  

namespace Raminagrobis.DAL.Tests
{
    public class AdherentsDepot_DAL_Tests
    {
        #region AdherentsDepot_DAL_Test_Insert
        [Fact]
        public void AdherentsDepot_DAL_Test_Insert()
        {
            string societe = "Raminagrobis Company";
            bool civilite = false;
            string nom = "Brant";
            string prenom = "Jacques";
            string email = "email";
            DateTime date_adhesion = DateTime.Now;
            bool actif = false;

            var adherent = new Adherent_DAL(societe, civilite, nom, prenom, email, date_adhesion, actif);
            var repo = new AdherentDepot_DAL();

            repo.Insert(adherent);

            Assert.NotNull(adherent);
            Assert.Equal(societe, adherent.Societe);
            Assert.Equal(civilite, adherent.Civilite);
            Assert.Equal(nom, adherent.Nom);
            Assert.Equal(prenom, adherent.Prenom);
            Assert.Equal(email, adherent.Email);
            Assert.Equal(date_adhesion, adherent.Date_adhesion);
            Assert.Equal(actif, adherent.Actif);
        }
        #endregion

        #region AdherentsDepot_DAL_Test_GetAll
        [Fact]
        public void AdherentsDepot_DAL_Test_GetAll()
        {
            var repo = new AdherentDepot_DAL();
            var adherent = repo.GetAll();

            Assert.NotNull(adherent);
        }
        #endregion

        #region AdherentsDepot_DAL_Test_GetByID
        [Fact]
        public void AdherentsDepot_DAL_Test_GetByID()
        {
            int id = 1;

            var repo = new AdherentDepot_DAL();
            var adherent = repo.GetByID(id);

            Assert.NotNull(adherent);
            Assert.Equal(id, adherent.ID);
        }
        #endregion

        #region AdherentsDepot_DAL_Test_Update
        [Fact]
        public void AdherentsDepot_DAL_Test_Update()
        {
            int id = 1;
            string societe = "Update Company";
            bool civilite = true;
            string nom = "Test";
            string prenom = "Update";
            string email = "email2";
            DateTime date_adhesion = DateTime.Now;
            bool actif = true;

            var adherent = new Adherent_DAL(id, societe, civilite, nom, prenom, email, date_adhesion, actif);
            var repo = new AdherentDepot_DAL();

            repo.Update(adherent);

            Assert.NotNull(adherent);
            Assert.Equal(id, adherent.ID);
            Assert.Equal(societe, adherent.Societe);
            Assert.Equal(civilite, adherent.Civilite);
            Assert.Equal(nom, adherent.Nom);
            Assert.Equal(prenom, adherent.Prenom);
            Assert.Equal(email, adherent.Email);
            Assert.Equal(date_adhesion, adherent.Date_adhesion);
            Assert.Equal(actif, adherent.Actif);
        }
        #endregion

        #region AdherentsDepot_DAL_Test_Delete
        [Fact]
        public void AdherentsDepot_DAL_Test_Delete()
        {
            int id = 1;

            var repo = new AdherentDepot_DAL();
            var adherent = repo.GetByID(id);

            repo.Delete(adherent);

            Assert.Throws<Exception>(() => repo.GetByID(adherent.ID));
        }
        #endregion
    }
}
