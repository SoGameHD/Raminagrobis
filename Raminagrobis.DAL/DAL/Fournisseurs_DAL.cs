using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class Fournisseurs_DAL
    {
        public int ID { get; set; }
        public string Societe { get; set; }
        public bool Civilite { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Adresse { get; set; }
        public bool Actif { get; set; }

        public Fournisseurs_DAL(string societe, bool civilite, string nom, string prenom, string email, string adresse, bool actif) => (Societe, Civilite, Nom, Prenom, Email, Adresse, Actif) = (societe, civilite, nom, prenom, email, adresse, actif);

        public Fournisseurs_DAL(int id, string societe, bool civilite, string nom, string prenom, string email, string adresse, bool actif) => (ID, Societe, Civilite, Nom, Prenom, Email, Adresse, Actif) = (id, societe, civilite, nom, prenom, email, adresse, actif);

        #region Insert
        public void Insert(SqlConnection connexion)
        {

            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;
                commande.CommandText = "INSERT INTO Fournisseurs(societe,civilite,nom, prenom, email,adresse,actif)" + " VALUES(@Societe,@Civilite,@Nom,@Prenom, @Email,@Adresse,@Actif); SELECT SCOPE_IDENTITY()";

                commande.Parameters.Add(new SqlParameter("@Societe", Societe));
                commande.Parameters.Add(new SqlParameter("@Civilite", Civilite));
                commande.Parameters.Add(new SqlParameter("@Nom", Nom));
                commande.Parameters.Add(new SqlParameter("@Prenom", Prenom));
                commande.Parameters.Add(new SqlParameter("@Email", Email));
                commande.Parameters.Add(new SqlParameter("@Adresse", Adresse));
                commande.Parameters.Add(new SqlParameter("@Actif", Actif));

                ID = Convert.ToInt32((decimal)commande.ExecuteScalar());
            }
            connexion.Close();
        }
        #endregion
    }
}

