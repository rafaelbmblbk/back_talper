using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Talper.API.Models;

namespace Talper.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE, OPTIONS")]
    public class ArchivosController : ApiController
    {
        [HttpPost]
        [Route("api/Archivos/upload")]
        public async Task<bool> saveArchivo()
        {
            var filesToDelete = HttpContext.Current.Request.Files.Count;
            if (filesToDelete > 0)
            {
                var newFileName = HttpContext.Current.Request.Files[0];
                var extencion = HttpContext.Current.Request.Form.Get("extencion");
                var fileName = Guid.NewGuid().ToString() + "." + extencion;
                var tmpFilePath = "C:/tmp/talper/" + fileName;
                newFileName.SaveAs(tmpFilePath);

                Archivos info = new Archivos();
                info.prospectoId = Int32.Parse(HttpContext.Current.Request.Form.Get("prospectoId"));
                info.nombre = HttpContext.Current.Request.Form.Get("nombre");
                info.path = tmpFilePath;

                ArchivosBD archivo = new ArchivosBD();
                bool res = archivo.archivosInsert(info);

            }


            return true;
        }


        [HttpGet]
        [Route("api/Archivos/{prospectoId}")]
        public IEnumerable<Archivos> getArchivos(int prospectoId)
        {
            ArchivosBD archivo = new ArchivosBD();
            return archivo.archivosRead(prospectoId);
        }
    }
}
