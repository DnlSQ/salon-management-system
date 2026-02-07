using AccesoDatosSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea2;
using System.Data.SqlClient;

namespace Negocio
{
    public class Logica
    {
        #region Autenticacion y Aurorizacion

        /// <summary>
        /// Metodo para validar la autenticacion de un usuario 
        /// </summary>
        /// <param name="P_Entidad">Entidad Tipo Usuario</param>
        /// <returns>Entidad tipo usuario</returns>
        public static Usuario Autenticacion(Usuario P_Entidad)
        {
            SQLPeticion peticion = new SQLPeticion
            {
                Peticion = "EXEC PA_AUTENTICACION '" + P_Entidad.NUsuario + "','" + P_Entidad.Pass + "'",
                ListaParametros = new List<SqlParameter>()
            };

            AccesoSQL objacceso = new AccesoSQL();
            List<Usuario> resultado = objacceso.ConsultarT_usuario(peticion);

            return resultado.FirstOrDefault();

        }

        /// <summary>
        /// Metodo para validar la Autorizacion de un usuario autenticado
        /// </summary>
        /// <param name="P_Entidad">Entidad Tipo Usuario</param>
        /// <returns>Entidad lista tipo perfil</returns>
        public static List<Perfil> Autorizacion(Usuario P_Entidad)
        {
            SQLPeticion peticion = new SQLPeticion
            {
                Peticion = "EXEC PA_AUTORIZACION '" + P_Entidad.NUsuario + "'",
                ListaParametros = new List<SqlParameter>()
            };

            AccesoSQL objacceso = new AccesoSQL();
            return objacceso.ConsultarUsuario(peticion);

        }

        #endregion

        #region Perfil
        public static void VerificarConexion()
        {
            try
            {
                AccesoSQL objacceso = new AccesoSQL();

            }
            catch (Exception ex)
            {
                throw ex;

            }


        }

        /// <summary>
        /// Metodo para agregar un usuario en base de datos
        /// </summary>
        /// <param name="P_Entidad"></param>
        /// <returns></returns>
        public static bool AgregarCodigo(Perfil P_Entidad)
        {

            try
            {
                //Aqui se establece la peticion a ejecutar
                SQLPeticion objpeticion = new SQLPeticion
                {
                    Peticion = @"EXEC PA_AgregarCodigo " + P_Entidad.ID_Codigo + ",'" + P_Entidad.Descripcion + "','" + P_Entidad.FechaCreacion.ToString("dd/MM/yyyy hh:mm:ss") + "','" + P_Entidad.Estado + "'",
                    ListaParametros = new List<System.Data.SqlClient.SqlParameter>()
                };
                //Ejecuta acceso a datos
                AccesoSQL objacceso = new AccesoSQL();
                return objacceso.EjecutarPeticion(objpeticion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// Metodo para modificar un usuario en base de datos
        /// </summary>
        /// <param name="P_Entidad"></param>
        /// <returns></returns>
        public static bool ModificarCodigo(Perfil P_Entidad)
        {

            try
            {
                //Aqui se establece la peticion a ejecutar
                SQLPeticion objpeticion = new SQLPeticion
                {
                    Peticion = @"EXEC PA_ModificarCodigo " + P_Entidad.ID_Codigo + ",'" + P_Entidad.Descripcion + "','" + P_Entidad.FechaCreacion.ToString("dd/MM/yyyy hh:mm:ss") + "','" + P_Entidad.Estado + "'",
                    ListaParametros = new List<System.Data.SqlClient.SqlParameter>()
                };
                //Ejecuta acceso a datos
                AccesoSQL objacceso = new AccesoSQL();
                return objacceso.EjecutarPeticion(objpeticion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// Metodo para eliminar un usuario en base de datos
        /// </summary>
        /// <param name="P_Entidad"></param>
        /// <returns></returns>
        public static bool EliminarCodigo(Perfil P_Entidad)
        {

            try
            {
                //Aqui se establece la peticion a ejecutar
                SQLPeticion objpeticion = new SQLPeticion
                {
                    Peticion = @"EXEC PA_EliminarCodigo " + P_Entidad.ID_Codigo,
                    ListaParametros = new List<System.Data.SqlClient.SqlParameter>()
                };
                //Ejecuta acceso a datos
                AccesoSQL objacceso = new AccesoSQL();
                return objacceso.EjecutarPeticion(objpeticion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// Metodo para consultar un usuario en base de datos
        /// </summary>
        /// <param name="P_Entidad"></param>
        /// <returns></returns>
        public static List<Perfil> ConsultarCodigo(Perfil P_Entidad)
        {

            try
            {
                //Aqui se establece la peticion a ejecutar
                SQLPeticion objpeticion = new SQLPeticion
                {
                    Peticion = @"EXEC PA_ConsultarCodigo " + P_Entidad.ID_Codigo,
                    ListaParametros = new List<System.Data.SqlClient.SqlParameter>()
                };
                //Ejecuta acceso a datos
                AccesoSQL objacceso = new AccesoSQL();
                return objacceso.ConsultarUsuario(objpeticion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        #endregion

        #region Cliente

        public static List<Cliente> ConsultarCliente(Cliente P_entidad)
        {
            try
            {
                //Aqui se establece la peticion a ejecutar 
                SQLPeticion objpeticion = new SQLPeticion
                {
                    Peticion = @"EXEC PA_ConsultarCliente '" + P_entidad.IDCliente + "'"
                };
                // Ejecuta contra AccesoDatos
                AccesoSQL objacceso = new AccesoSQL();
                return objacceso.ConsultarCliente(objpeticion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static bool AgregarCliente(Cliente P_entidad)
        {
            try
            {
                //Aqui se establece la peticion a ejecutar 
                SQLPeticion objpeticion = new SQLPeticion
                {
                    Peticion = @"EXEC PA_AgregarCliente " + P_entidad.C_Nombre + ",'" + P_entidad.C_Apellidos + "','" + P_entidad.C_Telefono + "','" + P_entidad.Email + "','" + P_entidad.TipoCedula + "','" + P_entidad.NumeroCedula + "'"
                };
                // Ejecuta contra AccesoDatos
                AccesoSQL objacceso = new AccesoSQL();
                return objacceso.EjecutarPeticion(objpeticion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static bool ModificarCliente(Cliente P_entidad)
        {
            try
            {
                //Aqui se establece la peticion a ejecutar 
                SQLPeticion objpeticion = new SQLPeticion
                {
                    Peticion = @"EXEC PA_ModificarCliente " + P_entidad.IDCliente + "," + P_entidad.C_Nombre + ",'" + P_entidad.C_Apellidos + "','" + P_entidad.C_Telefono + "','" + P_entidad.Email + "','" + P_entidad.TipoCedula + "','" + P_entidad.NumeroCedula + "'"
                };
                // Ejecuta contra AccesoDatos
                AccesoSQL objacceso = new AccesoSQL();
                return objacceso.EjecutarPeticion(objpeticion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static bool EliminarCliente(Cliente P_entidad)
        {
            try
            {
                //Aqui se establece la peticion a ejecutar 
                SQLPeticion objpeticion = new SQLPeticion
                {
                    Peticion = @"EXEC PA_EliminarCliente '" + P_entidad.IDCliente + "'"
                };
                // Ejecuta contra AccesoDatos
                AccesoSQL objacceso = new AccesoSQL();
                return objacceso.EjecutarPeticion(objpeticion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        #endregion

        #region Inventario

        public static List<Inventario> ConsultarInventario(Inventario P_entidad)
        {
            try
            {
                //Aqui se establece la peticion a ejecutar 
                SQLPeticion objpeticion = new SQLPeticion
                {
                    Peticion = @"EXEC PA_ConsultarInventario '" + P_entidad.IDInventario + "'"
                };
                // Ejecuta contra AccesoDatos
                AccesoSQL objacceso = new AccesoSQL();
                return objacceso.ConsultarInventario(objpeticion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static bool AgregarInventario(Inventario P_entidad)
        {
            try
            {
                //Aqui se establece la peticion a ejecutar 
                SQLPeticion objpeticion = new SQLPeticion
                {
                    Peticion = @"EXEC PA_AgregarInventario '" + P_entidad.I_Nombre + "', " + P_entidad.Cantidad + ", '" + P_entidad.UnidadMedida + "', '" + P_entidad.Descripcion + "', " + P_entidad.ProveedorId

                };
                // Ejecuta contra AccesoDatos
                AccesoSQL objacceso = new AccesoSQL();
                return objacceso.EjecutarPeticion(objpeticion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static bool ModificarInventario(Inventario P_entidad)
        {
            try
            {
                //Aqui se establece la peticion a ejecutar 
                SQLPeticion objpeticion = new SQLPeticion
                {
                    Peticion = @"EXEC PA_ModificarInventario " + P_entidad.IDInventario + ", '" + P_entidad.I_Nombre + "', " + P_entidad.Cantidad + ", '" + P_entidad.UnidadMedida + "', '" + P_entidad.Descripcion + "', " + P_entidad.ProveedorId

                };
                // Ejecuta contra AccesoDatos
                AccesoSQL objacceso = new AccesoSQL();
                return objacceso.EjecutarPeticion(objpeticion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static bool EliminarInventario(Inventario P_entidad)
        {
            try
            {
                //Aqui se establece la peticion a ejecutar 
                SQLPeticion objpeticion = new SQLPeticion
                {
                    Peticion = @"EXEC PA_EliminarInventario '" + P_entidad.IDInventario + "'"
                };
                // Ejecuta contra AccesoDatos
                AccesoSQL objacceso = new AccesoSQL();
                return objacceso.EjecutarPeticion(objpeticion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion

        #region Provedores

        public static List<Proveedor> ConsultarProveedor(Proveedor P_entidad)
        {
            try
            {
                //Aqui se establece la peticion a ejecutar 
                SQLPeticion objpeticion = new SQLPeticion
                {
                    Peticion = @"EXEC PA_ConsultarProveedor '" + P_entidad.IDProveedor + "'"
                };
                // Ejecuta contra AccesoDatos
                AccesoSQL objacceso = new AccesoSQL();
                return objacceso.ConsultarProveedor(objpeticion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static bool AgregarProveedor(Proveedor P_entidad)
        {
            try
            {
                //Aqui se establece la peticion a ejecutar 
                SQLPeticion objpeticion = new SQLPeticion
                {
                    Peticion = @"EXEC PA_AgregarProveedor '" + P_entidad.P_Nombre + "', '" + P_entidad.Descripcion + "', '" + P_entidad.Telefono + "'"


                };
                // Ejecuta contra AccesoDatos
                AccesoSQL objacceso = new AccesoSQL();
                return objacceso.EjecutarPeticion(objpeticion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static bool ModificarProveedor(Proveedor P_entidad)
        {
            try
            {
                //Aqui se establece la peticion a ejecutar 
                SQLPeticion objpeticion = new SQLPeticion
                {
                    Peticion = @"EXEC PA_ModificarProveedor " + P_entidad.IDProveedor + ", '" + P_entidad.P_Nombre + "', '" + P_entidad.Descripcion + "', '" + P_entidad.Telefono + "'"

                };
                // Ejecuta contra AccesoDatos
                AccesoSQL objacceso = new AccesoSQL();
                return objacceso.EjecutarPeticion(objpeticion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static bool EliminarProveedor(Proveedor P_entidad)
        {
            try
            {
                //Aqui se establece la peticion a ejecutar 
                SQLPeticion objpeticion = new SQLPeticion
                {
                    Peticion = @"EXEC PA_EliminarProveedor '" + P_entidad.IDProveedor + "'"
                };
                // Ejecuta contra AccesoDatos
                AccesoSQL objacceso = new AccesoSQL();
                return objacceso.EjecutarPeticion(objpeticion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion

        #region Servicios
        public static List<Servicios> ConsultarServicio(Servicios P_entidad)
        {
            try
            {
                //Aqui se establece la peticion a ejecutar 
                SQLPeticion objpeticion = new SQLPeticion
                {
                    Peticion = @"EXEC PA_ConsultarServicio '" + P_entidad.IDServicio + "'"
                };
                // Ejecuta contra AccesoDatos
                AccesoSQL objacceso = new AccesoSQL();
                return objacceso.ConsultarServicio(objpeticion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static bool AgregarServicio(Servicios P_entidad)
        {
            try
            {
                //Aqui se establece la peticion a ejecutar 
                SQLPeticion objpeticion = new SQLPeticion
                {
                    Peticion = @"EXEC PA_AgregarServicio '" + P_entidad.S_Nombre + "', '" + P_entidad.Descripcion + "', '" + P_entidad.Duracion + "'"


                };
                // Ejecuta contra AccesoDatos
                AccesoSQL objacceso = new AccesoSQL();
                return objacceso.EjecutarPeticion(objpeticion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static bool ModificarServicio(Servicios P_entidad)
        {
            try
            {
                //Aqui se establece la peticion a ejecutar 
                SQLPeticion objpeticion = new SQLPeticion
                {
                    Peticion = @"EXEC PA_ModificarServicio " + P_entidad.IDServicio + ", '" + P_entidad.S_Nombre + "', '" + P_entidad.Descripcion + "', '" + P_entidad.Duracion + "'"

                };
                // Ejecuta contra AccesoDatos
                AccesoSQL objacceso = new AccesoSQL();
                return objacceso.EjecutarPeticion(objpeticion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static bool EliminarServicio(Servicios P_entidad)
        {
            try
            {
                //Aqui se establece la peticion a ejecutar 
                SQLPeticion objpeticion = new SQLPeticion
                {
                    Peticion = @"EXEC PA_EliminarServicio '" + P_entidad.IDServicio + "'"
                };
                // Ejecuta contra AccesoDatos
                AccesoSQL objacceso = new AccesoSQL();
                return objacceso.EjecutarPeticion(objpeticion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion

        #region Usuario

        public static List<Usuario> ConsultarUsuarioC(Usuario P_entidad)
        {
            try
            {
                //Aqui se establece la peticion a ejecutar 
                SQLPeticion objpeticion = new SQLPeticion
                {
                    Peticion = @"EXEC PA_ConsultarUsuario '" + P_entidad.IDUsuario + "'"
                };
                // Ejecuta contra AccesoDatos
                AccesoSQL objacceso = new AccesoSQL();
                return objacceso.ConsultarUsuarioC(objpeticion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static bool AgregarUsuario(Usuario P_entidad)
        {
            try
            {
                //Aqui se establece la peticion a ejecutar 
                SQLPeticion objpeticion = new SQLPeticion
                {
                    Peticion = @"EXEC PA_AgregarUsuario " + P_entidad.IDUsuario + ", '" + P_entidad.NUsuario + "', '" + P_entidad.Pass + "', '" + P_entidad.Fecha + "', " + (P_entidad.Activo ? "1" : "0") + ", " + (P_entidad.Bloqueo ? "1" : "0") + ", '" + P_entidad.U_Nombre + "', '" + P_entidad.U_Apellido + "', '" + P_entidad.U_Telefono + "', '" + P_entidad.U_Email + "', '" + P_entidad.TCedula + "', '" + P_entidad.Cedula + "'"


                };
                // Ejecuta contra AccesoDatos
                AccesoSQL objacceso = new AccesoSQL();
                return objacceso.EjecutarPeticion(objpeticion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static bool ModificarUsuario(Usuario P_entidad)
        {
            try
            {
                //Aqui se establece la peticion a ejecutar 
                SQLPeticion objpeticion = new SQLPeticion
                {
                    Peticion = @"EXEC PA_ModificarUsuario " + P_entidad.IDUsuario + ",'" + P_entidad.NUsuario + "', '" + P_entidad.Pass + "', '" + P_entidad.Fecha + "', " + (P_entidad.Activo ? "1" : "0") + ", " + (P_entidad.Bloqueo ? "1" : "0") + ", '" + P_entidad.U_Nombre + "', '" + P_entidad.U_Apellido + "', '" + P_entidad.U_Telefono + "', '" + P_entidad.U_Email + "', '" + P_entidad.TCedula + "', '" + P_entidad.Cedula + "'"

                };
                // Ejecuta contra AccesoDatos
                AccesoSQL objacceso = new AccesoSQL();
                return objacceso.EjecutarPeticion(objpeticion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static bool EliminarUsuario(Usuario P_entidad)
        {
            try
            {
                //Aqui se establece la peticion a ejecutar 
                SQLPeticion objpeticion = new SQLPeticion
                {
                    Peticion = @"EXEC PA_EliminarUsuario '" + P_entidad.IDUsuario + "'"
                };
                // Ejecuta contra AccesoDatos
                AccesoSQL objacceso = new AccesoSQL();
                return objacceso.EjecutarPeticion(objpeticion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }




        #endregion

        #region UsuarioXPerfil
        public static List<UsuarioporPerfil> ConsultarUsuarioXPerfil(UsuarioporPerfil P_entidad)
        {
            try
            {
                //Aqui se establece la peticion a ejecutar 
                SQLPeticion objpeticion = new SQLPeticion
                {
                    Peticion = @"EXEC PA_ConsultarUsuarioPorPerfil '" + P_entidad.UsuarioId + "'"
                };
                // Ejecuta contra AccesoDatos
                AccesoSQL objacceso = new AccesoSQL();
                return objacceso.ConsultarUsuarioXPerfil(objpeticion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static bool AgregarUsuarioXPerfil(UsuarioporPerfil P_entidad)
        {
            try
            {
                //Aqui se establece la peticion a ejecutar 
                SQLPeticion objpeticion = new SQLPeticion
                {
                    Peticion = @"EXEC PA_AgregarUsuarioPorPerfil " + P_entidad.UsuarioId + ", '" + P_entidad.Usuario + "', " + P_entidad.CodPerfil + ", '" + P_entidad.FechaAsociacion + "'"


                };
                // Ejecuta contra AccesoDatos
                AccesoSQL objacceso = new AccesoSQL();
                return objacceso.EjecutarPeticion(objpeticion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static bool ModificarUsuarioXPerfil(UsuarioporPerfil P_entidad)
        {
            try
            {
                //Aqui se establece la peticion a ejecutar 
                SQLPeticion objpeticion = new SQLPeticion
                {
                    Peticion = @"EXEC PA_ModificarUsuarioPorPerfil " + P_entidad.UsuarioId + ", '" + P_entidad.Usuario + "', " + P_entidad.CodPerfil + ", '" + P_entidad.FechaAsociacion + "'"

                };
                // Ejecuta contra AccesoDatos
                AccesoSQL objacceso = new AccesoSQL();
                return objacceso.EjecutarPeticion(objpeticion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static bool EliminarUsuarioXPerfil(UsuarioporPerfil P_entidad)
        {
            try
            {
                //Aqui se establece la peticion a ejecutar 
                SQLPeticion objpeticion = new SQLPeticion
                {
                    Peticion = @"EXEC PA_EliminarUsuarioPorPerfil '" + P_entidad.UsuarioId + "'"
                };
                // Ejecuta contra AccesoDatos
                AccesoSQL objacceso = new AccesoSQL();
                return objacceso.EjecutarPeticion(objpeticion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        #endregion

        #region ServicioInventario
        public static List<ConsultaSxI> CSXI(ConsultaSxI P_entidad)
        {
            try
            {
                //Aqui se establece la peticion a ejecutar 
                SQLPeticion objpeticion = new SQLPeticion
                {
                    Peticion = @"EXEC PA_ConsultarSxI '" + P_entidad.IDServicioInventario + "'"
                };
                // Ejecuta contra AccesoDatos
                AccesoSQL objacceso = new AccesoSQL();
                return objacceso.CSXI(objpeticion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static bool AgregarSXI(ServicioInventario P_entidad)
        {
            try
            {
                //Aqui se establece la peticion a ejecutar 
                SQLPeticion objpeticion = new SQLPeticion
                {
                    Peticion = @"EXEC PA_AgregarServicioInventario " + P_entidad.IDServicio + ", " + P_entidad.IDInventario + ", " + P_entidad.CantidadUsada


                };
                // Ejecuta contra AccesoDatos
                AccesoSQL objacceso = new AccesoSQL();
                return objacceso.EjecutarPeticion(objpeticion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static bool ModificarSXI(ServicioInventario P_entidad)
        {
            try
            {
                //Aqui se establece la peticion a ejecutar 
                SQLPeticion objpeticion = new SQLPeticion
                {
                    Peticion = @"EXEC PA_ModificarServicioInventario " + P_entidad.IDServicioInventario + ", " + P_entidad.IDServicio + ", " + P_entidad.IDInventario + ", " + P_entidad.CantidadUsada

                };
                // Ejecuta contra AccesoDatos
                AccesoSQL objacceso = new AccesoSQL();
                return objacceso.EjecutarPeticion(objpeticion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static bool EliminarSXI(ServicioInventario P_entidad)
        {
            try
            {
                //Aqui se establece la peticion a ejecutar 
                SQLPeticion objpeticion = new SQLPeticion
                {
                    Peticion = @"EXEC PA_EliminarServicioInventario '" + P_entidad.IDServicioInventario + "'"
                };
                // Ejecuta contra AccesoDatos
                AccesoSQL objacceso = new AccesoSQL();
                return objacceso.EjecutarPeticion(objpeticion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        #endregion

        #region Citas
        public static List<Cita> ConsultarCitas(Cita P_entidad)
        {
            try
            {
                //Aqui se establece la peticion a ejecutar 
                SQLPeticion objpeticion = new SQLPeticion
                {
                    Peticion = @"EXEC PA_ConsultarCita '" + P_entidad.IDCita + "'"
                };
                // Ejecuta contra AccesoDatos
                AccesoSQL objacceso = new AccesoSQL();
                return objacceso.ConsultarCita(objpeticion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static bool AgregarCitas(Cita P_entidad)
        {
            try
            {
                //Aqui se establece la peticion a ejecutar 
                SQLPeticion objpeticion = new SQLPeticion
                {
                    Peticion = @"EXEC PA_AgregarCita " + P_entidad.ClienteId + ", '" + P_entidad.NombreCliente + "', " + P_entidad.EmpleadoId + ", '" + P_entidad.NombreEmpleado + "', " + P_entidad.ServicioId + ", '" + P_entidad.NombreServicio + "', '" + P_entidad.Fecha.ToString("yyyy-MM-dd") + "', '" +  P_entidad.Hora.ToString(@"hh\:mm") + "', '" +  P_entidad.Notas + "'"

                };
                // Ejecuta contra AccesoDatos
                AccesoSQL objacceso = new AccesoSQL();
                return objacceso.EjecutarPeticion(objpeticion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static bool ModificarCitas(Cita P_entidad)
        {
            try
            {
                //Aqui se establece la peticion a ejecutar 
                SQLPeticion objpeticion = new SQLPeticion
                {
                    Peticion = @"EXEC PA_ModificarCita " + P_entidad.IDCita + ", " + P_entidad.ClienteId + ", '" + P_entidad.NombreCliente + "', " + P_entidad.EmpleadoId + ", '" + P_entidad.NombreEmpleado + "', " + P_entidad.ServicioId + ", '" + P_entidad.NombreServicio + "', '" + P_entidad.Fecha.ToString("yyyy-MM-dd") + "', '" + P_entidad.Hora.ToString(@"hh\:mm") + "', '" + P_entidad.Notas + "'"
                };
                // Ejecuta contra AccesoDatos
                AccesoSQL objacceso = new AccesoSQL();
                return objacceso.EjecutarPeticion(objpeticion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static bool EliminarCitas(Cita P_entidad)
        {
            try
            {
                //Aqui se establece la peticion a ejecutar 
                SQLPeticion objpeticion = new SQLPeticion
                {
                    Peticion = @"EXEC PA_EliminarCita '" + P_entidad.IDCita + "'"
                };
                // Ejecuta contra AccesoDatos
                AccesoSQL objacceso = new AccesoSQL();
                return objacceso.EjecutarPeticion(objpeticion);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion

    }

}
