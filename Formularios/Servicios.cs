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
using Taller_Mecanico.Servicios;

namespace Taller_Mecanico.Formularios
{
    public partial class Servicios : UserControl
    {
        private RepositorioServicio repositorio = new RepositorioServicio();

        private Servicio servicio;

        private int id = -1;
        private bool registrar = true;

        public Servicios()
        {
            InitializeComponent();
        }

        private void llenarLista()
        {
            dgvLista.DataSource = null;
            dgvLista.DataSource = repositorio.ObtenerServicios();
        }

        private void limpiarCampos()
        {
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtCosto.Text = "";
            txtTiempoEstimado.Text = "";

            id = -1;
            btnRegistrar.Text = "Registrar";
            registrar = true;
            btnBorrar.Enabled = false;
        }

        private bool punto(string s)
        {
            int count = 0;

            foreach (char c in s)
            {
                if (c == '.')
                    if (count < 1)
                        count++;
                    else
                        return false;
            }

            return true;
        }

        private void Servicios_Load(object sender, EventArgs e)
        {
            llenarLista();

            btnBorrar.Enabled = false;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                string.IsNullOrWhiteSpace(txtCosto.Text) ||
                string.IsNullOrWhiteSpace(txtTiempoEstimado.Text)
                ) MessageBox.Show("Rellene todos los datos");
            else if(!punto(txtCosto.Text))
                MessageBox.Show("El costo no es válido");
            else
            {
                decimal costo = decimal.Parse(txtCosto.Text);
                decimal tiempo = decimal.Parse(txtTiempoEstimado.Text);
                if (costo < 1 || tiempo < 1 )
                    MessageBox.Show("El costo y el tiempo estimado deben ser mayores a 0");
                else
                {
                    servicio = new Servicio(
                    txtNombre.Text,
                    txtDescripcion.Text,
                    costo,
                    tiempo
                );

                    if (registrar)
                    {
                        if (repositorio.agregarServicio(servicio) >= 1)
                        {
                            MessageBox.Show("El servicio se agregó correctamente");
                            limpiarCampos();
                            llenarLista();
                        }
                        else
                        {
                            MessageBox.Show("Ocurrió un error al agregar el servicio(");
                        }
                    }
                    else
                    {
                        servicio.idServicio = id;
                        if (repositorio.actualizarServicio(servicio) >= 1)
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

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dgvLista.Rows[e.RowIndex];
            id = int.Parse(fila.Cells[0].Value.ToString());

            btnBorrar.Enabled = true;
        }

        private void dgvLista_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dgvLista.Rows[e.RowIndex];
            id = int.Parse(fila.Cells[0].Value.ToString());
            registrar = false;

            limpiarCampos();

            btnRegistrar.Text = "Actualizar";

            txtNombre.Text = fila.Cells[1].Value.ToString();
            txtDescripcion.Text = fila.Cells[2].Value.ToString();
            txtCosto.Text = fila.Cells[3].Value.ToString();
            txtTiempoEstimado.Text = fila.Cells[4].Value.ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (id >= 0)
            {
                if (repositorio.borrarServicio(id) >= 1)
                {
                    MessageBox.Show("El servivio se eliminó correctamente");
                    llenarLista();
                    limpiarCampos();
                }
                else
                    MessageBox.Show("Ocurrió un error al eliminar el servicio");
            }
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
        }
    }
}
