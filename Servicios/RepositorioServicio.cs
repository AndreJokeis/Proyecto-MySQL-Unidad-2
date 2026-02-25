using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller_Mecanico.Objetos;

namespace Taller_Mecanico.Servicios
{
    public class RepositorioServicio
    {
        /// <summary>
        /// Este método hace uso de un procedimiento almacenado en MySQL para buscar todas las refacciones en la tabla
        /// de Servicios.
        /// </summary>
        /// <returns>Regresa un <c>List<Servicio></c> con la lista de todas los Servicios</returns>
        public List<Servicio> ObtenerServicios()
        {
            List<Servicio> listaServicios = new List<Servicio>();
            using (MySqlConnection connection = new SQL().ObtenerConexion())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("get_servicios", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Servicio servicio = new Servicio(
                                Convert.ToInt32(reader["idServicio"]),
                                reader["NombreServicio"].ToString(),
                                reader["Descripcion"].ToString(),
                                Convert.ToDecimal(reader["Costo"]),
                                Convert.ToDecimal(reader["TiempoEstimado"])
                            );
                            listaServicios.Add(servicio);
                        }

                        return listaServicios;
                    }
                }
                catch (Exception ex)
                {
                    return listaServicios;
                }
            }
        }

        /// <summary>
        /// Este método hace uso de un procedimiento almacenado que agrega un Servicio en la tabla de la BD
        /// </summary>
        /// <param name="servicio">Recibe un objeto <c>Servicio</c></param>
        /// <returns>Regresa un <c>int</c> con la cantidad de filas modificadas</returns>
        public int agregarServicio(Servicio servicio)
        {
            using (MySqlConnection connection = new SQL().ObtenerConexion())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("add_servicio", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@nNombreServicio", servicio.nombreServicio);
                    cmd.Parameters.AddWithValue("@nDescripcion", servicio.descripcion);
                    cmd.Parameters.AddWithValue("@nCosto", servicio.costo);
                    cmd.Parameters.AddWithValue("@nTiempoEstimado", servicio.tiempoEstimado);
                    int result = cmd.ExecuteNonQuery();

                    return result;
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Este método se encarga de actualizar los datos de un servicio ya existente.
        /// </summary>
        /// <param name="servicio">Recibe el objeto ya existente que se desea modificar</param>
        /// <returns>Regresa un <c>int</c> con la cantidad de filas modificadas</returns>
        public int actualizarServicio(Servicio servicio)
        {
            using (MySqlConnection connection = new SQL().ObtenerConexion())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("edit_servicios", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", servicio.idServicio);
                    cmd.Parameters.AddWithValue("@nNombreServicio", servicio.nombreServicio);
                    cmd.Parameters.AddWithValue("@nDescripcion", servicio.descripcion);
                    cmd.Parameters.AddWithValue("@nCosto", servicio.costo);
                    cmd.Parameters.AddWithValue("@nTiempoEstimado", servicio.tiempoEstimado);

                    int result = cmd.ExecuteNonQuery();

                    return result;
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Esté método se encarga de borrar físicamente un servicio en la BD
        /// </summary>
        /// <param name="id">Recibe en id del Servicio a borrar</param>
        /// <returns>Regresa un <c>int</c> con la cantidad de filas modificadas</returns>
        public int borrarServicio(int id)
        {
            using (MySqlConnection connection = new SQL().ObtenerConexion())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("delete_servicio", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", id);

                    int result = cmd.ExecuteNonQuery();

                    return result;
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
        }
    }
}
