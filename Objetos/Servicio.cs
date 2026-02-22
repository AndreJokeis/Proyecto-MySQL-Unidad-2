using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_Mecanico.Objetos
{
    public class Servicio
    {
        public int idServicio { get; set; }
        public string nombreServicio { get; set; }
        public string descripcion { get; set; }
        public decimal costo { get; set; }
        public decimal tiempoEstimado { get; set; }

        public Servicio(int idServicio, string NombreServicio, string Descripcion, decimal Costo, decimal TiempoEstimado)
        {
            this.idServicio = idServicio;
            this.nombreServicio = NombreServicio;
            this.descripcion = Descripcion;
            this.costo = Costo;
            this.tiempoEstimado = TiempoEstimado;
        }

        public Servicio(string NombreServicio, string Descripcion, decimal Costo, decimal TiempoEstimado)
        {
            this.nombreServicio = NombreServicio;
            this.descripcion = Descripcion;
            this.costo = Costo;
            this.tiempoEstimado = TiempoEstimado;
        }

        public override string ToString()
        {
            return this.idServicio + "\n" +
                this.nombreServicio + "\n" +
                this.descripcion + "\n" +
                this.tiempoEstimado;
        }
    }

}
    
