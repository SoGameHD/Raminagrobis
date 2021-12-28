using System;
using Xunit;

namespace Raminagrobis.DAL.Tests
{
    public class LiaisonDepot_DAL_Tests
    {
        #region LiaisonDepot_DAL_Test_Insert
        [Fact]
        public void LiaisonDepot_DAL_Test_Insert()
        {
            int id_fournisseur = 1;
            int id_produit = 1;

            var liaison = new Liaison_DAL(id_fournisseur, id_produit);
            var repo = new LiaisonDepot_DAL();

            repo.Insert(liaison);

            Assert.NotNull(liaison);
            Assert.Equal(id_fournisseur, liaison.ID_fournisseur);
            Assert.Equal(id_produit, liaison.ID_produit);
        }
        #endregion
    }
}
