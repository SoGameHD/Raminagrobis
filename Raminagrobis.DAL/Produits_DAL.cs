using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class Produits_DAL
    {
        public string Reference { get; private set;  }
        public string Libelle { get; private set; }
        public string Marque { get; private set; }
        public bool Actif { get; private set; }
        public int ID { get; private set; }

        public Produits_DAL(string reference, string libelle, string marque, bool actif) => (Reference, Libelle, Marque, Actif) = (reference, libelle, marque, actif);

        public Produits_DAL(int id, string reference, string libelle, string marque, bool actif) => (ID, Reference, Libelle, Marque, Actif) = (id, reference, libelle, marque, actif);
    }
}
