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
    [RoutePrefix("estatus")]
    public class EstatusController : ApiController
    {
        // GET: api/Estatus
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Estatus/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Estatus
        public bool Post([FromBody]Prospecto value)
        {
            ProspectosBD prospecto = new ProspectosBD();
            bool res = prospecto.prospectoEstatus(value);

            return res;
        }

        // PUT: api/Estatus/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Estatus/5
        public void Delete(int id)
        {
        }
    }
}
