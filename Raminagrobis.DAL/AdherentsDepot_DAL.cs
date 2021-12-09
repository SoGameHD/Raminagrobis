using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class AdherentDepot_DAL : Depot_DAL<Adherent_DAL>
    {
        #region GetAll
        public override List<Adherent_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select societe, civilite, nom, prenom, email, date_adhesion, actif from Adherents";
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

            commande.CommandText = "select ID, societe, civilite, nom, prenom, email, date_adhesion, actif from Adherents where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            Adherent_DAL adherent;
            if (reader.Read())
            {
                adherent = new Adherent_DAL(reader.GetString(0),
                                        reader.GetBoolean(1),
                                        reader.GetString(2),
                                        reader.GetString(3),
                                        reader.GetString(4),
                                        reader.GetDateTime(5),
                                        reader.GetBoolean(6)
                                        );
            }
            else
            {
                throw new Exception($"Aucune occurance à l'ID {ID} dans la table Adherents");
            }

            DetruireConnexionEtCommande();

            return adherent;
        }
        #endregion

        #region Insert
        public override Adherent_DAL Insert(Adherent_DAL adherent)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into Adherents(societe, civilite, nom, prenom, email, date_adhesion, actif)" + " values (@Societe, @Civilite, @Nom, @Prenom, @Email, @Date_adhesion, @Actif); select scope_identity()";
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

            commande.CommandText = "update Adherents set societe=@Societe, civilite=@Civilite, nom=@Nom, prenom=@Prenom, email=@Email, date_adhesion=@Date_adhesion, actif=@Actif where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", adherent.ID));
            commande.Parameters.Add(new SqlParameter("@Societe", adherent.Societe));
            commande.Parameters.Add(new SqlParameter("@Civilite", adherent.Civilite));
            commande.Parameters.Add(new SqlParameter("@Nom", adherent.Nom));
            commande.Parameters.Add(new SqlParameter("@Prenom", adherent.Prenom));
            commande.Parameters.Add(new SqlParameter("@Email", adherent.Email));
            commande.Parameters.Add(new SqlParameter("@Date_adhesion", adherent.Date_adhesion));
            commande.Parameters.Add(new SqlParameter("@Actif", adherent.Actif));

            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour le point d'ID {adherent.ID}");
            }

            DetruireConnexionEtCommande();

            return adherent;
        }
        #endregion

        #region Delete
        public override void Delete(Adherent_DAL adherent)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "delete from Adherents where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", adherent.ID));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de supprimer le point d'ID {adherent.ID}");
            }

            DetruireConnexionEtCommande();
        }
        #endregion

    }
}