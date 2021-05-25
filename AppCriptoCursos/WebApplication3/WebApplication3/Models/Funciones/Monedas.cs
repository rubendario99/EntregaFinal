using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models.Clases;
using WebApplication3.Models.ViewModels;

namespace WebApplication3.Models.Funciones
{
    public class Func_Monedas
    {
        static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
        static public Respuesta recuperarListaMonedas(List<Moneda> listaMonedas, bool recuperarNoActivo = true)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);

            //Creo un log
            Func_Comunes.GuardarLog("Se listan las monedas en el index");

            //Creamos el objeto respuesta
            Respuesta respuesta = new Respuesta();
            respuesta.tipoRespuesta = TipoRespuesta.OK;

            //Creo un string con la consulta que realizaré

            string sql;

            if (recuperarNoActivo)
            {
                sql = "select * from Monedas";
            }
            else
            {
                sql = "select * from Monedas where activa=1";
            }



            //SqlDataAdapter sirve como puente entre el programa y la base de datos
            //El primer parámetro es la consulta y el segundo la conexión
            SqlDataAdapter adapt = new SqlDataAdapter(sql, connection);

            //DataTable permite almacenar los datos de la consulta como una tabla de BD
            //Representa una tabla con filas y columnas
            DataTable datos = new DataTable();

            try
            {
                //Adapt contiene la consulta que realizamos
                //Con Fill(), metemos los datos de esa consulta en un DataTable
                adapt.Fill(datos);
            }
            catch (Exception e)
            {
                respuesta.tipoRespuesta = TipoRespuesta.KO;
                respuesta.error = e.Message;
                throw;
            }

            //Como el DataTable tiene los datos en filas y columnas
            //Tenemos que recorrer esos datos para encontrar los que necesitemos
            //DataRow representa las filas en DataTable
            foreach (DataRow row in datos.Rows)
            {
                Moneda moneda = new Moneda()
                {
                    //Importante hacer las conversiones pertinentes
                    Moneda_PK = (int)row["Moneda_PK"],
                    Nombre = row["Nombre"].ToString(),
                    Favorita = (bool)row["Favorita"],
                    Cambio = (decimal)row["Cambio"],
                    Activa = (bool)row["Activa"],
                    FechaCreacion = (DateTime)row["FechaCreacion"]
                };
                listaMonedas.Add(moneda);
            }

            return respuesta;
        }
        static public Respuesta recuperarMoneda(Moneda moneda, int id)
        {
            //Creamos el objeto respuesta
            Respuesta respuesta = new Respuesta();
            respuesta.tipoRespuesta = TipoRespuesta.OK;

            //Creo un log
            Func_Comunes.GuardarLog("Se recupera la moneda " + id);

            //Creo un string de la consulta
            string sql = "select * from Monedas where Moneda_pk =" + id + ";";

            //Creo el adaptador con la conexión y consulta
            SqlDataAdapter adapt = new SqlDataAdapter(sql, connection);

            //Creo el DataTable para volcar los datos de la consulta
            DataTable datos = new DataTable();

            try
            {
                //Relleno el DataTable
                adapt.Fill(datos);
            }
            catch (Exception)
            {
                throw;
            }

            //Como el DataTable tiene los datos en filas y columnas
            //Tenemos que recorrer esos datos para encontrar los que necesitemos
            //DataRow representa las filas en DataTable
            foreach (DataRow row in datos.Rows)
            {

                moneda.Moneda_PK = (int)row["Moneda_PK"];
                moneda.Nombre = row["Nombre"].ToString();
                moneda.Favorita = (bool)row["Favorita"];
                moneda.Cambio = (decimal)row["Cambio"];
                moneda.Activa = (bool)row["Activa"];
                moneda.FechaCreacion = (DateTime)row["FechaCreacion"];
            }
            //Devolvemos el modelo que utilizará la vista
            return respuesta;
        }
        static public Respuesta editarMoneda(Moneda moneda)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);

            Respuesta respuesta = new Respuesta();
            respuesta.tipoRespuesta = TipoRespuesta.OK;

            Func_Comunes.GuardarLog("Se edita la moneda " + moneda.Nombre);

            SqlCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = "update dbo.Monedas set Nombre=@nombre, Favorita=@favorita, Cambio=@cambio, Activa=@activa, FechaCreacion=@fechaCreacion where Moneda_PK = @moneda_pk";
            command.Parameters.AddWithValue("@moneda_pk", moneda.Moneda_PK);
            command.Parameters.AddWithValue("@nombre", moneda.Nombre);
            command.Parameters.AddWithValue("@favorita", moneda.Favorita);
            command.Parameters.AddWithValue("@cambio", moneda.Cambio);
            command.Parameters.AddWithValue("@activa", moneda.Activa);
            command.Parameters.AddWithValue("@fechaCreacion", moneda.FechaCreacion);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                connection.Close();
                respuesta.tipoRespuesta = TipoRespuesta.KO;
            }
            connection.Close();
            return respuesta;
        }
        static public Respuesta crearMoneda(Moneda moneda)
        {

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);

            //Creamos el objeto respuesta
            Respuesta respuesta = new Respuesta();

            //Rellenamos algunos datos por default
            respuesta.tipoRespuesta = TipoRespuesta.OK;
            respuesta.error = string.Empty;

            //Creamos el log
            Func_Comunes.GuardarLog("Se crea la moneda" + moneda.Nombre);

            //Creamos el command al que le asociaremos la consulta
            SqlCommand command = connection.CreateCommand();

            //String con la consulta
            string sql = "select count (*) from dbo.Monedas where nombre = '" + moneda.Nombre.Trim() + "'";

            //Comprobando que no se repita el nombre
            command.CommandText = sql;

            //Int para comprobación
            int resultado = 0;

            connection.Open();
            try
            {
                //ExecuteScalar devuelve la primera columna solo
                //Por tanto el return puede ser 0 o 1
                resultado = (int)command.ExecuteScalar();
            }
            catch (Exception e)
            {
                //Importante cerrar siempre las conexiones
                connection.Close();
                //Respuesta KO si salta excepción
                respuesta.tipoRespuesta = TipoRespuesta.KO;
                respuesta.error = "Error: " + e.Message;

            }
            connection.Close();

            //Si hay monedas con ese nombre ya, la consulta será mas de 0
            //Por tanto entrará en el IF
            if (resultado > 0)
            {
                respuesta.error = "La moneda " + moneda.Nombre.ToUpper() + " ya existe en la BD. utiliza otro nombre";
            }
            else
            {
                //Creamos un procedimiento
                connection.Open();
                command.CommandText = "insert into dbo.Monedas (Nombre,Favorita,Cambio,Activa) values (@nombre,@favorita,@cambio,@activa)";
                command.Parameters.AddWithValue("@nombre", moneda.Nombre);
                command.Parameters.AddWithValue("@favorita", moneda.Favorita);
                command.Parameters.AddWithValue("@cambio", moneda.Cambio);
                command.Parameters.AddWithValue("@activa", moneda.Activa);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    connection.Close();
                    respuesta.tipoRespuesta = TipoRespuesta.KO;
                }
                connection.Close();
            }
            return respuesta;
        }
        static public Respuesta borrrarMoneda(int id)
        {
            SqlCommand command = connection.CreateCommand();

            Func_Comunes.GuardarLog("Se borra la moneda" + id);

            Respuesta respuesta = new Respuesta();
            respuesta.tipoRespuesta = TipoRespuesta.OK;
            string sql = "delete dbo.Monedas where Moneda_PK = " + id;
            command.CommandText = sql;

            connection.Open();
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                connection.Close();
                respuesta.tipoRespuesta = TipoRespuesta.KO;
                respuesta.error = e.Message;
            }
            connection.Close();
            return respuesta;
        }
        static public Respuesta recuperarListaTiposOperaciones(List<TiposOperaciones> listaTiposOperaciones, bool recuperarNoActivo = true)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);

            Respuesta respuesta = new Respuesta();
            respuesta.tipoRespuesta = TipoRespuesta.OK;

            Func_Comunes.GuardarLog("Se recuperan los tipos de operaciones");

            string sql;

            if (recuperarNoActivo)
            {
                sql = "select * from TiposOperaciones";
            }
            else
            {
                sql = "select * from TiposOperaciones where activo=1";
            }

            SqlDataAdapter adapt = new SqlDataAdapter(sql, connection);
            DataTable datos = new DataTable();
            try
            {
                adapt.Fill(datos);
            }
            catch (Exception)
            {
                throw;
            }

            foreach (DataRow row in datos.Rows)
            {
                TiposOperaciones tiposOperaciones = new TiposOperaciones()
                {
                    TipoOperacion_PK = (int)row["tipoOperacion_pk"],
                    Nombre = row["Nombre"].ToString(),
                    Activo = (bool)row["Activo"],
                };
                listaTiposOperaciones.Add(tiposOperaciones);
            }
            return respuesta;
        }
        static public decimal recuperarTasasCambio(int id = 0)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);

            decimal tasaCambio = 0;

            if (id == 0)
            {
                return tasaCambio;
            }

            Func_Comunes.GuardarLog("Se recuperan las tasas de cambio");
            string sql = "select cambio from Monedas where Moneda_PK=" + id;
            SqlDataAdapter adapt = new SqlDataAdapter(sql, connection);
            DataTable datos = new DataTable();
            try
            {
                adapt.Fill(datos);
            }
            catch (Exception e)
            {
                Func_Comunes.GuardarLog("Exception " + e.Message);
                throw;
            }
            foreach (DataRow row in datos.Rows)
            {
                tasaCambio = (decimal)row["cambio"];
            }
            return tasaCambio;
        }
        static public DateTime recuperarFechaCreacion(int id = 0)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);

            DateTime fechaCreacion = DateTime.MinValue;

            Func_Comunes.GuardarLog("Se recuperan la fecha de creación");
            string sql = "select FechaCreacion from Monedas where Moneda_PK=" + id;
            SqlDataAdapter adapt = new SqlDataAdapter(sql, connection);
            DataTable datos = new DataTable();

            if (id == 0)
            {
                return fechaCreacion;
            }

            try
            {
                adapt.Fill(datos);
            }
            catch (Exception e)
            {
                Func_Comunes.GuardarLog("Exception " + e.Message);
                throw;
            }
            foreach (DataRow row in datos.Rows)
            {
                fechaCreacion = (DateTime)row["FechaCreacion"];
            }
            return fechaCreacion;
        }
        static public Respuesta crearTransaccion(RegistrarOperaciones_VM registrarOperaciones)
        {
            //Command para crear procedimientos
            SqlCommand command = connection.CreateCommand();

            //Creo respuesta y asigno valores default
            Respuesta respuesta = new Respuesta();
            respuesta.tipoRespuesta = TipoRespuesta.OK;

            //Creamos el log
            Func_Comunes.GuardarLog("Creamos una transacción");

            //Creo la tasa de cambio a aplicar
            decimal tasaCambio = 1 / recuperarTasasCambio(registrarOperaciones.operaciones.Moneda_PK);

            //Calculo las monedas recibidas según la tasaCambio y el importe €
            decimal numMonedas = registrarOperaciones.operaciones.Importe * tasaCambio;

            //La fecha de creación de la transacción la establezco a hoy
            DateTime fechaCreacion = DateTime.Now;

            //Juntamos fecha y hora para crear un DateTime
            string fecha = registrarOperaciones.fecha;
            string hora = registrarOperaciones.hora;
            //Convertimos el string a DateTime
            DateTime fechaOperacion = Convert.ToDateTime(fecha + " " + hora);

            //Abrimos conexión y ejecutamos consulta
            connection.Open();
            command.CommandText = "insert into dbo.Operaciones (Moneda_PK,TipoOperacion_PK,FechaOperacion,Importe,NumMonedas,FechaCreacion) " +
                                  "values (@Moneda_PK,@TipoOperacion_PK,@FechaOperacion,@Importe,@NumMonedas,@FechaCreacion);";

            //Añadimos los parámetros que usará el procedimiento
            command.Parameters.AddWithValue("@Moneda_PK", registrarOperaciones.operaciones.Moneda_PK);
            command.Parameters.AddWithValue("@TipoOperacion_PK", registrarOperaciones.operaciones.TipoOperacion_PK);
            command.Parameters.AddWithValue("@FechaOperacion", fechaOperacion);
            command.Parameters.AddWithValue("@Importe", registrarOperaciones.operaciones.Importe);
            command.Parameters.AddWithValue("@NumMonedas", numMonedas);
            command.Parameters.AddWithValue("@FechaCreacion", fechaCreacion);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                connection.Close();
                respuesta.tipoRespuesta = TipoRespuesta.KO;
            }
            connection.Close();

            return respuesta;
        }
        static public Respuesta recuperarListaOperaciones(List<Operaciones> listaOperaciones)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);

            Respuesta respuesta = new Respuesta();
            respuesta.tipoRespuesta = TipoRespuesta.OK;

            Func_Comunes.GuardarLog("Se recuperan las operaciones");
            string sql = "select * from Operaciones";
            SqlDataAdapter adapt = new SqlDataAdapter(sql, connection);
            DataTable datos = new DataTable();
            try
            {
                adapt.Fill(datos);
            }
            catch (Exception e)
            {
                respuesta.tipoRespuesta = TipoRespuesta.KO;
                respuesta.error = e.Message;
                throw;
            }

            foreach (DataRow row in datos.Rows)
            {
                Operaciones operaciones = new Operaciones()
                {
                    Operacion_PK = (int)row["Operacion_PK"],
                    Moneda_PK = (int)row["Moneda_PK"],
                    TipoOperacion_PK = (int)row["TipoOperacion_PK"],
                    FechaOperacion = (DateTime)row["FechaOperacion"],
                    Importe = (decimal)row["Importe"],
                    NumMonedas = (decimal)row["NumMonedas"],
                    FechaCreacion = (DateTime)row["FechaCreacion"],
                };
                listaOperaciones.Add(operaciones);
            }

            return respuesta;
        }
        static public Respuesta recuperarOperacion(Operaciones operacion, int operacion_pk)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);

            Respuesta respuesta = new Respuesta();
            respuesta.tipoRespuesta = TipoRespuesta.OK;

            Func_Comunes.GuardarLog("Se recuperan la operacion");
            string sql = "select * from Operaciones where operacion_pk=" + operacion_pk;
            SqlDataAdapter adapt = new SqlDataAdapter(sql, connection);
            DataTable datos = new DataTable();
            try
            {
                adapt.Fill(datos);
            }
            catch (Exception e)
            {
                respuesta.tipoRespuesta = TipoRespuesta.KO;
                respuesta.error = e.Message;
                throw;
            }

            foreach (DataRow row in datos.Rows)
            {
                operacion.Operacion_PK = (int)row["Operacion_PK"];
                operacion.Moneda_PK = (int)row["Moneda_PK"];
                operacion.TipoOperacion_PK = (int)row["TipoOperacion_PK"];
                operacion.Importe = (decimal)row["Importe"];
                operacion.NumMonedas = (decimal)row["NumMonedas"];
                operacion.FechaCreacion = (DateTime)row["FechaCreacion"];
                operacion.FechaOperacion = (DateTime)row["FechaOperacion"];

            }
            return respuesta;
        }
        static public Respuesta recuperarListaOperaciones(List<Operaciones> listaOperaciones, int id = 0, int fechaMovimiento = 0)
        {

            Respuesta respuesta = new Respuesta();
            respuesta.tipoRespuesta = TipoRespuesta.OK;
            DateTime date = DateTime.Now;

            if (id == 4)
            {
                date = date.AddMonths(-1);
            }
            else
            {
                date = date.AddDays(-7 * fechaMovimiento);
            }
            string sql = "select * from operaciones";

            Func_Comunes.GuardarLog("Se recuperan las operaciones");

            if (id > 0)
            {
                sql += " where moneda_pk =" + id;
                if (fechaMovimiento != 0)
                {
                    sql += " and fechaOperacion >=" + "'" + date + "'";
                }
            }
            else
            {
                if (fechaMovimiento != 0)
                {
                    sql += "  where fechaOperacion>= " + "'" + date + "'";
                }
            }

            SqlDataAdapter adapt = new SqlDataAdapter(sql, connection);
            DataTable datos = new DataTable();
            try
            {
                adapt.Fill(datos);
            }
            catch (Exception e)
            {
                respuesta.tipoRespuesta = TipoRespuesta.KO;
                respuesta.error = e.Message;
                throw;
            }
            foreach (DataRow row in datos.Rows)
            {
                Operaciones operaciones = new Operaciones()
                {
                    Operacion_PK = (int)row["Operacion_PK"],
                    Moneda_PK = (int)row["Moneda_PK"],
                    TipoOperacion_PK = (int)row["TipoOperacion_PK"],
                    FechaOperacion = (DateTime)row["FechaOperacion"],
                    Importe = (decimal)row["Importe"],
                    NumMonedas = (decimal)row["NumMonedas"],
                    FechaCreacion = (DateTime)row["FechaCreacion"],
                };
                listaOperaciones.Add(operaciones);
            }

            return respuesta;
        }
        static public Respuesta recuperarListaMovimientos(List<SelectListItem> listaMovimientos)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.tipoRespuesta = TipoRespuesta.OK;

            listaMovimientos.Add(new SelectListItem { Value = "0", Text = "Todos" });
            listaMovimientos.Add(new SelectListItem { Value = "1", Text = "1 semana" });
            listaMovimientos.Add(new SelectListItem { Value = "2", Text = "2 semanas" });
            listaMovimientos.Add(new SelectListItem { Value = "3", Text = "3 semanas" });
            listaMovimientos.Add(new SelectListItem { Value = "4", Text = "1 mes" });

            return respuesta;
        }
        static public Respuesta recuperarDatosExcel(DataTable datos, int id = 0, int fechaMovimiento = 0)
        {
            //Respuesta
            Respuesta respuesta = new Respuesta();
            respuesta.tipoRespuesta = TipoRespuesta.OK;

            Func_Comunes.GuardarLog("Se recuperan los datos para el excel");

            DateTime date = DateTime.Now;

            //String con los join 
            string sql = "select Monedas.Nombre,TiposOperaciones.Nombre as Operacion,Operaciones.NumMonedas as Monedas,Operaciones.Importe,Operaciones.FechaOperacion from operaciones " +
                "join Monedas on Monedas.Moneda_PK= Operaciones.Moneda_PK join TiposOperaciones on Operaciones.TipoOperacion_PK=TiposOperaciones.TipoOperacion_PK";

            if (id == 4)
            {
                date = date.AddMonths(-1);
            }
            else
            {
                date = date.AddDays(-7 * fechaMovimiento);
            }

            if (id > 0)
            {
                sql += " where Monedas.Moneda_PK =" + id;
                if (fechaMovimiento != 0)
                {
                    sql += " and fechaOperacion >= " + "'" + date + "'";
                }
            }
            else
            {
                if (fechaMovimiento != 0)
                {
                    sql += "  where fechaOperacion>= " + "'" + date + "'";
                }
            }

            SqlDataAdapter adapt = new SqlDataAdapter(sql, connection);

            try
            {
                adapt.Fill(datos);
            }
            catch (Exception e)
            {
                respuesta.tipoRespuesta = TipoRespuesta.KO;
                respuesta.error = e.Message;
                throw;
            }
            return respuesta;
        }
    }
}