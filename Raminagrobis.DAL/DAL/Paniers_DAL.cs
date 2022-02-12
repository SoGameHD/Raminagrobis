using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL.DAL
{
    public class Paniers_DAL
    {
        public string Libelle { get; set; }
        public int ID { get; set; }

        public Paniers_DAL(string libelle) => Libelle = libelle;
        public Paniers_DAL(int id, string libelle) => (ID, Libelle) = (id, libelle);
    }
}
