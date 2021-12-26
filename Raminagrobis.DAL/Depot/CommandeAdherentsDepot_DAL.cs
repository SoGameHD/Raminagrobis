using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class CommandeAdherentsDepot_DAL : Depot_DAL<CommandeAdherents_DAL>
    {
        #region GetAll
        public override List<CommandeAdherents_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT id_adherent, id_panier FROM Commandes";
            var reader = commande.ExecuteReader();

            var listeCommande = new List<CommandeAdherents_DAL>();

            while (reader.Read())
            {
                var commande = new CommandeAdherents_DAL(reader.GetInt16(0),
                                            reader.GetInt16(1)
                                            );

                listeCommande.Add(commande);
            }

            DetruireConnexionEtCommande();

            return listeCommande;
        }
        #endregion

        #region GetByID
        public override CommandeAdherents_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT ID, id_adherent, id_panier FROM Commandes WHERE ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            CommandeAdherents_DAL listeCommande;

            if (reader.Read())
            {
                listeCommande = new CommandeAdherents_DAL(reader.GetInt32(0),
                                            reader.GetInt32(1),
                                            reader.GetInt32(2)
                                            );
            }
            else
            {
                throw new Exception($"Aucune occurance à l'ID {ID} dans la table Commandes");
            }


            DetruireConnexionEtCommande();

            return listeCommande;
        }
        #endregion

        #region Insert
        public override CommandeAdherents_DAL Insert(CommandeAdherents_DAL commandes)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "INSERT INTO Commandes (id_adherent, id_panier) VALUES (@ID_adherent, @ID_panier); SELECT SCOPE_IDENTITY()";
            commande.Parameters.Add(new SqlParameter("@ID_adherent", commandes.ID_adherent));
            commande.Parameters.Add(new SqlParameter("@ID_panier", commandes.ID_panier));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            commandes.ID = ID;

            DetruireConnexionEtCommande();

            return commandes;
        }
        #endregion

        #region Update
        public override CommandeAdherents_DAL Update(CommandeAdherents_DAL commandes)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "UPDATE Commandes SET id_adherent = @ID_adherent, id_panier = @ID_panier WHERE ID = @ID";
            commande.Parameters.Add(new SqlParameter("@ID", commandes.ID));
            commande.Parameters.Add(new SqlParameter("@ID_adherent", commandes.ID_adherent));
            commande.Parameters.Add(new SqlParameter("@ID_panier", commandes.ID_panier));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour la CommandeAdherents d'ID : {commandes.ID}");
            }

            DetruireConnexionEtCommande();

            return commandes;
        }
        #endregion

        #region Delete
        public override void Delete(CommandeAdherents_DAL commandes)
        {
            CreerConnexionEtCommande();
            commande.CommandText = "DELETE FROM Commandes WHERE ID = @ID";
            commande.Parameters.Add(new SqlParameter("@ID", commandes.ID));

            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees < 0)
            {
                throw new Exception($"Impossible de supprimer la CommandeAdherents d'ID {commandes.ID}");
            }
            DetruireConnexionEtCommande();
        }
        #endregion
    }
}