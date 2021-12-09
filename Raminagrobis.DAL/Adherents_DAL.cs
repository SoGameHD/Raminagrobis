﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class Adherent_DAL
    {
        public string Societe { get; private set; }
        public Boolean Civilite { get; private set; }
        public string Nom { get; private set; }
        public string Prenom { get; private set; }
        public string Email { get; private set; }
        public DateTime Date_adhesion { get; private set; }
        public Boolean Actif { get; private set; }
        public int ID { get; set; }

        public Adherent_DAL(string societe, Boolean civilite, string nom, string prenom, string email, DateTime date_adhesion, Boolean actif) => (Societe, Civilite, Nom, Prenom, Email, Date_adhesion, Actif) = (societe, civilite, nom, prenom, email, date_adhesion, actif);
        
        public Adherent_DAL(int id, string societe, Boolean civilite, string nom, string prenom, string email, DateTime date_adhesion, Boolean actif) => (ID, Societe, Civilite, Nom, Prenom, Email, Date_adhesion, Actif) = (id, societe, civilite, nom, prenom, email, date_adhesion, actif);

        #region Insert
        public void Insert(SqlConnection connexion)
        {

            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;
                commande.CommandText = "insert into Adherents(societe, civilite, nom, prenom, email, date_adhesion, actif)" + " values (@Societe, @Civilite, @Nom, @Prenom, @Email, @Date_adhesion, @actif); select scope_identity()";

                commande.Parameters.Add(new SqlParameter("@Societe", Societe));
                commande.Parameters.Add(new SqlParameter("@Civilite", Civilite));
                commande.Parameters.Add(new SqlParameter("@Nom", Nom));
                commande.Parameters.Add(new SqlParameter("@Prenom", Prenom));
                commande.Parameters.Add(new SqlParameter("@Email", Email));
                commande.Parameters.Add(new SqlParameter("@Date_adhesion", Date_adhesion));
                commande.Parameters.Add(new SqlParameter("@Actif", Actif));

                ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            }
            connexion.Close();
        }
        #endregion
    }
}
