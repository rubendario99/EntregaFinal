using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Models.ViewModels
{
    public class Informe_VM
    {
        public List<Operaciones> listaOperaciones { get; set; }
        public List<TiposOperaciones> listaTipoOperacion { get; set; }
        public List<Moneda> listaMonedas { get; set; }
        public Operaciones operaciones { get; set; }
        public TiposOperaciones tiposOperaciones { get; set; }
        public Moneda moneda { get; set; }
        public List<SelectListItem> listaMovimientos { get; set; }
        public int movimientoSemana { get; set; }
    }
}