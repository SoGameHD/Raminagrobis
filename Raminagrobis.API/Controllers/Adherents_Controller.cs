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
    public class Adherents_Controller : ControllerBase
    {
        private Adherents_Services service;

        public Adherents_Controller(Adherents_Services srv)
        {
            service = srv;
        }

        [HttpGet]
        public IEnumerable<Adherent_DTO> GetAll()
        {
            return service.GetAll().Select(t => new Adherent_DTO()
            {
                ID = t.ID,
            });
        }
    }
}
