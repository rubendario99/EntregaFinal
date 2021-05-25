using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models.ViewModels;
using WebApplication3.Models.Funciones;
using WebApplication3.Models;
using WebApplication3.Models.Clases;
using OfficeOpenXml;
using System.IO;
using System.Data;
using OfficeOpenXml.Table;
using System.Threading;
using Newtonsoft.Json;

namespace WebApplication3.Controllers
{
    public class InformeController : Controller
    {
        // GET: Informe
        public ActionResult Index()
        {
            //Creamos el ViewModel para rellenar los datos
            Informe_VM informe_VM = new Informe_VM();

            //Creamos una lista que rellenaremos
            List<Moneda> listaMonedas = new List<Moneda>();
            Respuesta respuesta = Func_Monedas.recuperarListaMonedas(listaMonedas);

            //Asignamos la lista al ViewModel
            informe_VM.listaMonedas = listaMonedas;

            //Creamos una lista que rellenaremos y asignaremos al ViewModel
            List<TiposOperaciones> listaTiposOperaciones = new List<TiposOperaciones>();
            respuesta = Func_Monedas.recuperarListaTiposOperaciones(listaTiposOperaciones);
            informe_VM.listaTipoOperacion = listaTiposOperaciones;

            //Rellenamos la lista de operaciones en el ViewModel
            List<Operaciones> listaOperaciones = new List<Operaciones>();
            respuesta = Func_Monedas.recuperarListaOperaciones(listaOperaciones);
            informe_VM.listaOperaciones = listaOperaciones;

            List<SelectListItem> listaMovimientos = new List<SelectListItem>();
            respuesta = Func_Monedas.recuperarListaMovimientos(listaMovimientos);
            informe_VM.listaMovimientos = listaMovimientos;

            if (respuesta.tipoRespuesta != TipoRespuesta.OK)
            {
                return View("Error");
            }

            //Enviamos el ViewModel a la vista con los datos necesarios
            return View(informe_VM);
        }

        [HttpPost]
        public ActionResult Index(Informe_VM informe_VM)
        {
            int moneda_pk = informe_VM.operaciones.Moneda_PK;
            int fechaMovimiento = informe_VM.movimientoSemana;

            //Creamos una lista que rellenaremos
            List<Moneda> listaMonedas = new List<Moneda>();
            Respuesta respuesta = Func_Monedas.recuperarListaMonedas(listaMonedas);

            //Asignamos la lista al ViewModel
            informe_VM.listaMonedas = listaMonedas;

            //Creamos una lista que rellenaremos y asignaremos al ViewModel
            List<TiposOperaciones> listaTiposOperaciones = new List<TiposOperaciones>();
            respuesta = Func_Monedas.recuperarListaTiposOperaciones(listaTiposOperaciones);
            informe_VM.listaTipoOperacion = listaTiposOperaciones;

            //Rellenamos la lista de operaciones en el ViewModel
            List<Operaciones> listaOperaciones = new List<Operaciones>();
            respuesta = Func_Monedas.recuperarListaOperaciones(listaOperaciones, moneda_pk, fechaMovimiento);
            informe_VM.listaOperaciones = listaOperaciones;

            List<SelectListItem> listaMovimientos = new List<SelectListItem>();
            respuesta = Func_Monedas.recuperarListaMovimientos(listaMovimientos);
            informe_VM.listaMovimientos = listaMovimientos;

            string boton = Request.Form["btn"];
            DataTable datos = new DataTable();

            if (boton == "Exportar")
            {
                Func_Monedas.recuperarDatosExcel(datos, moneda_pk, fechaMovimiento);

                using (ExcelPackage excel = new ExcelPackage())
                {
                    //Creamos una hoja
                    ExcelWorksheet worksheet = excel.Workbook.Worksheets.Add("Hoja 1");

                    //Cargamos la lista en la hoja de excel
                    worksheet.Cells["A1"].LoadFromDataTable(datos, true);

                    //Creamos un rango
                    //Parámetros: 1a fila, 1a columna, última fila, última columna
                    ExcelRange range = worksheet.Cells[1, 1, worksheet.Dimension.End.Row, worksheet.Dimension.End.Column];

                    //Añadimos una tabla con el rango
                    ExcelTable tab = worksheet.Tables.Add(range, "tabla");

                    //Formateamos la tabla
                    tab.TableStyle = TableStyles.Medium2;

                    //Le damos espacio entre columnas
                    worksheet.Cells.AutoFitColumns();

                    //Creo un memorystream
                    using (var memoryStream = new MemoryStream())
                    {
                        //Tipo de contenido del stream. XMLS en este caso
                        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        //Cabezera del archivo
                        Response.AddHeader("content-disposition", "attachment; filename= informe.xlsx");
                        //Guardamos el documento como memory stream
                        excel.SaveAs(memoryStream);
                        //Escribimos el stream en la respuesta del navegador
                        memoryStream.WriteTo(Response.OutputStream);
                        //Vaciamos y eliminamos la respuesta por seguridad
                        Response.Flush();
                        Response.End();
                    }
                }

                if (respuesta.tipoRespuesta != TipoRespuesta.OK)
                {
                    return View("Error");
                }
            }
            //return View("_resultados");
            return View(informe_VM);
        }
        public ActionResult prueba(Informe_VM informe_VM)
        {
            int moneda_pk = informe_VM.operaciones.Moneda_PK;
            int fechaMovimiento = informe_VM.movimientoSemana;

            Thread.Sleep(1500);

            //Creamos una lista que rellenaremos
            List<Moneda> listaMonedas = new List<Moneda>();
            Func_Monedas.recuperarListaMonedas(listaMonedas);
            informe_VM.listaMonedas = listaMonedas;

            //Creamos una lista que rellenaremos y asignaremos al ViewModel
            List<TiposOperaciones> listaTiposOperaciones = new List<TiposOperaciones>();
            Func_Monedas.recuperarListaTiposOperaciones(listaTiposOperaciones);
            informe_VM.listaTipoOperacion = listaTiposOperaciones;

            //Rellenamos la lista de operaciones en el ViewModel
            List<Operaciones> listaOperaciones = new List<Operaciones>();
            Func_Monedas.recuperarListaOperaciones(listaOperaciones, moneda_pk, fechaMovimiento);
            informe_VM.listaOperaciones = listaOperaciones;

            return PartialView("_resultados", informe_VM);
        }

        public JsonResult RecuperarFechaCreacion(int id = 0, int moneda_PK = 0)
        {
            DateTime fechaCreacion = Func_Monedas.recuperarFechaCreacion(id);

            if (fechaCreacion == DateTime.MinValue)
            {
                return Json(new { status = "KO" });
            }

            return Json(new { status = "OK", fechaCreacionObtenida = fechaCreacion.ToShortDateString() }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult RecuperarListaMonedas()
        {
            List<Moneda> listaMonedas = new List<Moneda>();
            Func_Monedas.recuperarListaMonedas(listaMonedas);

            JsonConvert.SerializeObject(listaMonedas);

            return Json(new { status = "OK", listaMonedas = listaMonedas }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult RecuperarListaMonedas2()
        {
            Informe_VM informe_VM = new Informe_VM();

            //Creamos una lista que rellenaremos
            List<Moneda> listaMonedas = new List<Moneda>();
            Func_Monedas.recuperarListaMonedas(listaMonedas);
            informe_VM.listaMonedas = listaMonedas;

            string vista = PartialView("~/Views/_VistasInfo/_DropdownMonedas.cshtml", informe_VM).RenderToString();

            return Json(new { status = "OK", vista = vista });

            //return PartialView("~/Views/_VistasInfo/_DropdownMonedas.cshtml", informe_VM);
        }
        public JsonResult RecuperarOperacionCompleta(int operacion_pk=0)
        {
            Operaciones operacion = new Operaciones();

            Respuesta respuesta = new Respuesta();

            respuesta = Func_Monedas.recuperarOperacion(operacion, operacion_pk);

            string modalOperacion = PartialView("~/Views/Informe/_DatosOperacion.cshtml", operacion).RenderToString();

            if (respuesta.tipoRespuesta != TipoRespuesta.OK)
            {
                return Json(new { status = "KO" });
            }
            return Json(new { status = "OK", modalOperacion = modalOperacion });
        }
    }
}