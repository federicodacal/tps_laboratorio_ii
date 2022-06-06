
namespace Vista
{
    partial class FrmAltaModificacion
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
            this.gbDatosSocio = new System.Windows.Forms.GroupBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblDNI = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.lblGenero = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.gbEsEstudiante = new System.Windows.Forms.GroupBox();
            this.rbNo = new System.Windows.Forms.RadioButton();
            this.rbSi = new System.Windows.Forms.RadioButton();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.cmbGenero = new System.Windows.Forms.ComboBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.gbDatosSocio.SuspendLayout();
            this.gbEsEstudiante.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDatosSocio
            // 
            this.gbDatosSocio.BackColor = System.Drawing.Color.Transparent;
            this.gbDatosSocio.Controls.Add(this.lblEmail);
            this.gbDatosSocio.Controls.Add(this.lblDNI);
            this.gbDatosSocio.Controls.Add(this.lblApellido);
            this.gbDatosSocio.Controls.Add(this.lblNombre);
            this.gbDatosSocio.Controls.Add(this.lblFechaNacimiento);
            this.gbDatosSocio.Controls.Add(this.lblGenero);
            this.gbDatosSocio.Controls.Add(this.txtDni);
            this.gbDatosSocio.Controls.Add(this.gbEsEstudiante);
            this.gbDatosSocio.Controls.Add(this.dtpFechaNacimiento);
            this.gbDatosSocio.Controls.Add(this.cmbGenero);
            this.gbDatosSocio.Controls.Add(this.txtEmail);
            this.gbDatosSocio.Controls.Add(this.txtApellido);
            this.gbDatosSocio.Controls.Add(this.txtNombre);
            this.gbDatosSocio.Location = new System.Drawing.Point(12, 12);
            this.gbDatosSocio.Name = "gbDatosSocio";
            this.gbDatosSocio.Size = new System.Drawing.Size(451, 590);
            this.gbDatosSocio.TabIndex = 0;
            this.gbDatosSocio.TabStop = false;
            this.gbDatosSocio.Text = "Datos Socio";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(21, 225);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(54, 25);
            this.lblEmail.TabIndex = 15;
            this.lblEmail.Text = "Email";
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Location = new System.Drawing.Point(21, 161);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(106, 25);
            this.lblDNI.TabIndex = 14;
            this.lblDNI.Text = "Documento";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(21, 99);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(78, 25);
            this.lblApellido.TabIndex = 13;
            this.lblApellido.Text = "Apellido";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(21, 37);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(78, 25);
            this.lblNombre.TabIndex = 12;
            this.lblNombre.Text = "Nombre";
            // 
            // lblFechaNacimiento
            // 
            this.lblFechaNacimiento.AutoSize = true;
            this.lblFechaNacimiento.Location = new System.Drawing.Point(21, 368);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(152, 25);
            this.lblFechaNacimiento.TabIndex = 11;
            this.lblFechaNacimiento.Text = "Fecha Nacimiento";
            // 
            // lblGenero
            // 
            this.lblGenero.AutoSize = true;
            this.lblGenero.Location = new System.Drawing.Point(21, 301);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(69, 25);
            this.lblGenero.TabIndex = 10;
            this.lblGenero.Text = "Genero";
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(21, 189);
            this.txtDni.Name = "txtDni";
            this.txtDni.PlaceholderText = "Ingrese documento o DNI";
            this.txtDni.Size = new System.Drawing.Size(392, 31);
            this.txtDni.TabIndex = 9;
            // 
            // gbEsEstudiante
            // 
            this.gbEsEstudiante.Controls.Add(this.rbNo);
            this.gbEsEstudiante.Controls.Add(this.rbSi);
            this.gbEsEstudiante.Location = new System.Drawing.Point(21, 450);
            this.gbEsEstudiante.Name = "gbEsEstudiante";
            this.gbEsEstudiante.Size = new System.Drawing.Size(392, 116);
            this.gbEsEstudiante.TabIndex = 8;
            this.gbEsEstudiante.TabStop = false;
            this.gbEsEstudiante.Text = "¿Estudia en UTN-Fra?";
            // 
            // rbNo
            // 
            this.rbNo.AutoSize = true;
            this.rbNo.Location = new System.Drawing.Point(189, 58);
            this.rbNo.Name = "rbNo";
            this.rbNo.Size = new System.Drawing.Size(61, 29);
            this.rbNo.TabIndex = 7;
            this.rbNo.TabStop = true;
            this.rbNo.Text = "No";
            this.rbNo.UseVisualStyleBackColor = true;
            // 
            // rbSi
            // 
            this.rbSi.AutoSize = true;
            this.rbSi.Location = new System.Drawing.Point(56, 58);
            this.rbSi.Name = "rbSi";
            this.rbSi.Size = new System.Drawing.Size(51, 29);
            this.rbSi.TabIndex = 6;
            this.rbSi.TabStop = true;
            this.rbSi.Text = "Si";
            this.rbSi.UseVisualStyleBackColor = true;
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(21, 396);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(392, 31);
            this.dtpFechaNacimiento.TabIndex = 5;
            // 
            // cmbGenero
            // 
            this.cmbGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGenero.FormattingEnabled = true;
            this.cmbGenero.Location = new System.Drawing.Point(21, 329);
            this.cmbGenero.Name = "cmbGenero";
            this.cmbGenero.Size = new System.Drawing.Size(392, 33);
            this.cmbGenero.TabIndex = 4;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(21, 253);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PlaceholderText = "Ingrese email";
            this.txtEmail.Size = new System.Drawing.Size(392, 31);
            this.txtEmail.TabIndex = 3;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(21, 127);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.PlaceholderText = "Ingrese apellido";
            this.txtApellido.Size = new System.Drawing.Size(392, 31);
            this.txtApellido.TabIndex = 1;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(21, 65);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.PlaceholderText = "Ingrese nombre";
            this.txtNombre.Size = new System.Drawing.Size(392, 31);
            this.txtNombre.TabIndex = 0;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(12, 627);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(219, 46);
            this.btnConfirmar.TabIndex = 12;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(244, 627);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(219, 46);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmAltaModificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.ClientSize = new System.Drawing.Size(475, 699);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.gbDatosSocio);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAltaModificacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAltaModificacion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAltaModificacion_FormClosing);
            this.Load += new System.EventHandler(this.FrmAltaModificacion_Load);
            this.gbDatosSocio.ResumeLayout(false);
            this.gbDatosSocio.PerformLayout();
            this.gbEsEstudiante.ResumeLayout(false);
            this.gbEsEstudiante.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatosSocio;
        private System.Windows.Forms.Label lblGenero;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.GroupBox gbEsEstudiante;
        private System.Windows.Forms.RadioButton rbNo;
        private System.Windows.Forms.RadioButton rbSi;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.ComboBox cmbGenero;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblFechaNacimiento;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblNombre;
    }
}