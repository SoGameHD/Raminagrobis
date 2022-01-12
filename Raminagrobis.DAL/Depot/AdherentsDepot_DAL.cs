using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Raminagrobis.DAL.DAL;

namespace Raminagrobis.DAL.Depot
{
    public class AdherentDepot_DAL : Depot_DAL<Adherent_DAL>
    {
        #region GetAll
        public override List<Adherent_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT societe, civilite, nom, prenom, email, date_adhesion, actif FROM Adherents";
            var reader = commande.ExecuteReader();

            var listeAdherents = new List<Adherent_DAL>();

            while (reader.Read())
            {
                var adherent = new Adherent_DAL(reader.GetString(0),
                                        reader.GetBoolean(1),
                                        reader.GetString(2),
                                        reader.GetString(3),
                                        reader.GetString(4),
                                        reader.GetDateTime(5),
                                        reader.GetBoolean(6)
                                        );

                listeAdherents.Add(adherent);
            }

            DetruireConnexionEtCommande();

            return listeAdherents;
        }
        #endregion

        #region GetByID
        public override Adherent_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT ID, societe, civilite, nom, prenom, email, date_adhesion, actif FROM Adherents WHERE ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            Adherent_DAL adherent;
            if (reader.Read())
            {
                adherent = new Adherent_DAL(reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetBoolean(2),
                                        reader.GetString(3),
                                        reader.GetString(4),
                                        reader.GetString(5),
                                        reader.GetDateTime(6),
                                        reader.GetBoolean(7)
                                        );
            }
            else
            {
                throw new Exception($"Aucune occurance de l'ID {ID} dans la table Adherents");
            }

            DetruireConnexionEtCommande();

            return adherent;
        }
        #endregion

        #region Insert
        public override Adherent_DAL Insert(Adherent_DAL adherent)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "INSERT INTO Adherents(societe, civilite, nom, prenom, email, date_adhesion, actif) VALUES (@Societe, @Civilite, @Nom, @Prenom, @Email, @Date_adhesion, @Actif); SELECT SCOPE_IDENTITY()";
            commande.Parameters.Add(new SqlParameter("@Societe", adherent.Societe));
            commande.Parameters.Add(new SqlParameter("@Civilite", adherent.Civilite));
            commande.Parameters.Add(new SqlParameter("@Nom", adherent.Nom));
            commande.Parameters.Add(new SqlParameter("@Prenom", adherent.Prenom));
            commande.Parameters.Add(new SqlParameter("@Email", adherent.Email));
            commande.Parameters.Add(new SqlParameter("@Date_adhesion", adherent.Date_adhesion));
            commande.Parameters.Add(new SqlParameter("@Actif", adherent.Actif));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            adherent.ID = ID;

            DetruireConnexionEtCommande();

            return adherent;
        }
        #endregion

        #region Update
        public override Adherent_DAL Update(Adherent_DAL adherent)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "UPDATE Adherents SET societe=@Societe, civilite=@Civilite, nom=@Nom, prenom=@Prenom, email=@Email, date_adhesion=@Date_adhesion, actif=@Actif WHERE ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", adherent.ID));
            commande.Parameters.Add(new SqlParameter("@Societe", adherent.Societe));
            commande.Parameters.Add(new SqlParameter("@Civilite", adherent.Civilite));
            commande.Parameters.Add(new SqlParameter("@Nom", adherent.Nom));
            commande.Parameters.Add(new SqlParameter("@Prenom", adherent.Prenom));
            commande.Parameters.Add(new SqlParameter("@Email", adherent.Email));
            commande.Parameters.Add(new SqlParameter("@Date_adhesion", adherent.Date_adhesion));
            commande.Parameters.Add(new SqlParameter("@Actif", adherent.Actif));

            var nombreDeLignesAffectees = commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour l'Adherents d'ID : {adherent.ID}");
            }

            DetruireConnexionEtCommande();

            return adherent;
        }
        #endregion

        #region Delete
        public override void Delete(Adherent_DAL adherent)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "DELETE FROM Adherents WHERE ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", adherent.ID));
            var nombreDeLignesAffectees = commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de supprimer l'Adhérents d'ID {adherent.ID}");
            }

            DetruireConnexionEtCommande();
        }
        #endregion

    }
}