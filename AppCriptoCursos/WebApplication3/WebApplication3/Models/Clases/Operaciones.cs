 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Operaciones
    {
        public int Operacion_PK { set; get; }
        public int Moneda_PK { set; get; }
        public int TipoOperacion_PK { set; get; }
        public DateTime FechaOperacion { set; get; }
        [DisplayName("Introduce importe")]
        [Required(ErrorMessage = "Introduce un importe")]
        public decimal Importe { set; get; }
        public decimal NumMonedas { set; get; }
        public DateTime FechaCreacion { set; get; }
    }
}