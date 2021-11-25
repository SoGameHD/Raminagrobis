using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class Adherent_DAL
    {
        public string Societe { get; private set; }
        public Boolean Civilite { get; private set; }
        public string Nom { get; private set; }
        public string Prenom { get; private set; }
        public string Email { get; private set; }
        public DateTime Date_adhesion { get; private set; }
        public int ID { get; set; }

        public Adherent_DAL(string societe, Boolean civilite, string nom, string prenom, string email) => (Societe, Civilite, Nom, Prenom, Email) = (societe, civilite, nom, prenom, email);
        
        public Adherent_DAL(int id, string societe, Boolean civilite, string nom, string prenom, string email, DateTime date_adhesion) => (ID, Societe, Civilite, Nom, Prenom, Email, Date_adhesion) = (id, societe, civilite, nom, prenom, email, date_adhesion);

        public void Insert(SqlConnection connexion)
        {

            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;
                commande.CommandText = "insert into Adherents(societe, civilite, nom, prenom, email)"
                                    + " values (@societe, @civilite, @nom, @prenom, @email); select scope_identity()";

                commande.Parameters.Add(new SqlParameter("@societe", Societe));
                commande.Parameters.Add(new SqlParameter("@civilite", Civilite));
                commande.Parameters.Add(new SqlParameter("@nom", Nom));
                commande.Parameters.Add(new SqlParameter("@prenom", Prenom));
                commande.Parameters.Add(new SqlParameter("@email", Email));

                ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            }
            connexion.Close();
        }
    }
}
