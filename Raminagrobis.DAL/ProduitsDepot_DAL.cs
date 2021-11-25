using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class ProduitsDepot_DAL : Depot_DAL<Produits_DAL>
    {
        #region GetAll
        public override List<Produits_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select reference, libelle, marque, actif from Produits";
            var reader = commande.ExecuteReader();

            var listeProduits = new List<Produits_DAL>();

            while (reader.Read())
            {
                var produits = new Produits_DAL(reader.GetString(0),
                                        reader.GetString(1),
                                        reader.GetString(2),
                                        reader.GetBoolean(3)
                                        );

                listeProduits.Add(produits);
            }

            DetruireConnexionEtCommande();

            return listeProduits;
        }
        #endregion

        #region GetByID
        public override Produits_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select ID, reference, libelle, marque, actif from Produits where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            Produits_DAL listeProduits;

            if (reader.Read())
            {
                listeProduits = new Produits_DAL(reader.GetString(0),
                                        reader.GetString(1),
                                        reader.GetString(2),
                                        reader.GetBoolean(3)
                                        );
            }
            else
            {
                throw new Exception($"Aucune occurance à l'ID {ID} dans la table Produits");
            }


            DetruireConnexionEtCommande();

            return listeProduits;
        }
        #endregion

        #region Insert
        public override Produits_DAL Insert(Produits_DAL produits)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into Produits(reference, libelle, marque, actif)" + " values (@Reference, @Libelle, @Marque, @Actif); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@Reference", produits.Reference));
            commande.Parameters.Add(new SqlParameter("@Libelle", produits.Libelle));
            commande.Parameters.Add(new SqlParameter("@Marque", produits.Marque));
            commande.Parameters.Add(new SqlParameter("@Actif", produits.Actif));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            produits.ID = ID;

            DetruireConnexionEtCommande();

            return produits;
        }
        #endregion


        #region Update
        public override Produits_DAL Update(Produits_DAL produits)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update Produits SET reference = @Reference, libelle = @Libelle, marque = @Marque, actif = @Actif where ID = @ID";
            commande.Parameters.Add(new SqlParameter("@Reference", produits.Reference));
            commande.Parameters.Add(new SqlParameter("@Libelle", produits.Libelle));
            commande.Parameters.Add(new SqlParameter("@Marque", produits.Marque));
            commande.Parameters.Add(new SqlParameter("@Actif", produits.Actif));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour le fournisseur d'ID {produits.ID}");
            }


            DetruireConnexionEtCommande();

            return produits;
        }
        #endregion

        #region Delete
        public override void Delete(Produits_DAL produits)
        {
            CreerConnexionEtCommande();
            commande.CommandText = "delete from Produits where ID = @ID";
            commande.Parameters.Add(new SqlParameter("@ID", produits.ID));

            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees < 0)
            {
                throw new Exception($"Impossible de mettre à jour le produit d'ID {produits.ID}");
            }
            DetruireConnexionEtCommande();
        }
        #endregion
    }
}
