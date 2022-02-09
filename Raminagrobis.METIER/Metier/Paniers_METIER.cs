using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DAL;
using Raminagrobis.DAL.DAL;
using Raminagrobis.DAL.Depot;

namespace Raminagrobis.METIER.Metier
{
    public class Paniers_METIER
    {
        public string Libelle { get; set; }
        public int ID { get; set; }

        public Paniers_METIER(string libelle) => Libelle = libelle;
        public Paniers_METIER(int id, string libelle) => (ID, Libelle) = (id, libelle);


        #region Insert
        public void Insert()
        {
            Paniers_DAL Paniers = new Paniers_DAL(Libelle);

            var depotPaniers = new PaniersDepot_DAL();

            Paniers = depotPaniers.Insert(Paniers);

            ID = Paniers.ID;
        }
        #endregion

        #region Delete
        public void Delete()
        {
            Paniers_DAL Paniers = new Paniers_DAL(Libelle);

            var depotPaniers = new PaniersDepot_DAL();

            depotPaniers.Delete(Paniers);
        }
        #endregion

        #region Update
        public void Update()
        {
            Paniers_DAL Paniers = new Paniers_DAL(Libelle);

            var depotPaniers = new PaniersDepot_DAL();

            depotPaniers.Update(Paniers);
        }
        #endregion
    }
}