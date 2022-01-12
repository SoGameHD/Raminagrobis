using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Raminagrobis.DTO;
using System.Collections.Generic;
using System.Linq;
using Raminagrobis.METIER.Services;

namespace Raminagrobis.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Produits_Controller : ControllerBase
    {
        private Produits_Services service;

        public Produits_Controller(Produits_Services srv)
        {
            service = srv;
        }

        #region GetAll
        [HttpGet]
        public IEnumerable<Produits_DTO> GetAll()
        {
            return service.GetAll().Select(item => new Produits_DTO()
            {
                ID = item.ID,
                Reference = item.Reference,
                Libelle = item.Libelle,
                Marque = item.Marque,
                Actif = item.Actif,
            }); ;
        }
        #endregion

        #region GetByID
        [HttpGet("{id}")]
        public Produits_DTO GetByID(int id)
        {
            var item = service.GetByID(id);
            return new Produits_DTO()
            {
                ID = item.ID,
                Reference = item.Reference,
                Libelle = item.Libelle,
                Marque = item.Marque,
                Actif = item.Actif,
            };
        }
        #endregion

        #region Insert
        [HttpPost]
        public void Insert([FromBody] Produits_DTO item)
        {
            service.Insert(item);
        }
        #endregion

        #region Update
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] Produits_DTO item)
        {
            service.Update(id, item);
        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.Delete(id);
        }
        #endregion
    }
}
