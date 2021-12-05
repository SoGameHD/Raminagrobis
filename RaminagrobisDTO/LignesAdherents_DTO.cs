using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DTO
{
    class LignesAdherents_DTO
    {
        public int ID_ligne_global { get; set; }
        public int Quantite { get; set; }
        public int ID_produit { get; set; }
        public int ID_commande { get; set; }
    }
}
