using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DTO.DTO
{
    public class Adherent_DTO
    {
        public string Societe { get; set; }
        public bool Civilite { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public DateTime Date_adhesion { get; set; }
        public bool Actif { get; set; }
        public int? ID { get; set; }
    }
}
