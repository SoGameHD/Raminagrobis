using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class LignesAdherentsDepot_DAL : Depot_DAL<LignesAdherents_DAL>
    {
        #region GetAll
        public override List<LignesAdherents_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id_ligne_global, quantite from LignesAdherents";
            var reader = commande.ExecuteReader();

            var listeAdherents = new List<LignesAdherents_DAL>();

            while (reader.Read())
            {
                var lignesAdherent = new LignesAdherents_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1)
                                        );

                listeAdherents.Add(lignesAdherent);
            }

            DetruireConnexionEtCommande();

            return listeAdherents;
        }
        #endregion

        #region GetByID
        public override LignesAdherents_DAL GetByID(int ID_produit/*, int ID_commande*/)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select ID_produit, ID_commande, id_ligne_globale, quantite from LignesAdherent where ID_produit=@ID_produits, ID_commande=@ID_commande";
            commande.Parameters.Add(new SqlParameter("@ID_produit", ID_produit));
            /*commande.Parameters.Add(new SqlParameter("@ID_commande", ID_commande));*/
            var reader = commande.ExecuteReader();

            LignesAdherents_DAL listeAdherent;

            if (reader.Read())
            {
                listeAdherent = new LignesAdherents_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2),
                                        reader.GetInt32(3)
                                        );
            }
            else
            {
                throw new Exception($"Aucune occurance à l'ID {ID_produit} dans la table LignesAdherent");
            }

            DetruireConnexionEtCommande();

            return listeAdherent;
        }
        #endregion

        #region Insert
        public override LignesAdherents_DAL Insert(LignesAdherents_DAL lignesAdherent)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Update
        public override LignesAdherents_DAL Update(LignesAdherents_DAL lignesAdherent)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Delete
        public override void Delete(LignesAdherents_DAL lignesAdherent)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
