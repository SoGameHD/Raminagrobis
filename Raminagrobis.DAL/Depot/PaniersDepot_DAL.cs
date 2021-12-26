using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class PaniersDepot_DAL : Depot_DAL<Paniers_DAL>
    {
        #region GetAll
        public override List<Paniers_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT libelle FROM Paniers";
            var reader = commande.ExecuteReader();

            var listeProduits = new List<Paniers_DAL>();

            while (reader.Read())
            {
                var paniers = new Paniers_DAL(reader.GetString(0));

                listeProduits.Add(paniers);
            }

            DetruireConnexionEtCommande();

            return listeProduits;
        }
        #endregion

        #region GetByID
        public override Paniers_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT ID, libelle FROM Paniers WHERE ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            Paniers_DAL listePaniers;

            if (reader.Read())
            {
                listePaniers = new Paniers_DAL(reader.GetInt32(0),
                                    reader.GetString(1)
                                    );
            }
            else
            {
                throw new Exception($"Aucune occurance à l'ID {ID} dans la table Paniers");
            }


            DetruireConnexionEtCommande();

            return listePaniers;
        }
        #endregion

        #region Insert
        public override Paniers_DAL Insert(Paniers_DAL paniers)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "INSERT INTO Paniers(libelle) VALUES ( @Libelle); SELECT SCOPE_IDENTITY()";
            commande.Parameters.Add(new SqlParameter("@Libelle", paniers.Libelle));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            paniers.ID = ID;

            DetruireConnexionEtCommande();

            return paniers;
        }
        #endregion

        #region Update
        public override Paniers_DAL Update(Paniers_DAL paniers)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "UPDATE Paniers SET libelle = @Libelle WHERE ID = @ID";
            commande.Parameters.Add(new SqlParameter("@ID", paniers.ID));
            commande.Parameters.Add(new SqlParameter("@Libelle", paniers.Libelle));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour le Paniers d'ID {paniers.ID}");
            }

            DetruireConnexionEtCommande();

            return paniers;
        }
        #endregion

        #region Delete
        public override void Delete(Paniers_DAL paniers)
        {
            CreerConnexionEtCommande();
            commande.CommandText = "DELETE FROM Paniers WHERE ID = @ID";
            commande.Parameters.Add(new SqlParameter("@ID", paniers.ID));

            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees < 0)
            {
                throw new Exception($"Impossible de supprimer le produit d'ID {paniers.ID}");
            }
            DetruireConnexionEtCommande();
        }
        #endregion
    }
}
