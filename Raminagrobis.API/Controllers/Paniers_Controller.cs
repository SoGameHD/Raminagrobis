using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Raminagrobis.METIER.Services;
using Raminagrobis.DTO.DTO;

namespace Raminagrobis.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Paniers_Controller : ControllerBase
    {
        private Paniers_Services service;

        public Paniers_Controller(Paniers_Services srv)
        {
            service = srv;
        }

        #region GetAll
        [HttpGet]
        public IEnumerable<Paniers_DTO> GetAll()
        {
            return service.GetAll().Select(item => new Paniers_DTO()
            {
                ID = item.ID,
                Libelle = item.Libelle,
            }); ;
        }
        #endregion

        #region GetByID
        [HttpGet("{id}")]
        public Paniers_DTO GetByID(int id)
        {
            var item = service.GetByID(id);
            return new Paniers_DTO()
            {
                ID = item.ID,
                Libelle = item.Libelle,
            };
        }
        #endregion

        #region Insert
        [HttpPost]
        public void Insert([FromBody] Paniers_DTO item)
        {
            service.Insert(item);
        }
        #endregion

        #region Update
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] Paniers_DTO item)
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
