using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Moneda
    {
        public int Moneda_PK { get; set; }

        [Required(ErrorMessage = "Debe ingresar un nombre")]
        public string Nombre { get; set; }
        public bool Favorita { get; set; }
        [Required(ErrorMessage = "Debe ingresar un cambio")]
        public decimal Cambio { get; set; }
        public bool Activa { get; set; }
        public DateTime FechaCreacion { set; get; }

    }
}