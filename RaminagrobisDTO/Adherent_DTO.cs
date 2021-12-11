using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DTO
{
    public class Adherent_DTO
    {
        public string Societe { get; private set; }
        public Boolean Civilite { get; private set; }
        public string Nom { get; private set; }
        public string Prenom { get; private set; }
        public string Email { get; private set; }
        public DateTime Date_adhesion { get; private set; }
        public Boolean Actif { get; private set; }
        public int? ID { get; set; }
    }
}
