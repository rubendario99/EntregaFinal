using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models.Clases
{
    //Enumerado con los tipos de respuesta del obj Respuesta
   public enum TipoRespuesta
    {
        OK=1,
        KO=2,
        WARNING=3
    }

    //Clase para guardar y acceder posibles errores
    //en la ejecución de nuestras funciones y demás
    public class Respuesta
    {
        public string error { get; set; }
        public TipoRespuesta tipoRespuesta { get; set; }
    }
}