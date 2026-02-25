using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taller_Mecanico.Servicios;

namespace Taller_Mecanico.Objetos
{
    public class RepostiorioRefaccion
    {

        /// <summary>
        /// Este método hace uso de un procedimiento almacenado en MySQL el cual busca una refacción por id.
        /// </summary>
        /// <param name="id">ID de la refacción a buscar</param>
        /// <returns>Objeto <c>refacción</c> que se desea</returns>
        public Refaccion obtenerRefaccion(int id)
        {
            using (MySqlConnection connection = new SQL().ObtenerConexion())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("get_refaccion", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        Refaccion refaccion;

                        while (reader.Read())
                        {
                            refaccion = new Refaccion(
                                Convert.ToInt32(reader["idRefaccion"]),
                                reader["Nombre"].ToString(),
                                reader["Marca"].ToString(),
                                Convert.ToDecimal(reader["PrecioUnitario"]),
                                Convert.ToInt32(reader["Stock"]),
                                Convert.ToInt32(reader["StockMinimo"]),
                                reader["Proveedor"].ToString()
                            );

                            return refaccion;

                        }

                        return null;
                    }

                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Este método hace uso de un procedimiento almacenado en MySQL para buscar todas las refacciones en la tabla
        /// de refacciones
        /// </summary>
        /// <returns>Regresa un <c>List<Refaccion></c> con la lista de todas las refacciones</returns>
        public List<Refaccion> ObtenerRefacciones()
        {
            List<Refaccion> listaRefacciones = new List<Refaccion>();
            using (MySqlConnection connection = new SQL().ObtenerConexion())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("get_refacciones", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Refaccion refaccion = new Refaccion(
                                Convert.ToInt32(reader["idRefaccion"]),
                                reader["Nombre"].ToString(),
                                reader["Marca"].ToString(),
                                Convert.ToDecimal(reader["PrecioUnitario"]),
                                Convert.ToInt32(reader["Stock"]),
                                Convert.ToInt32(reader["StockMinimo"]),
                                reader["Proveedor"].ToString()
                            );
                            listaRefacciones.Add(refaccion);
                        }

                        return listaRefacciones;
                    }
                }
                catch (Exception ex)
                {
                    return listaRefacciones;
                }
            }
        }


        /// <summary>
        /// Este método hace uso de un procedimiento almacenado que agrega una Refacción en la tabla de la BD
        /// </summary>
        /// <param name="refaccion">Recibe un objeto <c>Refacción</c></param>
        /// <returns>Regresa un <c>int</c> con la cantidad de filas modificadas</returns>
        public int agregarRefaccion(Refaccion refaccion)
        {
            using (MySqlConnection connection = new SQL().ObtenerConexion())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("add_refaccion", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@nNombre", refaccion.nombre);
                    cmd.Parameters.AddWithValue("@nMarca", refaccion.marca);
                    cmd.Parameters.AddWithValue("@nPrecioUnitario", refaccion.precioUnitario);
                    cmd.Parameters.AddWithValue("@nStock", refaccion.stock);
                    cmd.Parameters.AddWithValue("@nStockMinimo", refaccion.stockMinimo);
                    cmd.Parameters.AddWithValue("@nProveedor", refaccion.proveedor);

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
        /// Este método se encarga de actualizar los datos de una refacción ya existente
        /// </summary>
        /// <param name="refaccion">Recibe el objeto ya existente que se desea modificar</param>
        /// <returns>Regresa un <c>int</c> con la cantidad de filas modificadas</returns>
        public int actualizarRefaccion(Refaccion refaccion)
        {
            using (MySqlConnection connection = new SQL().ObtenerConexion())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("edit_refaccion", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", refaccion.idRefaccion);
                    cmd.Parameters.AddWithValue("@nNombre", refaccion.nombre);
                    cmd.Parameters.AddWithValue("@nMarca", refaccion.marca);
                    cmd.Parameters.AddWithValue("@nPrecioUnitario", refaccion.precioUnitario);
                    cmd.Parameters.AddWithValue("@nStock", refaccion.stock);
                    cmd.Parameters.AddWithValue("@nStockMinimo", refaccion.stockMinimo);
                    cmd.Parameters.AddWithValue("@nProveedor", refaccion.proveedor);

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
        /// Esté método se encarga de borrar físicamente una refacción en la BD
        /// </summary>
        /// <param name="id">Recibe en id de la Refafacción a borrar</param>
        /// <returns>Regresa un <c>int</c> con la cantidad de filas modificadas</returns>
        public int borrarRefaccion(int id)
        {
            using (MySqlConnection connection = new SQL().ObtenerConexion())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("delete_refacciones", connection);
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
