using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DTO.DTO
{
    public class Produits_DTO
    {
        public string Reference { get; set; }
        public string Libelle { get; set; }
        public string Marque { get; set; }
        public bool Actif { get; set; }
        public int? ID { get; set; }
    }
}
