using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raminagrobis.DAL.DAL;
using Raminagrobis.DAL.Depot;
using Raminagrobis.METIER.Metier;
using Raminagrobis.DTO.DTO;

namespace Raminagrobis.METIER.Services
{
    public class Paniers_Services
    {
        #region GetAll
        public List<Paniers_METIER> GetAll()
        {
            var result = new List<Paniers_METIER>();
            var depot = new PaniersDepot_DAL();
            foreach (var item in depot.GetAll())
            {
                result.Add(new Paniers_METIER(item.ID, item.Libelle));
            }
            return result;
        }
        #endregion

        #region GetByID
        public Paniers_METIER GetByID(int id)
        {
            var depot = new PaniersDepot_DAL();
            var paniers = depot.GetByID(id);
            return new Paniers_METIER(paniers.ID, paniers.Libelle);
        }
        #endregion

        #region Insert
        public void Insert(Paniers_DTO input)
        {
            var paniers = new Paniers_DAL(input.Libelle);
            var depot = new PaniersDepot_DAL();
            depot.Insert(paniers);
        }
        #endregion

        #region Update
        public void Update(int id, Paniers_DTO input)
        {
            var paniers = new Paniers_DAL(id, input.Libelle);
            var depot = new PaniersDepot_DAL();
            depot.Update(paniers);
        }
        #endregion

        #region Delete
        public void Delete(int id)
        {
            Paniers_DAL paniers;
            PaniersDepot_DAL depot = new PaniersDepot_DAL();
            paniers = depot.GetByID(id);
            depot.Delete(paniers);
        }
        #endregion
    }
}
