using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Talper.API.Models
{
    public class Archivos
    {
        public int archivoId { get; set; }
        public int prospectoId { get; set; }
        public string nombre { get; set; }
        public string path { get; set; }

        public Archivos()
        {

        }

        public Archivos(int ProspectoId , string Nombre , string Path)
        {
            prospectoId = ProspectoId;
            nombre = Nombre;
            path = Path;

        }

        public Archivos(int ArchivoId, int ProspectoId, string Nombre, string Path)
        {
            archivoId = ArchivoId;
            prospectoId = ProspectoId;
            nombre = Nombre;
            path = Path;

        }

    }
}