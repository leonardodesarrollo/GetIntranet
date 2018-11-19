using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace DAL
{
    public class Datos
    {
        Database db = DatabaseFactory.CreateDatabase();

        public DataSet getBuscarUsuario(string idUsuario, string usuario, string password, string activo)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_buscarUsuario");
            db.AddInParameter(cmd, "@idUsuario", DbType.String, idUsuario);
            db.AddInParameter(cmd, "@usuario", DbType.String, usuario);
            db.AddInParameter(cmd, "@password", DbType.String, password);
            db.AddInParameter(cmd, "@activo", DbType.String, activo);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar el usuario, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar el usuario, " + ex.Message, ex);
            }
        }

        public DataSet SetInUsuario(int IdUsuario, string Usuario, string Nombre, string Telefono,
            string Email, string Fotografia, int? IdSucursal, int? IdCargo, int? IdPerfil,
            string Password, int Activo)
        {
            DbCommand cmd = db.GetStoredProcCommand("usp_USUARIOInsert");
            db.AddInParameter(cmd, "@IdUsuario", DbType.String, IdUsuario);
            db.AddInParameter(cmd, "@Usuario", DbType.String, Usuario);
            db.AddInParameter(cmd, "@Nombre", DbType.String, Nombre);
            db.AddInParameter(cmd, "@Telefono", DbType.String, Telefono);
            db.AddInParameter(cmd, "@Email", DbType.String, Email);
            db.AddInParameter(cmd, "@Fotografia", DbType.String, Fotografia);
            db.AddInParameter(cmd, "@IdSucursal", DbType.String, IdSucursal);
            db.AddInParameter(cmd, "@IdCargo", DbType.String, IdCargo);
            db.AddInParameter(cmd, "@IdPerfil", DbType.String, IdPerfil);
            db.AddInParameter(cmd, "@Password", DbType.String, Password);
            db.AddInParameter(cmd, "@Activo", DbType.String, Activo);
            db.AddInParameter(cmd, "@FechaCreacion", DbType.String, null);
            db.AddInParameter(cmd, "@FechaModificacion", DbType.String, null);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo ingresar el usuario, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo ingresar el usuario, " + ex.Message, ex);
            }
        }

        public DataSet SetUpUsuario(int IdUsuario, string Usuario, string Nombre, string Telefono,
            string Email, string Fotografia, int? IdSucursal, int? IdCargo, int? IdPerfil,
            string Password, int Activo)
        {
            DbCommand cmd = db.GetStoredProcCommand("usp_USUARIOUpdate");
            db.AddInParameter(cmd, "@IdUsuario", DbType.String, IdUsuario);
            db.AddInParameter(cmd, "@Usuario", DbType.String, Usuario);
            db.AddInParameter(cmd, "@Nombre", DbType.String, Nombre);
            db.AddInParameter(cmd, "@Telefono", DbType.String, Telefono);
            db.AddInParameter(cmd, "@Email", DbType.String, Email);
            db.AddInParameter(cmd, "@Fotografia", DbType.String, Fotografia);
            db.AddInParameter(cmd, "@IdSucursal", DbType.String, IdSucursal);
            db.AddInParameter(cmd, "@IdCargo", DbType.String, IdCargo);
            db.AddInParameter(cmd, "@IdPerfil", DbType.String, IdPerfil);
            db.AddInParameter(cmd, "@Password", DbType.String, Password);
            db.AddInParameter(cmd, "@Activo", DbType.String, Activo);
            db.AddInParameter(cmd, "@FechaCreacion", DbType.String, null);
            db.AddInParameter(cmd, "@FechaModificacion", DbType.String, null);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo ingresar el usuario, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo ingresar el usuario, " + ex.Message, ex);
            }
        }
        
        public void SetDelUsuario(int IdUsuario)
        {
            DbCommand cmd = db.GetStoredProcCommand("usp_USUARIODelete");
            db.AddInParameter(cmd, "@IdUsuario", DbType.String, IdUsuario);

            try
            {
                db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo eliminar el usuario, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar el usuario, " + ex.Message, ex);
            }
        }

        public DataSet GetBuscarSucursal(int? IdSucursal)
        {
            DbCommand cmd = db.GetStoredProcCommand("usp_SUCURSALSelect");
            db.AddInParameter(cmd, "@IdSucursal", DbType.String, IdSucursal);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar la sucursal, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar la sucursal, " + ex.Message, ex);
            }
        }


        public DataSet GetBuscarPerfil(int? IdPerfil)
        {
            DbCommand cmd = db.GetStoredProcCommand("usp_PERFILSelect");
            db.AddInParameter(cmd, "@IdPerfil", DbType.String, IdPerfil);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar, " + ex.Message, ex);
            }
        }


        public DataSet GetBuscarCargo(int? IdCargo)
        {
            DbCommand cmd = db.GetStoredProcCommand("usp_CARGOSelect");
            db.AddInParameter(cmd, "@IdCargo", DbType.String, IdCargo);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar, " + ex.Message, ex);
            }
        }


        public DataSet getBuscarSeccionHijo(string idSeccionPadre)
        {

            DbCommand cmd = db.GetStoredProcCommand("stp_buscarSeccionHijo");
            db.AddInParameter(cmd, "@idSeccion", DbType.String, idSeccionPadre);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar la sección, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar la sección, " + ex.Message, ex);
            }

        }


        public DataSet getBuscarSeccion(string nombre)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_buscarSeccion");
            db.AddInParameter(cmd, "@nombre", DbType.String, "%" + nombre + "%");

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar la sección, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar la sección, " + ex.Message, ex);
            }
        }


        public DataSet getBuscarNodoPorPerfil(string idPerfil)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_buscarNodosPorPerfil");
            db.AddInParameter(cmd, "@idPerfil", DbType.String, idPerfil);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar, " + ex.Message, ex);
            }
        }


        public DataSet getBuscarNodo()
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_buscarNodos");

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar la etiqueta, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar la etiqueta, " + ex.Message, ex);
            }
        }


        public void setEliminarSeccion(string idSeccion)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_eliminarSeccion");
            db.AddInParameter(cmd, "@idSeccion", DbType.String, idSeccion);
            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo eliminar la sección, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar la sección, " + ex.Message, ex);
            }
        }


        public void setModificarSeccion(string idSeccion, string nombre, string idObra, string idCliente, string ubicacionGeografica)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_modificarSeccion");
            db.AddInParameter(cmd, "@idSeccion", DbType.String, idSeccion);
            db.AddInParameter(cmd, "@nombre", DbType.String, nombre);
            if (idObra == "0")
            {
                db.AddInParameter(cmd, "@idObra", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@idObra", DbType.String, idObra);
            }
            if (idCliente == "0")
            {
                db.AddInParameter(cmd, "@idCliente", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@idCliente", DbType.String, idCliente);
            }

            db.AddInParameter(cmd, "@ubicacionGeografica", DbType.String, ubicacionGeografica);

            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se puede modificar la sección, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede modificar la sección, " + ex.Message, ex);
            }
        }


        public string getIngresarSeccion(string nombre, string idSeccionPadre, string idObra, string idCliente, string ubicacionGeografica, string idUsuario)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_ingresarSeccion");
            db.AddInParameter(cmd, "@nombre", DbType.String, nombre);
            db.AddInParameter(cmd, "@idSeccionPadre", DbType.String, idSeccionPadre);

            if (idObra == "0")
            {
                db.AddInParameter(cmd, "@idObra", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@idObra", DbType.String, idObra);
            }
            if (idCliente == "0")
            {
                db.AddInParameter(cmd, "@idCliente", DbType.String, null);
            }
            else
            {
                db.AddInParameter(cmd, "@idCliente", DbType.String, idCliente);
            }

            db.AddInParameter(cmd, "@ubicacionGeografica", DbType.String, ubicacionGeografica);
            db.AddInParameter(cmd, "@idUsuario", DbType.String, idUsuario);
            try
            {
                string valor = db.ExecuteScalar(cmd).ToString();
                return valor;
            }
            catch (SqlException ex)
            {
                throw new Exception("No se puede ingresar la sección, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede ingresar la sección, " + ex.Message, ex);
            }
        }


        public string getBuscarMaxIdSeccion()
        {
            string id = "";
            DbCommand cmd = db.GetStoredProcCommand("stp_buscarMaxIdSeccion");
            id = db.ExecuteScalar(cmd).ToString();
            return id;

        }

        public void setIngresarSeccionesPorPerfil(string IdPerfil, string idSeccion)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_IngresarSeccionesPorUsuario");
            db.AddInParameter(cmd, "@IdPerfil", DbType.String, IdPerfil);
            db.AddInParameter(cmd, "@idSeccion", DbType.String, idSeccion);

            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se puede ingresar la sección por perfil, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede ingresar la sección por usuario, " + ex.Message, ex);
            }
        }


        public void SetIngresarSeccionesPorPerfil(string idPerfil, string idSeccion)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_IngresarSeccionesPorPerfil");
            db.AddInParameter(cmd, "@idPerfil", DbType.String, idPerfil);
            db.AddInParameter(cmd, "@idSeccion", DbType.String, idSeccion);

            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se puede ingresar la sección por perfil, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede ingresar la sección por perfil, " + ex.Message, ex);
            }
        }

        public void SetIngresarSeccionesPorPerfilPermisoUpload(string idPerfil, string idSeccion)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_IngresarSeccionesPorPerfilPermisoUpload");
            db.AddInParameter(cmd, "@idPerfil", DbType.String, idPerfil);
            db.AddInParameter(cmd, "@idSeccion", DbType.String, idSeccion);

            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se puede ingresar la sección por perfil, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede ingresar la sección por perfil, " + ex.Message, ex);
            }
        }
        

        public void SetEliminarSeccionesPorPerfil(string idUsuario)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_EliminarSeccionesPorPerfil");
            db.AddInParameter(cmd, "@idUsuario", DbType.String, idUsuario);

            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se puede eliminar la sección por usuario, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede eliminar la sección por usuario, " + ex.Message, ex);
            }
        }

        public DataSet GetBuscarSeccionPorPerfilPorSeccion(string IdPerfil, string idSeccion)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_buscarSeccionPorPerfilPorSeccion");
            db.AddInParameter(cmd, "@idPerfil", DbType.String, IdPerfil);
            db.AddInParameter(cmd, "@idSeccion", DbType.String, idSeccion);
            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar la sección o usuario, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar la sección o usuario, " + ex.Message, ex);
            }
        }

        public DataSet GetBuscarSeccionPorPerfilPorSeccionPermisoUpload(string IdPerfil, string idSeccion)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_buscarSeccionPorPerfilPorSeccionPermisoUpload");
            db.AddInParameter(cmd, "@idPerfil", DbType.String, IdPerfil);
            db.AddInParameter(cmd, "@idSeccion", DbType.String, idSeccion);
            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar la sección o usuario, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar la sección o usuario, " + ex.Message, ex);
            }
        }

        // biblioteca
        public string SetIngresarBiblioteca(string idUsuario, string idTipoBiblioteca, string archivo, string ipHost, string ipLocal,
            string idCliente, string nombre, string descripcion, string email, string emailCC)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_IngresarBiblioteca");

            db.AddInParameter(cmd, "@idUsuario", DbType.String, idUsuario);
            db.AddInParameter(cmd, "@idTipoBiblioteca", DbType.String, idTipoBiblioteca);
            db.AddInParameter(cmd, "@archivo", DbType.String, archivo);
            db.AddInParameter(cmd, "@ipHost", DbType.String, ipHost);
            db.AddInParameter(cmd, "@ipLocal", DbType.String, ipLocal);
            db.AddInParameter(cmd, "@idCliente", DbType.String, idCliente);
            db.AddInParameter(cmd, "@nombre", DbType.String, nombre);
            db.AddInParameter(cmd, "@descripcion", DbType.String, descripcion);
            db.AddInParameter(cmd, "@email", DbType.String, email);
            db.AddInParameter(cmd, "@emailCC", DbType.String, emailCC);
            try
            {
                string valor;
                valor = db.ExecuteScalar(cmd).ToString();
                return valor;
                //db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo ingresar el archivo, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo ingresar el archivo, " + ex.Message, ex);
            }
        }



        public DataSet GetBuscarBibliotecaPorIdTipo(string idTipo)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_buscarBibliotecaPorIdTipo");

            db.AddInParameter(cmd, "@idTipo", DbType.String, idTipo);

            try
            {
                return db.ExecuteDataSet(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo buscar la biblioteca , " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo buscar la biblioteca , " + ex.Message, ex);
            }
        }


        public void SetIngresarLog(string ip, string idUsuario, string idArchivoSubido,
            string nombreArchivo, string fechaSubidad, string ruta)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_IngresarLog");
            db.AddInParameter(cmd, "@ip", DbType.String, ip);
            db.AddInParameter(cmd, "@idUsuario", DbType.String, idUsuario);
            db.AddInParameter(cmd, "@idArchivoSubido", DbType.String, idArchivoSubido);
            db.AddInParameter(cmd, "@nombreArchivo", DbType.String, nombreArchivo);
            db.AddInParameter(cmd, "@fechaSubidad", DbType.String, fechaSubidad);
            db.AddInParameter(cmd, "@ruta", DbType.String, ruta);

            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se puede ingresar el log, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede ingresar el log, " + ex.Message, ex);
            }
        }


        public void SetEliminarArchivoBiblioteca(string idArchivo)
        {
            DbCommand cmd = db.GetStoredProcCommand("stp_EliminarArchivoBiblioteca");
            db.AddInParameter(cmd, "@idArchivo", DbType.String, idArchivo);

            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo eliminar el archivo, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar el archivo, " + ex.Message, ex);
            }
        }



        public void SetEliminarPerfil(int id)
        {
            DbCommand cmd = db.GetStoredProcCommand("usp_PERFILDelete");
            db.AddInParameter(cmd, "@IdPerfil", DbType.String, id);

            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo eliminar el perfil, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo eliminar el perfils, " + ex.Message, ex);
            }
        }


        public void SetIngresarPerfil(int Id, string Perfil)
        {
            DbCommand cmd = db.GetStoredProcCommand("usp_PERFILInsert");
            db.AddInParameter(cmd, "@IdPerfil", DbType.String, Id);
            db.AddInParameter(cmd, "@Perfil", DbType.String, Perfil);

            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se puede ingresar el perfil, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede ingresar el perfil, " + ex.Message, ex);
            }
        }


        public void SetEditarPerfil(int IdPerfil, string Perfil)
        {
            DbCommand cmd = db.GetStoredProcCommand("usp_PERFILUpdate");
            db.AddInParameter(cmd, "@IdPerfil", DbType.String, IdPerfil);
            db.AddInParameter(cmd, "@Perfil", DbType.String, Perfil);
            
            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (SqlException ex)
            {
                throw new Exception("No se puede modificar el perfil, " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede modificar el perfil, " + ex.Message, ex);
            }
        }

    }
}
