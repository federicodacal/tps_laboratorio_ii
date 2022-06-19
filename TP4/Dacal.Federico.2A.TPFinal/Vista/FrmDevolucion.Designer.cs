
namespace Vista
{
    partial class FrmDevolucion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDevolucion));
            this.lstPrestamos = new System.Windows.Forms.ListBox();
            this.btnRecibir = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnCancelarComprobante = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstPrestamos
            // 
            this.lstPrestamos.BackColor = System.Drawing.Color.Bisque;
            this.lstPrestamos.FormattingEnabled = true;
            this.lstPrestamos.ItemHeight = 25;
            this.lstPrestamos.Location = new System.Drawing.Point(12, 12);
            this.lstPrestamos.Name = "lstPrestamos";
            this.lstPrestamos.Size = new System.Drawing.Size(481, 379);
            this.lstPrestamos.TabIndex = 0;
            // 
            // btnRecibir
            // 
            this.btnRecibir.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRecibir.Location = new System.Drawing.Point(12, 412);
            this.btnRecibir.Name = "btnRecibir";
            this.btnRecibir.Size = new System.Drawing.Size(189, 52);
            this.btnRecibir.TabIndex = 1;
            this.btnRecibir.Text = "Recibir";
            this.btnRecibir.UseVisualStyleBackColor = true;
            this.btnRecibir.Click += new System.EventHandler(this.btnRecibir_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnVolver.Location = new System.Drawing.Point(789, 412);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(189, 52);
            this.btnVolver.TabIndex = 2;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnCancelarComprobante
            // 
            this.btnCancelarComprobante.Enabled = false;
            this.btnCancelarComprobante.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancelarComprobante.Location = new System.Drawing.Point(216, 412);
            this.btnCancelarComprobante.Name = "btnCancelarComprobante";
            this.btnCancelarComprobante.Size = new System.Drawing.Size(277, 52);
            this.btnCancelarComprobante.TabIndex = 4;
            this.btnCancelarComprobante.Text = "Cancelar Comprobante";
            this.btnCancelarComprobante.UseVisualStyleBackColor = true;
            this.btnCancelarComprobante.Click += new System.EventHandler(this.btnCancelarComprobante_Click);
            // 
            // FrmDevolucion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(990, 515);
            this.Controls.Add(this.btnCancelarComprobante);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnRecibir);
            this.Controls.Add(this.lstPrestamos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDevolucion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Devolucion";
            this.Load += new System.EventHandler(this.FrmDevolucion_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstPrestamos;
        private System.Windows.Forms.Button btnRecibir;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnCancelarComprobante;
    }
}