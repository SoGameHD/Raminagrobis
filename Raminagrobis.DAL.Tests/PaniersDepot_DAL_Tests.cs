using System;
using Xunit;

namespace Raminagrobis.DAL.Tests
{
    public class PaniersDepot_DAL_Tests
    {
        #region PaniersDepot_DAL_Test_Insert
        [Fact]
        public void PaniersDepot_DAL_Test_Insert()
        {
            int id = 1;
            string libelle = "Adherents N°1";

            var panier = new Paniers_DAL(id, libelle);
            var repo = new PaniersDepot_DAL();

            repo.Insert(panier);

            Assert.NotNull(panier);
            Assert.Equal(id, panier.ID);
            Assert.Equal(libelle, panier.Libelle);
        }
        #endregion

        #region PaniersDepot_DAL_Test_GetAll
        [Fact]
        public void PaniersDepot_DAL_Test_GetAll()
        {
            var repo = new PaniersDepot_DAL();
            var panier = repo.GetAll();

            Assert.NotNull(panier);
        }
        #endregion

        #region PaniersDepot_DAL_Test_GetByID
        [Fact]
        public void PaniersDepot_DAL_Test_GetByID_()
        {
            int id = 1;

            var repo = new PaniersDepot_DAL();
            var panier = repo.GetByID(id);

            Assert.NotNull(panier);
            Assert.Equal(id, panier.ID);
        }
        #endregion

        #region PaniersDepot_DAL_Test_Update
        [Fact]
        public void PaniersDepot_DAL_Test_Update()
        {
            int id = 1;
            string libelle = "Adherent N°2";

            var panier = new Paniers_DAL(id, libelle);
            var repo = new PaniersDepot_DAL();

            repo.Update(panier);

            Assert.NotNull(panier);
            Assert.Equal(id, panier.ID);
            Assert.Equal(libelle, panier.Libelle);
        }
        #endregion

        #region PaniersDepot_DAL_Test_Delete
        [Fact]
        public void PaniersDepot_DAL_Test_Delete()
        {
            int id = 1;

            var repo = new PaniersDepot_DAL();
            var panier = repo.GetByID(id);

            repo.Delete(panier);

            Assert.Throws<Exception>(() => repo.GetByID(panier.ID));
        }
        #endregion

    }
}
