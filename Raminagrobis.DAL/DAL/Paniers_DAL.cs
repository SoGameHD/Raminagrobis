using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class Paniers_DAL
    {
        public string Libelle { get; set; }
        public int ID { get; set; }

        public Paniers_DAL(string libelle) => (Libelle) = (libelle);

        public Paniers_DAL(int id, string libelle) => (ID, Libelle) = (id, libelle);

        #region Insert
        public void Insert(SqlConnection connexion)
        {

            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;
                commande.CommandText = "insert into Paniers(libelle)" + " values(@Libelle); SELECT SCOPE_IDENTITY()";

                commande.Parameters.Add(new SqlParameter("@Libelle", Libelle));

                ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            }
            connexion.Close();
        }
        #endregion
    }
}
