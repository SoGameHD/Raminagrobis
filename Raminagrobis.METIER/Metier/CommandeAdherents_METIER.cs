using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DAL.DAL;

namespace Raminagrobis.METIER.Metier
{
    public class CommandeAdherents_METIER
    {
        public int ID_adherent { get; set; }
        public int ID_panier { get; set; }
        private int ID { get; set; }

        public CommandeAdherents_METIER(int id_adherent, int id_panier) => (ID_adherent, ID_panier) = (id_adherent, id_panier);

        #region Insert
        public void Insert()
        {
            CommandeAdherents_DAL CommandeAdherents = new(ID_adherent, ID_panier);

            var depotAdherent = new CommandeAdherentsDepot_DAL();

            CommandeAdherents = depotAdherent.Insert(CommandeAdherents);

            ID = CommandeAdherents.ID;
        }
        #endregion

        #region Delete
        public void Delete()
        {
            CommandeAdherents_DAL CommandeAdherents = new CommandeAdherents_DAL(ID_adherent, ID_panier);
            var depotfournisseur = new CommandeAdherentsDepot_DAL();
            depotfournisseur.Delete(CommandeAdherents);
        }
        #endregion

        #region Update
        public void Update()
        {
            CommandeAdherents_DAL CommandeAdherents = new CommandeAdherents_DAL(ID_adherent, ID_panier);
            var depotCommandeAdherents = new CommandeAdherentsDepot_DAL();
            depotCommandeAdherents.Update(CommandeAdherents);
        }
        #endregion
    }
}