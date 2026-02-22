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
        private RepostiorioRefaccion repostiorioRefaccion = new RepostiorioRefaccion();

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
            }
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
                    if (repostiorioRefaccion.agregarRefaccion(refaccion) >= 1)
                    {
                        MessageBox.Show("La refaccion se agregó correctamente");
                        txtNombre.Text = "";
                        txtMarca.Text = "";
                        txtPrecioUnitario.Text = "";
                        nudStock.Text = "";
                        nudStockMinimo.Text = "";
                        txtProveedor.Text = "";

                        llenarLista();
                        id = -1;
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al agregar la refacción(" +
                            repostiorioRefaccion.agregarRefaccion(refaccion) +
                            ")\n" + refaccion);
                    }
                } else
                {
                    refaccion.idRefaccion = id;
                    if (repostiorioRefaccion.actualizarRefaccion(refaccion) >= 1)
                    {
                        MessageBox.Show("La refaccion se editó correctamente");
                        txtNombre.Text = "";
                        txtMarca.Text = "";
                        txtPrecioUnitario.Text = "";
                        nudStock.Text = "";
                        nudStockMinimo.Text = "";
                        txtProveedor.Text = "";

                        btnRegistrar.Text = "Registrar";
                        registrar = true;

                        llenarLista();
                        id = -1;
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al agregar la refacción(" +
                            repostiorioRefaccion.agregarRefaccion(refaccion) +
                            ")\n" + refaccion);
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
            dgvLista.DataSource = repostiorioRefaccion.ObtenerRefacciones();
        }

        private void limpiarCampos()
        {
            txtNombre.Text = "";
            txtMarca.Text = "";
            txtPrecioUnitario.Text = "";
            nudStock.Text = "";
            nudStockMinimo.Text = "";
            txtProveedor.Text = "";
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

            MessageBox.Show("" + id);

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
                if (repostiorioRefaccion.borrarRefaccion(id) >= 1)
                {
                    MessageBox.Show("La refacción se eliminó correctamente");
                    btnBorrar.Enabled = false;
                    id = -1;
                    llenarLista();
                    limpiarCampos();
                }
                else
                    MessageBox.Show("Ocurrió un error al eliminar la refacción");
            } 
        }
    }
}
