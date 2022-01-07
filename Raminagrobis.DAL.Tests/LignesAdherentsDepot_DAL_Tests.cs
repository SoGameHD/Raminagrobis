using System;
using Xunit;

namespace Raminagrobis.DAL.Tests
{
    public class LignesAdherentsDepot_DAL_Tests
    {
        #region LignesAdherentsDepot_DAL_Test_Insert
        [Fact]
        public void LignesAdherentsDepot_DAL_Test_Insert()
        {
            int id_produit = 1;
            int id_commande = 1;
            int id_ligne_global = 1;
            int quantite = 10;

            var lignesAdherent = new LignesAdherents_DAL(id_produit, id_commande, id_ligne_global, quantite);
            var repo = new LignesAdherentsDepot_DAL();

            repo.Insert(lignesAdherent);

            Assert.NotNull(lignesAdherent);
            Assert.Equal(id_produit, lignesAdherent.ID_produit);
            Assert.Equal(id_commande, lignesAdherent.ID_commande);
            Assert.Equal(id_ligne_global, lignesAdherent.ID_ligne_global);
            Assert.Equal(quantite, lignesAdherent.Quantite);
        }
        #endregion

        #region LignesAdherentsDepot_DAL_Test_GetAll
        [Fact]
        public void LignesAdherentsDepot_DAL_Test_GetAll()
        {
            var repo = new LignesAdherentsDepot_DAL();
            var lignesAdherent = repo.GetAll();

            Assert.NotNull(lignesAdherent);
        }
        #endregion

        #region LignesAdherentsDepot_DAL_Test_GetByID_produit
        [Fact]
        public void LignesAdherentsDepot_DAL_Test_GetByID_produit()
        {
            int id_produit = 1;

            var repo = new LignesAdherentsDepot_DAL();
            var lignesAdherent = repo.GetByID_produit(id_produit);

            Assert.NotNull(lignesAdherent);
            Assert.Equal(id_produit, lignesAdherent.ID_produit);
        }
        #endregion

        #region LignesAdherentsDepot_DAL_Test_GetByID_commande
        [Fact]
        public void LignesAdherentsDepot_DAL_Test_GetByID_commande()
        {
            int id_commande = 1;

            var repo = new LignesAdherentsDepot_DAL();
            var lignesAdherent = repo.GetByID_commande(id_commande);

            Assert.NotNull(lignesAdherent);
            Assert.Equal(id_commande, lignesAdherent.ID_commande);
        }
        #endregion

        #region LiaisonAdherents_DAL_Test_Insert
        [Fact]
        public void LiaisonAdherents_DAL_Test_Insert()
        {
            int id_produit = 1;
            int id_commande = 1;
            int id_ligne_global = 1;
            int quantite = 10;

            var ligneAdherent = new LignesAdherents_DAL(id_produit, id_commande, id_ligne_global, quantite);
            var repo = new LignesAdherentsDepot_DAL();

            repo.Insert(ligneAdherent);

            Assert.NotNull(ligneAdherent);
            Assert.Equal(id_produit, ligneAdherent.ID_produit);
            Assert.Equal(id_commande, ligneAdherent.ID_commande);
            Assert.Equal(id_ligne_global, ligneAdherent.ID_ligne_global);
            Assert.Equal(quantite, ligneAdherent.Quantite);
        }
        #endregion

        #region LignesAdherentsDepot_DAL_Test_Update
        [Fact]
        public void LignesAdherentsDepot_DAL_Test_Update()
        {
            int id_produit = 1;
            int id_commande = 1;
            int id_ligne_global = 1;
            int quantite = 20;

            var lignesAdherent = new LignesAdherents_DAL(id_produit, id_commande, id_ligne_global, quantite);
            var repo = new LignesAdherentsDepot_DAL();

            repo.Update(lignesAdherent);

            Assert.NotNull(lignesAdherent);
            Assert.Equal(id_produit, lignesAdherent.ID_produit);
            Assert.Equal(id_commande, lignesAdherent.ID_commande);
            Assert.Equal(id_ligne_global, lignesAdherent.ID_ligne_global);
            Assert.Equal(quantite, lignesAdherent.Quantite);
        }
        #endregion
    }
}
