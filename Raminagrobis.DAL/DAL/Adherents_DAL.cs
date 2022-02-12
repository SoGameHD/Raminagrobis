using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL.DAL
{
    public class Adherent_DAL
    {
        public string Societe { get; set; }
        public bool Civilite { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public DateTime Date_adhesion { get; set; }
        public bool Actif { get; set; }
        public int ID { get; set; }

        public Adherent_DAL(string societe, bool civilite, string nom, string prenom, string email, DateTime date_adhesion, bool actif) => (Societe, Civilite, Nom, Prenom, Email, Date_adhesion, Actif) = (societe, civilite, nom, prenom, email, date_adhesion, actif);

        public Adherent_DAL(int id, string societe, bool civilite, string nom, string prenom, string email, DateTime date_adhesion, bool actif) => (ID, Societe, Civilite, Nom, Prenom, Email, Date_adhesion, Actif) = (id, societe, civilite, nom, prenom, email, date_adhesion, actif);
    }
}
