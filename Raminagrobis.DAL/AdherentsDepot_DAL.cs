using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class AdherentDepot_DAL : Depot_DAL<Adherent_DAL>
    {
        public override List<Adherent_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select societe, civilite, nom, prenom, email, date_adhesion from Adherents";
            var reader = commande.ExecuteReader();

            var listeAdherents = new List<Adherent_DAL>();

            while (reader.Read())
            {
                var adherent = new Adherent_DAL(reader.GetString(0),
                                        reader.GetByte(1),
                                        reader.GetString(2),
                                        reader.GetString(3),
                                        reader.GetString(4),
                                        reader.GetDateTime(5));

                listeAdherents.Add(adherent);
            }

            DetruireConnexionEtCommande();

            return listeAdherents;
        }

        public override Adherent_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select ID, societe, civilite, nom, prenom, email, date_adhesion from Adherents where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            Adherent_DAL adherent;
            if (reader.Read())
            {
                adherent = new Adherent_DAL(reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetByte(2),
                                        reader.GetString(3),
                                        reader.GetString(4),
                                        reader.GetString(5),
                                        reader.GetDateTime(6));
            }
            else
            {
                throw new Exception($"Aucune occurance à l'ID {ID} dans la table Adherents");
            }


            DetruireConnexionEtCommande();

            return adherent;
        }

        public override Adherent_DAL Insert(Adherent_DAL adherent)
        {
            throw new NotImplementedException();
            //TODO
        }

        public override Adherent_DAL Update(Adherent_DAL adherent)
        {
            throw new NotImplementedException();
            //TODO
        }

        public override void Delete(Adherent_DAL adherent)
        {

            throw new NotImplementedException();
            //TODO
        }

    }
}
