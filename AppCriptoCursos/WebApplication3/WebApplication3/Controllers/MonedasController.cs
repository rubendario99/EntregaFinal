using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using WebApplication3.Models.Clases;
using WebApplication3.Models.Funciones;

namespace WebApplication3.Controllers
{
    public class MonedasController : Controller
    {
        //Creo la conexión con la base de datos
        SqlConnection connection = new SqlConnection("Server=localhost;Database=Monedas;Trusted_Connection=True;");
        public ActionResult Index()
        {
            //Creo y relleno la lista de monedas desde la base de datos
            List<Moneda> listaMonedas = new List<Moneda>();
            Respuesta respuesta = Func_Monedas.recuperarListaMonedas(listaMonedas);

            if (respuesta.tipoRespuesta != TipoRespuesta.OK)
            {
                return View("Error");
            }

            //Devuelvo la vista con el modelo que utiliza la vista correspondiente
            //En este caso Monedas/Index
            return View(listaMonedas);
        }

        //Este Edit es la vista que se mostrará antes de editar como tal
        //Por eso no tiene [HttpPost]
        //Aquí sólo cogemos datos para mostrar
        public ActionResult Edit(int id = 0)
        {
            Moneda moneda = new Moneda();

            //Creo y relleno el objeto moneda según la moneda que haya consultado
            Respuesta respuesta = Func_Monedas.recuperarMoneda(moneda, id);

            if (respuesta.tipoRespuesta != TipoRespuesta.OK)
            {
                return View("Error");
            }

            //En este caso Monedas/Index
            return View(moneda);
        }
        [HttpPost]
        public ActionResult Edit(Moneda moneda)
        {
            //La vista tiene un modelo especificado
            //Cuando hay un formulario y se hace el submit
            //Este modelo se envía de vuelta al controlador
            //En este caso es Moneda, que es el parámetro que tiene el método

            //Creamos el objeto respuesta para gestionar errores
            //Editamos la moneda devuelta por la vista
            Respuesta respuesta = Func_Monedas.editarMoneda(moneda);

            //Creamos un tipo respuesta y le asignamos el valor
            //Que haya devuelto la Respuesta de la consulta
            TipoRespuesta tipoRespuesta = respuesta.tipoRespuesta;

            //Gestionamos en caso de que haya errores
            if (tipoRespuesta != TipoRespuesta.OK)
            {
                return View("Error");
            }

            //Volvemos a la acción Index
            //NO la vista, dado que esto no actualizaría los datos
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult EditJson(Moneda moneda)
        {
            //La vista tiene un modelo especificado
            //Cuando hay un formulario y se hace el submit
            //Este modelo se envía de vuelta al controlador
            //En este caso es Moneda, que es el parámetro que tiene el método

            //Creamos el objeto respuesta para gestionar errores
            //Editamos la moneda devuelta por la vista
            Respuesta respuesta = Func_Monedas.editarMoneda(moneda);

            //Creamos un tipo respuesta y le asignamos el valor
            //Que haya devuelto la Respuesta de la consulta
            TipoRespuesta tipoRespuesta = respuesta.tipoRespuesta;

            //Gestionamos en caso de que haya errores
            if (tipoRespuesta != TipoRespuesta.OK)
            {
                return Json(new { status = "KO" });

            }
            //Volvemos a la acción Index
            //NO la vista, dado que esto no actualizaría los datos
            string vista = PartialView("~/Views/Monedas/_CrearExito.cshtml", moneda).RenderToString();
            return Json(new { status = "OK", vista = vista });
        }

        public ActionResult Create()
        {
            //Aquí solo hacemos que al ir a /create
            //Se cargue la vista llamada Create
            return View();
        }
        [HttpPost]
        public ActionResult Create(Moneda moneda)
        {
            //Creamos el objeto respuesta y ejecutamos la función, crearMoneda()
            Respuesta respuesta = Func_Monedas.crearMoneda(moneda);
            TipoRespuesta tipoRespuesta = respuesta.tipoRespuesta;

            //Gestionamos errores
            if (tipoRespuesta != TipoRespuesta.OK)
            {
                return View("Error");
            }

            //Si hay un mensaje de error, lo mostramos en la misma página
            if (!string.IsNullOrEmpty(respuesta.error))
            {
                //Utilizamos ViewBag para enviarlo del controlador a la vista
                //Pero no puede reutilizarse 
                ViewBag.MensajeError = respuesta.error;

                return View();
            }

            //Si todo sale bien, enviamos un mensaje de éxito a la vista para mostrarlo
            //TempData puede ser reusado y no se pierden sus datos al contrario de ViewBag
            TempData["mensajeExito"] = "¡Se ha creado la moneda " + moneda.Nombre + "!";

            //Envíamos de nuevo al método Index
            //return RedirectToAction("Index");
            return View("Index");

        }
        public ActionResult Delete(int id = 0)
        {
            //Creamos el objeto respuesta y ejecutamos la función borrar()
            Respuesta respuesta = Func_Monedas.borrrarMoneda(id);
            TipoRespuesta tipoRespuesta = respuesta.tipoRespuesta;

            //Gestionamos errores
            if (tipoRespuesta != TipoRespuesta.OK)
            {
                return View("Error");
            }

            //Reenviamos a la acción Index
            return RedirectToAction("Index");
        }
        public ActionResult prueba(Moneda moneda)
        {
            //Creamos el objeto respuesta y ejecutamos la función, crearMoneda()
            Respuesta respuesta = Func_Monedas.crearMoneda(moneda);
            TipoRespuesta tipoRespuesta = respuesta.tipoRespuesta;

            Thread.Sleep(700);

            //Gestionamos errores
            if (tipoRespuesta != TipoRespuesta.OK)
            {
                return PartialView("_CrearError", moneda);
            }

            //Si hay un mensaje de error, lo mostramos en la misma página
            if (!string.IsNullOrEmpty(respuesta.error))
            {
                //Utilizamos ViewBag para enviarlo del controlador a la vista
                //Pero no puede reutilizarse 
                ViewBag.MensajeError = respuesta.error;
                return PartialView("_CrearError", moneda);
            }

            //Si todo sale bien, enviamos un mensaje de éxito a la vista para mostrarlo
            //TempData puede ser reusado y no se pierden sus datos al contrario de ViewBag
            TempData["mensajeExito"] = "¡Se ha creado la moneda " + moneda.Nombre + "!";

            //Envíamos de nuevo al método Index
            return PartialView("_CrearExito", moneda);
        }
        public JsonResult EditarModal(int id = 0, bool crear = false)
        {
            Moneda moneda = new Moneda();
            Respuesta respuesta = Func_Monedas.recuperarMoneda(moneda, id);

            //Gestionamos en caso de que haya errores
            if (respuesta.tipoRespuesta != TipoRespuesta.OK)
            {
                return Json(new { status = "KO" });
            }
            string modalOperacion;
            if (crear)
            {
                modalOperacion = PartialView("~/Views/Monedas/_ModalEditar.cshtml").RenderToString();
            }

            modalOperacion = PartialView("~/Views/Monedas/_ModalEditar.cshtml", moneda).RenderToString();

            return Json(new { status = "OK", crear = crear, modalEditar = modalOperacion });
        }
        public JsonResult RecuperarListaMonedas()
        {
            //Creo y relleno la lista de monedas desde la base de datos
            List<Moneda> listaMonedas = new List<Moneda>();
            Respuesta respuesta = Func_Monedas.recuperarListaMonedas(listaMonedas);

            if (respuesta.tipoRespuesta != TipoRespuesta.OK)
            {
                return Json(new { status = "KO", error = respuesta.error });
            }
            string vistaLista = PartialView("~/Views/Monedas/_TablaMonedas.cshtml", listaMonedas).RenderToString();
            return Json(new { status = "OK", vistaLista = vistaLista });
        }
        public JsonResult RecuperarMonedaBorrar(int id = 0)
        {
            //Creo y relleno la lista de monedas desde la base de datos
            Moneda moneda = new Moneda();
            Respuesta respuesta = Func_Monedas.recuperarMoneda(moneda, id);

            if (respuesta.tipoRespuesta != TipoRespuesta.OK)
            {
                return Json(new { status = "KO", error = respuesta.error });
            }
            string vistaBorrar = PartialView("~/Views/Monedas/_BorrarMoneda.cshtml", moneda).RenderToString();
            return Json(new { status = "OK", vistaBorrar = vistaBorrar });
        }
        public JsonResult RecuperarMonedaEditar(int id = 0)
        {
            //Creo y relleno la lista de monedas desde la base de datos
            Moneda moneda = new Moneda();
            Respuesta respuesta = Func_Monedas.recuperarMoneda(moneda, id);

            if (respuesta.tipoRespuesta != TipoRespuesta.OK)
            {
                return Json(new { status = "KO", error = respuesta.error });
            }
            string vistaEditar = PartialView("~/Views/Monedas/_EditarMoneda.cshtml", moneda).RenderToString();
            return Json(new { status = "OK", vistaEditar = vistaEditar });
        }
        public JsonResult BorrarMoneda(int id = 0)
        {
            //Creamos el objeto respuesta y ejecutamos la función borrar()
            Respuesta respuesta = Func_Monedas.borrrarMoneda(id);
            TipoRespuesta tipoRespuesta = respuesta.tipoRespuesta;

            //Gestionamos errores
            if (tipoRespuesta != TipoRespuesta.OK)
            {
                return Json(new { status = "KO" });
            }

            string vistaBorrar = PartialView("~/Views/_VistasInfo/_MensajeCorrecto.cshtml").RenderToString();
            return Json(new { status = "OK", vistaBorrar = vistaBorrar });
        }

        public JsonResult AbrirModalCrear()
        {
            string vistaCrear = PartialView("~/Views/Monedas/_CrearMoneda.cshtml").RenderToString();
            return Json(new { status = "OK", vistaCrear = vistaCrear });
        }
        public JsonResult CrearMoneda(Moneda moneda)
        {

            //Creamos el objeto respuesta y ejecutamos la función, crearMoneda()
            Respuesta respuesta = Func_Monedas.crearMoneda(moneda);
            TipoRespuesta tipoRespuesta = respuesta.tipoRespuesta;

            //Gestionamos errores
            if (tipoRespuesta != TipoRespuesta.OK)
            {
                return Json(new { status = "KO" });
            }
            string vista = PartialView("~/Views/_VistasInfo/_MensajeCorrecto.cshtml").RenderToString();
            return Json(new { status = "OK", vista = vista });
        }
        public JsonResult EditarMoneda(Moneda moneda)
        {

            //Creamos el objeto respuesta y ejecutamos la función, crearMoneda()
            Respuesta respuesta = Func_Monedas.editarMoneda(moneda);
            TipoRespuesta tipoRespuesta = respuesta.tipoRespuesta;

            //Gestionamos errores
            if (tipoRespuesta != TipoRespuesta.OK)
            {
                return Json(new { status = "KO" });
            }
            string vista = PartialView("~/Views/_VistasInfo/_MensajeCorrecto.cshtml").RenderToString();
            return Json(new { status = "OK", vista = vista });
        }
    }
}

