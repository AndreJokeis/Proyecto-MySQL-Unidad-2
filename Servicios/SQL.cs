using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_Mecanico.Servicios
{
    public class SQL
    {
        public static string cadena = ConfigurationManager.ConnectionStrings["cadena_conexion"].ToString();

        /// <summary>
        /// Este método se encarga de obtener la conexión y establecerla con la BD
        /// </summary>
        /// <returns>Regresa la conexión ya establecida</returns>
        /// <exception cref="Exception"></exception>
        public MySqlConnection ObtenerConexion()
        {
            MySqlConnection conexion = new MySqlConnection(cadena);
            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                {
                    conexion.Open();
                }
            }
            catch (Exception ex)
            {
                conexion.Close();
                throw new Exception("Error al conectar con la Base de Datos: " + ex.Message);
            }

            return conexion;
        }

    }
}
