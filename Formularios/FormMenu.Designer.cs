namespace Taller_Mecanico.Formularios
{
    partial class FormMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnServicios = new System.Windows.Forms.Button();
            this.btnRefacciones = new System.Windows.Forms.Button();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnServicios
            // 
            this.btnServicios.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnServicios.Location = new System.Drawing.Point(750, 12);
            this.btnServicios.Name = "btnServicios";
            this.btnServicios.Size = new System.Drawing.Size(228, 115);
            this.btnServicios.TabIndex = 15;
            this.btnServicios.Text = "Servicios";
            this.btnServicios.UseVisualStyleBackColor = true;
            this.btnServicios.Click += new System.EventHandler(this.btnServicios_Click);
            // 
            // btnRefacciones
            // 
            this.btnRefacciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnRefacciones.Location = new System.Drawing.Point(487, 12);
            this.btnRefacciones.Name = "btnRefacciones";
            this.btnRefacciones.Size = new System.Drawing.Size(228, 115);
            this.btnRefacciones.TabIndex = 16;
            this.btnRefacciones.Text = "Refacciones";
            this.btnRefacciones.UseVisualStyleBackColor = true;
            this.btnRefacciones.Click += new System.EventHandler(this.btnRefacciones_Click);
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.Location = new System.Drawing.Point(12, 133);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(1430, 904);
            this.pnlContenedor.TabIndex = 17;
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1453, 1049);
            this.Controls.Add(this.pnlContenedor);
            this.Controls.Add(this.btnRefacciones);
            this.Controls.Add(this.btnServicios);
            this.Name = "FormMenu";
            this.Text = "FormMenu";
            this.Load += new System.EventHandler(this.FormMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnServicios;
        private System.Windows.Forms.Button btnRefacciones;
        private System.Windows.Forms.Panel pnlContenedor;
    }
}