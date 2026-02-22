using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taller_Mecanico.Formularios
{
    public partial class FormMenu : Form
    {
        Refacciones refacciones;

        string estado = "refacciones";

        public FormMenu()
        {
            InitializeComponent();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            refacciones = new Refacciones();
            pnlContenedor.Controls.Add(refacciones);
        }

        private void btnRefacciones_Click(object sender, EventArgs e)
        {
            if(estado != "refacciones")
            {
                pnlContenedor.Controls.Clear();
                refacciones = new Refacciones();
                pnlContenedor.Controls.Add(refacciones);
                estado = "refacciones";
            }
        }

        private void btnServicios_Click(object sender, EventArgs e)
        {
            if(estado != "servicios")
            {
                pnlContenedor.Controls.Clear();
                Servicios servicios = new Servicios();
                pnlContenedor.Controls.Add(servicios);
                estado = "servicios";
            }
        }
    }
}
