using System;
using Xunit;

namespace Raminagrobis.DAL.Tests
{
    public class PropositionsDepot_DAL_Tests
    {
        #region PropositionsDepot_DAL_Test_Insert
        [Fact]
        public void PropositionsDepot_DAL_Test_Insert()
        {
            int id_ligne_global = 1;
            int id_fournisseur = 1;
            int prix = 10;

            var propositions = new Propositions_DAL(id_ligne_global, id_fournisseur, prix);
            var repo = new PropositionsDepot_DAL();

            repo.Insert(propositions);

            Assert.NotNull(propositions);
            Assert.Equal(id_ligne_global, propositions.ID_ligne_global);
            Assert.Equal(id_fournisseur, propositions.ID_fournisseur);
            Assert.Equal(prix, propositions.Prix);
        }
        #endregion

        #region PropositionsDepot_DAL_Test_GetAll
        [Fact]
        public void PropositionsDepot_DAL_Test_GetAll()
        {
            var repo = new PropositionsDepot_DAL();
            var propositions = repo.GetAll();

            Assert.NotNull(propositions);
        }
        #endregion

        #region PropositionsDepot_DAL_Test_GetByID_ligne_global
        [Fact]
        public void PropositionsDepot_DAL_Test_GetByID_ligne_global()
        {
            int id_ligne_global = 1;

            var repo = new PropositionsDepot_DAL();
            var propositions = repo.GetByID_ligne_global(id_ligne_global);

            Assert.NotNull(propositions);
            Assert.Equal(id_ligne_global, propositions.ID_ligne_global);
        }
        #endregion

        #region PropositionsDepot_DAL_Test_GetByID_fournisseur
        [Fact]
        public void PropositionsDepot_DAL_Test_GetByID_fournisseur()
        {
            int id_fournisseur = 1;

            var repo = new PropositionsDepot_DAL();
            var propositions = repo.GetByID_fournisseur(id_fournisseur);

            Assert.NotNull(propositions);
            Assert.Equal(id_fournisseur, propositions.ID_fournisseur);
        }
        #endregion

        #region PropositionsDepot_DAL_Test_Update
        [Fact]
        public void PropositionsDepot_DAL_Test_Update()
        {
            int id_ligne_global = 1;
            int id_fournisseur = 1;
            int prix = 20;

            var propositions = new Propositions_DAL(id_ligne_global, id_fournisseur, prix);
            var repo = new PropositionsDepot_DAL();

            repo.Update(propositions);

            Assert.NotNull(propositions);
            Assert.Equal(id_ligne_global, propositions.ID_ligne_global);
            Assert.Equal(id_fournisseur, propositions.ID_fournisseur);
            Assert.Equal(prix, propositions.Prix);
        }
        #endregion
    }
}
