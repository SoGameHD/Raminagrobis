using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class Liaison_DAL
    {
        public int ID_produit { get; set; }
        public int ID_fournisseur { get; set; }

        public Liaison_DAL(int id_produit, int id_fournisseur) => (ID_produit, ID_fournisseur) = (id_produit, id_fournisseur);

        #region Insert
        public void Insert(SqlConnection connexion)
        {

            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;
                commande.CommandText = "insert into Liaison(id_produit, id_fournisseur)" + " values(@ID_produit, @ID_fournisseur); SELECT SCOPE_IDENTITY()";

                commande.Parameters.Add(new SqlParameter("@ID_produit", ID_produit));
                commande.Parameters.Add(new SqlParameter("@ID_fournisseur", ID_fournisseur));
            }
            connexion.Close();
        }
        #endregion
    }
}