using System;
using Xunit;

namespace Raminagrobis.DAL.Tests
{
    public class CommandeAdherentsDepot_DAL_Tests
    {
        #region CommandeAdherentsDepot_DAL_Test_Insert
        [Fact]
        public void CommandeAdherentsDepot_DAL_Test_Insert()
        {
            int id = 1;
            int id_adherent = 1;
            int id_panier = 1;

            var commande = new CommandeAdherents_DAL(id, id_adherent, id_panier);
            var repo = new CommandeAdherentsDepot_DAL();

            repo.Insert(commande);

            Assert.NotNull(commande);
            Assert.Equal(id, commande.ID);
            Assert.Equal(id_adherent, commande.ID_adherent);
            Assert.Equal(id_panier, commande.ID_panier);
        }
        #endregion

        #region CommandeAdherentsDepot_DAL_Test_GetAll
        [Fact]
        public void CommandeAdherentsDepot_DAL_Test_GetAll()
        {
            var repo = new CommandeAdherentsDepot_DAL();
            var commande = repo.GetAll();

            Assert.NotNull(commande);
        }
        #endregion

        #region CommandeAdherentsDepot_DAL_Test_GetByID
        [Fact]
        public void CommandeAdherentsDepot_DAL_Test_GetByID_()
        {
            int id = 1;

            var repo = new CommandeAdherentsDepot_DAL();
            var commande = repo.GetByID(id);

            Assert.NotNull(commande);
            Assert.Equal(id, commande.ID);
        }
        #endregion

        #region CommandeAdherentsDepot_DAL_Test_Update
        [Fact]
        public void CommandeAdherentsDepot_DAL_Test_Update()
        {
            int id = 1;
            int id_adherent = 1;
            int id_panier = 1;

            var commande = new CommandeAdherents_DAL(id, id_adherent, id_panier);
            var repo = new CommandeAdherentsDepot_DAL();

            repo.Update(commande);

            Assert.NotNull(commande);
            Assert.Equal(id, commande.ID);
            Assert.Equal(id_adherent, commande.ID_adherent);
            Assert.Equal(id_panier, commande.ID_panier);
        }
        #endregion

        #region CommandeAdherentsDepot_DAL_Tests_Delete
        [Fact]
        public void CommandeAdherentsDepot_DAL_Tests_Delete()
        {
            int id = 1;

            var repo = new CommandeAdherentsDepot_DAL();
            var commande = repo.GetByID(id);

            repo.Delete(commande);

            Assert.Throws<Exception>(() => repo.GetByID(commande.ID));
        }
        #endregion
    }
}
