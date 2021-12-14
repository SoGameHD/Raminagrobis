using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class LignesAdherents_DAL
    {
        public int ID_ligne_global { get; set; }
        public int Quantite { get; set; }
        public int ID_produit { get; set; }
        public int ID_commande { get; set; }

        public LignesAdherents_DAL(int id_ligne_global, int quantite) => (ID_ligne_global, Quantite) = (id_ligne_global, quantite);

        public LignesAdherents_DAL(int id_produit, int id_commande, int id_ligne_global, int quantite) => (ID_produit, ID_commande, ID_ligne_global, Quantite) = (id_produit, id_commande, id_ligne_global, quantite);
        
        #region Insert
        public void Insert(SqlConnection connexion)
        {

            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;
                commande.CommandText = "INSERT INTO LignesAdherent(id_ligne_global, quantite)" + " VALUES(@ID_ligne_global, @Quantite); SELECT SCOPE_IDENTITY()";

                commande.Parameters.Add(new SqlParameter("@ID_ligne_global", ID_ligne_global));
                commande.Parameters.Add(new SqlParameter("@Quantite", Quantite));

                ID_produit = Convert.ToInt32((decimal)commande.ExecuteScalar());
                ID_commande = Convert.ToInt32((decimal)commande.ExecuteScalar());

            }
            connexion.Close();
        }
        #endregion
    }
}
