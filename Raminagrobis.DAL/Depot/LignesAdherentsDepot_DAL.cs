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

            commande.CommandText = "SELECT id_produit, id_commande, id_ligne_global, quantite FROM LignesAdherent";
            var reader = commande.ExecuteReader();

            var listeAdherents = new List<LignesAdherents_DAL>();

            while (reader.Read())
            {
                var lignesAdherent = new LignesAdherents_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2),
                                        reader.GetInt32(3)
                                        );

                listeAdherents.Add(lignesAdherent);
            }

            DetruireConnexionEtCommande();

            return listeAdherents;
        }
        #endregion

        #region GetByID
        public override LignesAdherents_DAL GetByID(int ID)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region GetByID_produit
        public LignesAdherents_DAL GetByID_produit(int ID_produit)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT ID_produit, ID_commande, id_ligne_global, quantite FROM LignesAdherent WHERE ID_produit=@ID_produit";
            commande.Parameters.Add(new SqlParameter("@ID_produit", ID_produit));
            var reader = commande.ExecuteReader();

            LignesAdherents_DAL listeAdherent;

            if (reader.Read())
            {
                listeAdherent = new LignesAdherents_DAL(reader.GetInt16(0),
                                        reader.GetInt16(1)
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

        #region GetByID_commande
        public LignesAdherents_DAL GetByID_commande(int ID_commande)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT ID_produit, ID_commande, id_ligne_global, quantite FROM LignesAdherent WHERE ID_commande=@ID_commande";
            commande.Parameters.Add(new SqlParameter("@ID_commande", ID_commande));
            var reader = commande.ExecuteReader();

            LignesAdherents_DAL listeAdherent;

            if (reader.Read())
            {
                listeAdherent = new LignesAdherents_DAL(reader.GetInt16(0),
                                        reader.GetInt16(1)
                                        );
            }
            else
            {
                throw new Exception($"Aucune occurance à l'ID {ID_commande} dans la table LignesAdherent");
            }

            DetruireConnexionEtCommande();

            return listeAdherent;
        }
        #endregion

        #region Insert
        public override LignesAdherents_DAL Insert(LignesAdherents_DAL lignesAdherent)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "INSERT INTO LignesAdherent (id_produit, id_commande, id_ligne_global, quantite) VALUES (@ID_produit, @ID_commande, @ID_ligne_global, @Quantite); SELECT SCOPE_IDENTITY()";
            commande.Parameters.Add(new SqlParameter("@ID_produit", lignesAdherent.ID_produit));
            commande.Parameters.Add(new SqlParameter("@ID_commande", lignesAdherent.ID_commande));
            commande.Parameters.Add(new SqlParameter("@ID_ligne_global", lignesAdherent.ID_ligne_global));
            commande.Parameters.Add(new SqlParameter("@Quantite", lignesAdherent.Quantite));
            var ID_produit = Convert.ToInt32((decimal)commande.ExecuteScalar());
            var ID_commande = Convert.ToInt32((decimal)commande.ExecuteScalar());
                lignesAdherent.ID_produit = ID_produit;
                lignesAdherent.ID_commande = ID_commande;

            DetruireConnexionEtCommande();

            return lignesAdherent;
        }
        #endregion

        #region Update
        public override LignesAdherents_DAL Update(LignesAdherents_DAL lignesAdherent)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "UPDATE LignesAdherent SET id_ligne_global = @ID_ligne_global, quantite = @Quantite WHERE ID_produit = @ID_produit AND ID_commande = @ID_commande";
            commande.Parameters.Add(new SqlParameter("@ID_produit", lignesAdherent.ID_produit));
            commande.Parameters.Add(new SqlParameter("@ID_commande", lignesAdherent.ID_commande));
            commande.Parameters.Add(new SqlParameter("@ID_ligne_global", lignesAdherent.ID_ligne_global));
            commande.Parameters.Add(new SqlParameter("@Quantite", lignesAdherent.Quantite));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour la LignesAdherents d'ID_produit {lignesAdherent.ID_produit} & d'ID_commande {lignesAdherent.ID_commande}");
            }

            DetruireConnexionEtCommande();

            return lignesAdherent;
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
