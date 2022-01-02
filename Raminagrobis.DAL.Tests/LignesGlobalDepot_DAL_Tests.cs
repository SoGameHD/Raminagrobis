using System;
using Xunit;

namespace Raminagrobis.DAL.Tests
{
    public class LignesGlobalDepot_DAL_Tests
    {
        #region LignesGlobalDepot_DAL_Test_Insert
        [Fact]
        public void LignesGlobalDepot_DAL_Test_Insert()
        {
            int id = 1;
            int id_panier = 1;
            int quantite = 10;
            int id_produit = 1;

            var ligneGlobal = new LignesGlobal_DAL(id, id_panier, quantite, id_produit);
            var repo = new LignesGlobalDepot_DAL();

            repo.Insert(ligneGlobal);

            Assert.NotNull(ligneGlobal);
            Assert.Equal(id, ligneGlobal.ID);
            Assert.Equal(id_panier, ligneGlobal.ID_panier);
            Assert.Equal(quantite, ligneGlobal.Quantite);
            Assert.Equal(id_produit, ligneGlobal.ID_produit);
        }
        #endregion

        #region LignesGlobalDepot_DAL_Test_GetAll
        [Fact]
        public void LignesGlobalDepot_DAL_Test_GetAll()
        {
            var repo = new LignesGlobalDepot_DAL();
            var ligneGlobal = repo.GetAll();

            Assert.NotNull(ligneGlobal);
        }
        #endregion

        #region LignesGlobalDepot_DAL_Test_GetByID
        [Fact]
        public void LignesGlobalDepot_DAL_Test_GetByID()
        {
            int id = 1;

            var repo = new LignesGlobalDepot_DAL();
            var ligneGlobal = repo.GetByID(id);

            Assert.NotNull(ligneGlobal);
            Assert.Equal(id, ligneGlobal.ID);
        }
        #endregion

        #region LignesGlobalDepot_DAL_Test_Update
        [Fact]
        public void LignesGlobalDepot_DAL_Test_Update()
        {
            int id = 1;
            int id_panier = 1;
            int quantite = 20;
            int id_produit = 1;

            var ligneGlobal = new LignesGlobal_DAL(id, id_panier, quantite, id_produit);
            var repo = new LignesGlobalDepot_DAL();

            repo.Update(ligneGlobal);

            Assert.NotNull(ligneGlobal);
            Assert.Equal(id, ligneGlobal.ID);
            Assert.Equal(id_panier, ligneGlobal.ID_panier);
            Assert.Equal(quantite, ligneGlobal.Quantite);
            Assert.Equal(id_produit, ligneGlobal.ID_produit);
        }
        #endregion

        #region LignesGlobalDepot_DAL_Test_Delete
        [Fact]
        public void LignesGlobalDepot_DAL_Test_Delete()
        {
            int id = 1;

            var repo = new LignesGlobalDepot_DAL();
            var ligneGobal = repo.GetByID(id);

            repo.Delete(ligneGobal);

            Assert.Throws<Exception>(() => repo.GetByID(ligneGobal.ID));
        }
        #endregion
    }
}
