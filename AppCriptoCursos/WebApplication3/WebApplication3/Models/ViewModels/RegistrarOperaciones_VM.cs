using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication3.Models;

namespace WebApplication3.Models.ViewModels
{
    public class RegistrarOperaciones_VM
    {
        public List<TiposOperaciones> tiposOperaciones { get; set; }
        public List<Moneda> listaMonedas { get; set; }
        public List<Decimal> tasaCambio { get; set; }
        public Moneda moneda { get; set; }
        public Operaciones operaciones { set; get; }
        [Required(ErrorMessage = "Introduce una fecha")]
        [RegularExpression(@"(\d{2}/\d{2}/\d{4})", ErrorMessage = "Introduce una fecha valida")]
        public string fecha { get; set; }
        [DisplayName("Introduce hora")]
        [Required(ErrorMessage = "Introduce una hora")]
        public string hora { get; set; }
    }
}