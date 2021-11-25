using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class Produits_DAL
    {
        public string Reference { get; set;  }
        public string Libelle { get; set; }
        public string Marque { get; set; }
        public bool Actif { get; set; }
        public int ID { get; set; }

        public Produits_DAL(string reference, string libelle, string marque, bool actif) => (Reference, Libelle, Marque, Actif) = (reference, libelle, marque, actif);

        public Produits_DAL(int id, string reference, string libelle, string marque, bool actif) => (ID, Reference, Libelle, Marque, Actif) = (id, reference, libelle, marque, actif);

        public void Insert(SqlConnection connexion)
        {

            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;
                commande.CommandText = "insert into Produits(reference, libelle, marque, actif)" + " values(@Reference, @Libelle, @Marque, @Actif); SELECT SCOPE_IDENTITY()";

                commande.Parameters.Add(new SqlParameter("@Reference", Reference));
                commande.Parameters.Add(new SqlParameter("@Libelle", Libelle));
                commande.Parameters.Add(new SqlParameter("@Marque", Marque));
                commande.Parameters.Add(new SqlParameter("@Actif", Actif));

                ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            }
            connexion.Close();
        }
    }
}
