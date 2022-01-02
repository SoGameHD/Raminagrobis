using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class PropositionsDepot_DAL : Depot_DAL<Propositions_DAL>
    {
        #region GetAll
        public override List<Propositions_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT prix FROM Propositions";
            var reader = commande.ExecuteReader();

            var listePropositions = new List<Propositions_DAL>();

            while (reader.Read())
            {
                var commande = new Propositions_DAL(reader.GetInt16(0));

                listePropositions.Add(commande);
            }

            DetruireConnexionEtCommande();

            return listePropositions;
        }
        #endregion

        #region GetByID
        public override Propositions_DAL GetByID(int ID)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region GetByID_ligne_global
        public Propositions_DAL GetByID_ligne_global(int ID_ligne_global)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT ID_ligne_global, ID_fournisseur, prix FROM Propositions WHERE ID_ligne_global=@ID_ligne_global";
            commande.Parameters.Add(new SqlParameter("@ID_ligne_global", ID_ligne_global));
            var reader = commande.ExecuteReader();

            Propositions_DAL listePropositions;

            if (reader.Read())
            {
                listePropositions = new Propositions_DAL(reader.GetInt16(0),
                                            reader.GetInt16(1),
                                            reader.GetInt16(2)
                                            );
            }
            else
            {
                throw new Exception($"Aucune occurance à l'ID {ID_ligne_global} dans la table Propositions");
            }


            DetruireConnexionEtCommande();

            return listePropositions;
        }
        #endregion

        #region GetByID_fournisseur
        public Propositions_DAL GetByID_fournisseur(int ID_fournisseur)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT ID_ligne_global, id_fournisseur, prix FROM Propositions WHERE ID_fournisseur=@ID_fournisseur";
            commande.Parameters.Add(new SqlParameter("@ID_fournisseur", ID_fournisseur));
            var reader = commande.ExecuteReader();

            Propositions_DAL listePropositions;

            if (reader.Read())
            {
                listePropositions = new Propositions_DAL(reader.GetInt16(0),
                                            reader.GetInt16(1),
                                            reader.GetInt16(2)
                                            );
            }
            else
            {
                throw new Exception($"Aucune occurance à l'ID {ID_fournisseur} dans la table Propositions");
            }


            DetruireConnexionEtCommande();

            return listePropositions;
        }
        #endregion

        #region Insert
        public override Propositions_DAL Insert(Propositions_DAL propositions)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "INSERT INTO Propositions (prix) VALUES (@prix); SELECT SCOPE_IDENTITY()";
            commande.Parameters.Add(new SqlParameter("@Prix", propositions.Prix));

            DetruireConnexionEtCommande();

            return propositions;
        }
        #endregion

        #region Update
        public override Propositions_DAL Update(Propositions_DAL propositions)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "UPDATE Propositions SET prix = @Prix WHERE ID_ligne_global = @ID_ligne_global AND ID_fournisseur = @ID_fournisseur";
            commande.Parameters.Add(new SqlParameter("@Prix", propositions.Prix));
            commande.Parameters.Add(new SqlParameter("@ID_ligne_global", propositions.ID_ligne_global));
            commande.Parameters.Add(new SqlParameter("@ID_fournisseur", propositions.ID_fournisseur));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour le propositions d'ID_ligne_global {propositions.ID_ligne_global} & d'ID_fournisseur {propositions.ID_fournisseur}");
            }

            DetruireConnexionEtCommande();

            return propositions;
        }
        #endregion

        #region Delete
        public override void Delete(Propositions_DAL propositions)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}