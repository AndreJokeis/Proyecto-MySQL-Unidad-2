using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_Mecanico.Objetos
{
    public class Refaccion
    {
        public int idRefaccion { get; set; }
        public string nombre { get; set; }
        public string marca { get; set; }
        public decimal precioUnitario { get; set; }
        public int stock { get; set; }
        public int stockMinimo { get; set; }
        public string proveedor { get; set; }

        public Refaccion(string nombre, string marca, decimal precioUnitario, int stock, int stockMinimo, string proveedor)
        {
            this.nombre = nombre;
            this.marca = marca;
            this.precioUnitario = precioUnitario;
            this.stock = stock;
            this.stockMinimo = stockMinimo;
            this.proveedor = proveedor;
        }
        public Refaccion(int idRefaccion, string nombre, string marca, decimal precioUnitario, int stock, int stockMinimo, string proveedor)
        {
            this.idRefaccion = idRefaccion;
            this.nombre = nombre;
            this.marca = marca;
            this.precioUnitario = precioUnitario;
            this.stock = stock;
            this.stockMinimo = stockMinimo;
            this.proveedor = proveedor;
        }

        public override string ToString()
        {
            return this.idRefaccion + "\n" +
                this.nombre + "\n" +
                this.marca + "\n" +
                this.precioUnitario + "\n" +
                this.stock + "\n" +
                this.stockMinimo + "\n" +
                this.proveedor;
        }
    }
}
