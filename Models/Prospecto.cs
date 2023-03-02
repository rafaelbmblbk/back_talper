using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Talper.API.Models
{
    public class Prospecto
    {
        public int prospectoId { get; set; }
        public string nombre { get; set; }
        public string apMaterno { get; set; }
        public string apPaterno { get; set; }
        public string calle { get; set; }
        public string numero { get; set; }
        public string colonia { get; set; }
        public string cp { get; set; }
        public string telefono { get; set; }
        public string rfc { get; set; }
        public string authorization { get; set; }
        public int stAutorization { get; set; }
        public string motivo { get; set; }
 
        public Prospecto()
        {

        }

        public Prospecto(string Nombre, string ApMaterno, string ApPaterno, string Calle, string Numero, string Colonia, string Cp, string Telefono, string Rfc, string Authorization, int StAutorization, string Motivo)
        {
            nombre = Nombre;
            apMaterno = ApMaterno;
            apPaterno = ApPaterno;
            calle = Calle;
            numero = Numero;
            colonia = Colonia;
            cp = Cp;
            telefono = Telefono;
            rfc = Rfc;
            authorization = Authorization;
            stAutorization = StAutorization;
            motivo = Motivo;
        }

        public Prospecto(int ProspectoId, string Nombre, string ApMaterno, string ApPaterno, string Calle, string Numero, string Colonia, string Cp, string Telefono, string Rfc, string Authorization,int StAutorization, string Motivo)
        {
            prospectoId = ProspectoId;
            nombre = Nombre;
            apMaterno = ApMaterno;
            apPaterno = ApPaterno;
            calle = Calle;
            numero = Numero;
            colonia = Colonia;
            cp = Cp;
            telefono = Telefono;
            rfc = Rfc;
            authorization = Authorization;
            stAutorization = StAutorization;
            motivo = Motivo;
        }
    }
}