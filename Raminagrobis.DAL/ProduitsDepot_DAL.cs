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

        public override Produits_DAL Insert(Produits_DAL produits)
        {
            throw new NotImplementedException();
            //TODO
        }

        public override Produits_DAL Update(Produits_DAL produits)
        {
            throw new NotImplementedException();
            //TODO
        }

        public override void Delete(Produits_DAL produits)
        {

            throw new NotImplementedException();
            //TODO
        }
    }
}
