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
    public class Adherents_Controller : ControllerBase
    {
        private Adherents_Services service;

        public Adherents_Controller(Adherents_Services srv)
        {
            service = srv;
        }

        #region GetAll
        [HttpGet]
        public IEnumerable<Adherent_DTO> GetAll()
        {
            return service.GetAll().Select(item => new Adherent_DTO()
            {
                ID = item.ID,
                Societe = item.Societe,
                Civilite = item.Civilite,
                Nom = item.Nom,
                Prenom = item.Prenom,
                Email = item.Email,
                Date_adhesion = item.Date_adhesion,
                Actif = item.Actif,
            });
        }
        #endregion

        #region GetByID
        [HttpGet("{id}")]
        public Adherent_DTO GetByID(int id)
        {
            var item = service.GetByID(id);
            return new Adherent_DTO()
            {
                ID = item.ID,
                Societe = item.Societe,
                Civilite = item.Civilite,
                Nom = item.Nom,
                Prenom = item.Prenom,
                Email = item.Email,
                Date_adhesion = item.Date_adhesion,
                Actif = item.Actif,
            };
        }
        #endregion

        #region Insert
        [HttpPost]
        public void Insert([FromBody] Adherent_DTO item)
        {
            service.Insert(item);
        }
        #endregion

        #region Update
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] Adherent_DTO item)
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
