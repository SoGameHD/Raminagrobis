using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class FournisseursDepot_DAL : Depot_DAL<Fournisseurs_DAL>
    {
        #region GetAll
        public override List<Fournisseurs_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT societe, civilite, nom, prenom, email, adresse, actif FROM Fournisseurs";
            var reader = commande.ExecuteReader();

            var listeFournisseurs = new List<Fournisseurs_DAL>();

            while (reader.Read())
            {
                var fournisseur = new Fournisseurs_DAL(reader.GetString(0),
                                        reader.GetBoolean(1),
                                        reader.GetString(2),
                                        reader.GetString(3),
                                        reader.GetString(4),
                                        reader.GetString(5),
                                        reader.GetBoolean(6));

                listeFournisseurs.Add(fournisseur);
            }

            DetruireConnexionEtCommande();

            return listeFournisseurs;
        }
        #endregion

        #region GetByID
        public override Fournisseurs_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT ID, societe, civilite, nom, prenom, email, adresse, actif FROM Fournisseurs where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            Fournisseurs_DAL fournisseur;
            if (reader.Read())
            {
                fournisseur = new Fournisseurs_DAL(reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetBoolean(2),
                                        reader.GetString(3),
                                        reader.GetString(4),
                                        reader.GetString(5),
                                        reader.GetString(6),
                                        reader.GetBoolean(7));
            }
            else
            {
                throw new Exception($"Aucune occurance à l'ID {ID} dans la table Fournisseurs");
            }


            DetruireConnexionEtCommande();

            return fournisseur;
        }
        #endregion

        #region Insert
        public override Fournisseurs_DAL Insert(Fournisseurs_DAL fournisseur)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "INSERT INTO Fournisseurs(societe, civilite, nom, prenom, email, adresse, actif) VALUES (@Societe, @Civilite, @Nom, @Prenom, @Email, @Adresse, @Actif); SELECT SCOPE_IDENTITY()";
            commande.Parameters.Add(new SqlParameter("@ID", fournisseur.ID));
            commande.Parameters.Add(new SqlParameter("@Societe", fournisseur.Societe));
            commande.Parameters.Add(new SqlParameter("@Civilite", fournisseur.Civilite));
            commande.Parameters.Add(new SqlParameter("@Nom", fournisseur.Nom));
            commande.Parameters.Add(new SqlParameter("@Prenom", fournisseur.Prenom));
            commande.Parameters.Add(new SqlParameter("@Email", fournisseur.Email));
            commande.Parameters.Add(new SqlParameter("@Adresse", fournisseur.Adresse));
            commande.Parameters.Add(new SqlParameter("@Actif", fournisseur.Actif));
            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            fournisseur.ID = ID;

            DetruireConnexionEtCommande();

            return fournisseur;
        }
        #endregion

        #region Update
        public override Fournisseurs_DAL Update(Fournisseurs_DAL fournisseur)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "UPDATE Fournisseurs SET societe = @Societe, civilite = @Civilite, nom = @Nom, prenom = @Prenom, email = @Email, adresse = @Adresse, actif = @Actif WHERE ID = @ID";
            commande.Parameters.Add(new SqlParameter("@Societe", fournisseur.Societe));
            commande.Parameters.Add(new SqlParameter("@Civilite", fournisseur.Civilite));
            commande.Parameters.Add(new SqlParameter("@Nom", fournisseur.Nom));
            commande.Parameters.Add(new SqlParameter("@Prenom", fournisseur.Prenom));
            commande.Parameters.Add(new SqlParameter("@Email", fournisseur.Email));
            commande.Parameters.Add(new SqlParameter("@Adresse", fournisseur.Adresse));
            commande.Parameters.Add(new SqlParameter("@Actif", fournisseur.Actif));
            commande.Parameters.Add(new SqlParameter("@ID", fournisseur.ID));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour le Fournisseurs d'ID : {fournisseur.ID}");
            }


            DetruireConnexionEtCommande();

            return fournisseur;
        }
        #endregion

        #region Delete
        public override void Delete(Fournisseurs_DAL fournisseur)
        {
            CreerConnexionEtCommande();
            commande.CommandText = "DELETE FROM Fournisseurs WHERE ID = @ID";
            commande.Parameters.Add(new SqlParameter("@ID", fournisseur.ID));

            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees < 0)
            {
                throw new Exception($"Impossible de supprimer le fournisseur d'ID {fournisseur.ID}");
            }
            DetruireConnexionEtCommande();
        }
        #endregion

    }
}
