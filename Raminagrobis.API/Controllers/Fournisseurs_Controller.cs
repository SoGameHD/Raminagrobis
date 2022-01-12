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
    public class Fournisseurs_Controller : ControllerBase
    {
        private Fournisseurs_Services service;

        public Fournisseurs_Controller(Fournisseurs_Services srv)
        {
            service = srv;
        }

        #region GetAll
        [HttpGet]
        public IEnumerable<Fournisseur_DTO> GetAll()
        {
            return service.GetAll().Select(item => new Fournisseur_DTO()
            {
                ID = item.ID,
                Societe = item.Societe,
                Civilite = item.Civilite,
                Nom = item.Nom,
                Prenom = item.Prenom,
                Email = item.Email,
                Adresse = item.Adresse,
                Actif = item.Actif,
            });
        }
        #endregion

        #region GetByID
        [HttpGet("{id}")]
        public Fournisseur_DTO GetByID(int id)
        {
            var item = service.GetByID(id);
            return new Fournisseur_DTO()
            {
                ID = item.ID,
                Societe = item.Societe,
                Civilite = item.Civilite,
                Nom = item.Nom,
                Prenom = item.Prenom,
                Email = item.Email,
                Adresse = item.Adresse,
                Actif = item.Actif,
            };
        }
        #endregion

        #region Insert
        [HttpPost]
        public void Insert([FromBody] Fournisseur_DTO item)
        {
            service.Insert(item);
        }
        #endregion

        #region Update
        [HttpPut("{id}")]
        public void Update (int id, [FromBody] Fournisseur_DTO item)
        {
            service.Update(id, item);
        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public void Delete( int id)
        {
            service.Delete(id);
        }
        #endregion
    }
}
