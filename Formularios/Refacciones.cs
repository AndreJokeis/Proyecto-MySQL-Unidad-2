using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taller_Mecanico.Objetos;

namespace Taller_Mecanico.Formularios
{
    public partial class Refacciones : UserControl
    {
        private RepostiorioRefaccion repositorio= new RepostiorioRefaccion();

        private Refaccion refaccion;

        private int id = -1;
        private bool registrar = true;

        public Refacciones()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtMarca.Text) ||
                string.IsNullOrWhiteSpace(txtPrecioUnitario.Text) ||
                string.IsNullOrWhiteSpace(txtProveedor.Text) ||
                string.IsNullOrWhiteSpace(nudStock.Text) ||
                string.IsNullOrWhiteSpace(nudStockMinimo.Text)) 
            {
                MessageBox.Show("Rellene todos los datos");
            } else if (!punto(txtPrecioUnitario.Text))
            {
                    MessageBox.Show("Ingrese un precio válido");
            }
            else
            {
                decimal stock = nudStock.Value;
                decimal stockMinimo = nudStockMinimo.Value;

                if (stock < 1 || stockMinimo < 1)
                    MessageBox.Show("Stock y Stock mínimo deben de ser mayores a 0");
                else if (nudStock.Value < nudStockMinimo.Value)
                    MessageBox.Show("El stock es menor al mínimo");

                else
                {
                    refaccion = new Refaccion(
                    txtNombre.Text,
                    txtMarca.Text,
                    decimal.Parse(txtPrecioUnitario.Text),
                    int.Parse(nudStock.Text),
                    int.Parse(nudStockMinimo.Text),
                    txtProveedor.Text
                );

                    if (registrar)
                    {
                        if (repositorio.agregarRefaccion(refaccion) >= 1)
                        {
                            MessageBox.Show("La refaccion se agregó correctamente");

                            limpiarCampos();
                            llenarLista();
                        }
                        else
                        {
                            MessageBox.Show("Ocurrió un error al agregar la refacción");
                        }
                    }
                    else
                    {
                        refaccion.idRefaccion = id;
                        if (repositorio.actualizarRefaccion(refaccion) >= 1)
                        {
                            MessageBox.Show("La refaccion se editó correctamente");

                            limpiarCampos();
                            llenarLista();
                        }
                        else
                        {
                            MessageBox.Show("Ocurrió un error al agregar la refacción");
                        }
                    }
                }
            }
        }

        private void Refacciones_Load(object sender, EventArgs e)
        {
            llenarLista();

            btnBorrar.Enabled = false;
        }
        private void llenarLista()
        {
            dgvLista.DataSource = null;
            dgvLista.DataSource = repositorio.ObtenerRefacciones();
        }

        private bool punto(string s)
        {
            int count = 0;

            foreach(char c in s)
            {
                if(c == '.')
                    if (count < 1)
                        count++;
                    else
                        return false;
            }

            return true;
        }

        private void limpiarCampos()
        {
            txtNombre.Text = "";
            txtMarca.Text = "";
            txtPrecioUnitario.Text = "";
            nudStock.Text = "";
            nudStockMinimo.Text = "";
            txtProveedor.Text = "";

            id = -1;
            btnRegistrar.Text = "Registrar";
            registrar = true;
            btnBorrar.Enabled = false;
        }

        private void dgvLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dgvLista.Rows[e.RowIndex];
            id = int.Parse(fila.Cells[0].Value.ToString());
            registrar = false;

            limpiarCampos();

            btnRegistrar.Text = "Actualizar";

            txtNombre.Text = fila.Cells[1].Value.ToString();
            txtMarca.Text = fila.Cells[2].Value.ToString();
            txtPrecioUnitario.Text = fila.Cells[3].Value.ToString();
            nudStock.Text = fila.Cells[4].Value.ToString();
            nudStockMinimo.Text = fila.Cells[5].Value.ToString();
            txtProveedor.Text = fila.Cells[6].Value.ToString();
        }

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dgvLista.Rows[e.RowIndex];
            id = int.Parse(fila.Cells[0].Value.ToString());

            btnBorrar.Enabled = true;

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (id >= 0)
            {
                if (repositorio.borrarRefaccion(id) >= 1)
                {
                    MessageBox.Show("La refacción se eliminó correctamente");
                    llenarLista();
                    limpiarCampos();
                }
                else
                    MessageBox.Show("Ocurrió un error al eliminar la refacción");
            } 
        }

        private void txtPrecioUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
        }
    }
}
