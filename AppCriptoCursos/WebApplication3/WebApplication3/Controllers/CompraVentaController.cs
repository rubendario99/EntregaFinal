using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using WebApplication3.Models.Clases;
using WebApplication3.Models.Funciones;
using WebApplication3.Models.ViewModels;


namespace WebApplication3.Controllers
{
    public class CompraVentaController : Controller
    {
        //Creo la conexión con la BBDD
        SqlConnection connection = new SqlConnection("Server=localhost;Database=Monedas;Trusted_Connection=True;");
        public ActionResult Index()
        {
            //Creo listas para guardar los datos de dropdowlist
            List<Moneda> listaMonedas = new List<Moneda>();
            List<TiposOperaciones> listaTiposOperacion = new List<TiposOperaciones>();

            //Creo el ViewModel para poder meterle datos luego
            RegistrarOperaciones_VM registroOperaciones = new RegistrarOperaciones_VM();

            //Relleno la lista de monedas
            Respuesta respuesta = Func_Monedas.recuperarListaMonedas(listaMonedas, false);

            //Guardo las listas en el ViewModel
            List<TiposOperaciones> listaTiposOperaciones = new List<TiposOperaciones>();
            respuesta = Func_Monedas.recuperarListaTiposOperaciones(listaTiposOperaciones, false);
            registroOperaciones.tiposOperaciones = listaTiposOperaciones;
            registroOperaciones.listaMonedas = listaMonedas;

            if (respuesta.tipoRespuesta != TipoRespuesta.OK)
            {
                return View("Error");
            }

            //Devuelvo la vista con el ViewModel
            return View(registroOperaciones);
        }
        [HttpPost]
        public ActionResult Index(RegistrarOperaciones_VM registroOperaciones)
        {
            //Creo y relleno la lista de monedas
            List<Moneda> listaMonedas = new List<Moneda>();
            Func_Monedas.recuperarListaMonedas(listaMonedas);

            //Cargo esta lista en la propieda del ViewModel
            registroOperaciones.listaMonedas = listaMonedas;

            //Añado al ViewModel los tipos de operaciones
            Respuesta respuesta = Func_Monedas.recuperarListaTiposOperaciones(registroOperaciones.tiposOperaciones);

            //Creo el objeto respuesta y ejecuto crearTransaccion()
            //El parámetro registroOperaciones contiene todos los datos necesarios para crear la transacción
            respuesta = Func_Monedas.crearTransaccion(registroOperaciones);
            TipoRespuesta tipoRespuesta = respuesta.tipoRespuesta;

            //Gestionamos errores
            if (tipoRespuesta != TipoRespuesta.OK)
            {
                return View("Error");
            }
            else
            {
                //Mostramos mensaje de éxito si sale bien todo
                ViewBag.MensajeExito = "¡Perfecto! Todo ha salido bien ";
            }

            return View(registroOperaciones);
        }
        //Función que utilizará la llamada de Ajax 
        //Para aplicar una tasa de cambio al momento de escribir en el formulario
        [HttpPost]
        public JsonResult RecuperarTasaCambio(int id = 0)
        {
            decimal tasaDeCambio = Func_Monedas.recuperarTasasCambio(id);

            if (tasaDeCambio == 0)
            {
                return Json(new { status = "KO" });
            }
            return Json(new { status = "OK", tasaCambio = 1 / tasaDeCambio });
        }
        public ActionResult RealizarOperacion(RegistrarOperaciones_VM registroOperaciones)
        {

            Respuesta respuesta = new Respuesta();
            respuesta.tipoRespuesta = TipoRespuesta.OK;

            //Creo y relleno la lista de monedas
            List<Moneda> listaMonedas = new List<Moneda>();
            respuesta = Func_Monedas.recuperarListaMonedas(listaMonedas);

            //Cargo esta lista en la propieda del ViewModel
            registroOperaciones.listaMonedas = listaMonedas;

            //Añado al ViewModel los tipos de operaciones
            respuesta = Func_Monedas.recuperarListaTiposOperaciones(registroOperaciones.tiposOperaciones);

            //Creo el objeto respuesta y ejecuto crearTransaccion()
            //El parámetro registroOperaciones contiene todos los datos necesarios para crear la transacción
            respuesta = Func_Monedas.crearTransaccion(registroOperaciones);
            TipoRespuesta tipoRespuesta = respuesta.tipoRespuesta;


            if (respuesta.tipoRespuesta != TipoRespuesta.OK)
            {
            return View("Error");
            }
            return PartialView("~/Views/Monedas/_CrearExito.cshtml", registroOperaciones.moneda);
        }

    }
}
