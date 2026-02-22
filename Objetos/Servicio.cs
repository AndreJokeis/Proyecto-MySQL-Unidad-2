using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_Mecanico.Objetos
{
    public class Servicio
    {
        int idServicio { get; set; }
        string NombreServicio { get; set; }
        string Descripcion { get; set; }
        decimal Costo { get; set; }
        decimal TiempoEstimado { get; set; }
    }
}
