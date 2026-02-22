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
