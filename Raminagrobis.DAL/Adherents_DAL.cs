using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class Adherent_DAL
    {
        public string Societe { get; private set; }
        public int Civilite { get; private set; }
        public string Nom { get; private set; }
        public string Prenom { get; private set; }
        public string Email { get; private set; }
        public DateTime Date_adhesion { get; private set; }
        public int ID { get; set; }

        public Adherent_DAL(string societe, int civilite, string nom, string prenom, string email, DateTime dateAdhesion) => (Societe, Civilite, Nom, Prenom, Email, Date_adhesion) = (societe, civilite, nom, prenom, email, dateAdhesion);

        public Adherent_DAL(int id, string societe, int civilite, string nom, string prenom, string email, DateTime dateAdhesion) => (ID, Societe, Civilite, Nom, Prenom, Email, Date_adhesion) = (id, societe, civilite, nom, prenom, email, dateAdhesion);
    }
}
