using System;
using Xunit;

namespace Raminagrobis.DAL.Tests
{
    public class ProduitsDepot_DAL_Tests
    {
        #region ProduitsDepot_DAL_Test_Insert
        [Fact]
        public void ProduitsDepot_DAL_Test_Insert()
        {
            int id = 1;
            string reference = "BC14520";
            string libelle = "DELL G5 15";
            string marque = "DELL";
            bool actif = true;

            var produit = new Produits_DAL(id, reference, libelle, marque, actif);
            var repo = new ProduitsDepot_DAL();

            repo.Insert(produit);

            Assert.NotNull(produit);
            Assert.Equal(id, produit.ID);
            Assert.Equal(reference, produit.Reference);
            Assert.Equal(libelle, produit.Libelle);
            Assert.Equal(marque, produit.Marque);
            Assert.Equal(actif, produit.Actif);
        }
        #endregion

        #region ProduitsDepot_DAL_Test_GetAll
        [Fact]
        public void ProduitsDepot_DAL_Test_GetAll()
        {
            var repo = new ProduitsDepot_DAL();
            var produit = repo.GetAll();

            Assert.NotNull(produit);
        }
        #endregion

        #region ProduitsDepot_DAL_Test_GetByID
        [Fact]
        public void ProduitsDepot_DAL_Test_GetByID()
        {
            int id = 1;

            var repo = new ProduitsDepot_DAL();
            var panier = repo.GetByID(id);

            Assert.NotNull(panier);
            Assert.Equal(id, panier.ID);
        }
        #endregion

        #region ProduitsDepot_DAL_Test_Update
        [Fact]
        public void ProduitsDepot_DAL_Test_Update()
        {
            int id = 1;
            string reference = "BC14520";
            string libelle = "ACER A3 15";
            string marque = "ACER";
            bool actif = false;

            var produit = new Produits_DAL(id, reference, libelle, marque, actif);
            var repo = new ProduitsDepot_DAL();

            repo.Update(produit);

            Assert.NotNull(produit);
            Assert.Equal(id, produit.ID);
            Assert.Equal(reference, produit.Reference);
            Assert.Equal(libelle, produit.Libelle);
            Assert.Equal(marque, produit.Marque);
            Assert.Equal(actif, produit.Actif);
        }
        #endregion

        #region ProduitsDepot_DAL_Test_Delete
        [Fact]
        public void ProduitsDepot_DAL_Test_Delete()
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
