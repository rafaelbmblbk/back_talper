using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Talper.API.Models;

namespace Talper.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE, OPTIONS")]
    [RoutePrefix("prospectos")]
    public class ProspectosController : ApiController
    {
        // GET: api/Prospectos
        public IEnumerable<Prospecto> Get()
        {
            ProspectosBD prospecto = new ProspectosBD();
            return prospecto.prostectoQuery();
        }

        // GET: api/Prospectos/5
        public IEnumerable<Prospecto> Get(int id)
        {
            ProspectosBD prospecto = new ProspectosBD();
            return prospecto.prostectoRead(id);
        }

        // POST: api/Prospectos
        public int Post([FromBody] Prospecto info)
        {
            ProspectosBD prospecto = new ProspectosBD();
            int res = prospecto.prospectoInsert(info);

            return res;
        }

        // PUT: api/Prospectos/5
        public bool Put(int prospectoKey, [FromBody] Prospecto info)
        {
            ProspectosBD prospecto = new ProspectosBD();
            bool res = prospecto.prospectoUpdate(prospectoKey, info);

            return res;
        }

        // DELETE: api/Prospectos/5
        public bool Delete(int prospectoKey)
        {
            ProspectosBD prospecto = new ProspectosBD();
            bool res = prospecto.prospectoDelete(prospectoKey);

            return res;
        }
    }
}
