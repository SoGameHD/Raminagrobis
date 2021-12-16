using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class Propositions_DAL
    {
        public int Prix { get; set; }
        public int ID_ligne_global { get; set; }
        public int ID_fournisseur { get; set; }

        public Propositions_DAL(int prix) => (Prix) = (prix);

        public Propositions_DAL(int id_ligne_global, int id_fournisseur, int prix) => (ID_ligne_global, ID_fournisseur, Prix) = (id_ligne_global, id_fournisseur, prix);

        #region Insert
        public void Insert(SqlConnection connexion)
        {

            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;
                commande.CommandText = "INSERT INTO Propositions(id_ligne_global, id_fournisseur, prix) VALUES (@ID_ligne_global, @ID_fournisseur, @Prix); SELECT SCOPE_IDENTITY()";

                commande.Parameters.Add(new SqlParameter("@ID_ligne_global", ID_ligne_global));
                commande.Parameters.Add(new SqlParameter("@ID_fournisseur", ID_fournisseur));
                commande.Parameters.Add(new SqlParameter("@Prix", Prix));
            }
            connexion.Close();
        }
        #endregion
    }
}