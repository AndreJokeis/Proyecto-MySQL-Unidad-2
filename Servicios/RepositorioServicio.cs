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
