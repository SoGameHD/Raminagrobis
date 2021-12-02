using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class CommandeAdherents_DAL
    {
        public int ID_adherent { get; set; }
        public int ID_panier { get; set; }
        public int ID { get; set; }

        public CommandeAdherents_DAL(int id_adherent, int id_panier) => (ID_adherent, ID_panier) = (id_adherent, id_panier);

        public CommandeAdherents_DAL(int id, int id_adherent, int id_panier) => (ID, ID_adherent, ID_panier) = (id, id_adherent, id_panier);

        #region Insert
        public void Insert(SqlConnection connexion)
        {

            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;
                commande.CommandText = "insert into Commande(id_adherent, id_panier)" + " values(@ID_adherent, @ID_panier); SELECT SCOPE_IDENTITY()";

                commande.Parameters.Add(new SqlParameter("@ID_adherent", ID_adherent));
                commande.Parameters.Add(new SqlParameter("@ID_panier", ID_panier));

                ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            }
            connexion.Close();
        }
        #endregion
    }
}