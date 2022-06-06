using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;
using Entidades;

namespace Vista
{
    public partial class FrmAltaModificacion : Form
    {
        private Socio socio;

        public FrmAltaModificacion()
        {
            InitializeComponent();
        }

        public FrmAltaModificacion(Socio socio):this()
        {
            this.socio = socio;           
        }

        public Socio Socio
        {
            get { return this.socio; }
        }

        private bool EsValidoString(string str, int min, int max)
        {
            bool rta = false;
            bool flagDigit = false;
            if(!String.IsNullOrWhiteSpace(str) && str.Trim().Length > min && str.Trim().Length < max)
            {
                foreach (char item in str)
                {
                    if (char.IsDigit(item))
                    {
                        flagDigit = true;
                        break;
                    }
                }
                if (!flagDigit)
                {
                    rta = true;
                }
            }
            return rta;
        }

        private bool EsValidoEmail(string email)
        {
            bool rta = false;
            if(EsValidoString(email, 6, 40) && new EmailAddressAttribute().IsValid(email))
            {
                rta = true;
            }
            return rta;
        }

        private bool ValidarCampos(string nombre, string apellido, string dni, string email)
        {
            bool rta = false;
            long auxDni;
            if(EsValidoString(nombre, 1, 25) && EsValidoString(apellido, 1, 25) && long.TryParse(dni, out auxDni) && EsValidoEmail(email))
            {
                foreach (Control control in gbEsEstudiante.Controls)
                {
                    RadioButton radio = control as RadioButton;
                    if(radio is not null && radio.Checked)
                    {
                        rta = true;
                        break;
                    }
                }
            }
            return rta;
        }

        private void MessageBoxError(Exception ex)
        {
            MessageBox.Show(ex.Message, "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = this.txtNombre.Text;
                string apellido = this.txtApellido.Text;
                string dni = this.txtDni.Text;
                string email = this.txtEmail.Text;
                bool esEstudiante = this.CheckearRadioButtons();

                if (this.Socio is null)
                {
                    if (ValidarCampos(nombre, apellido, dni, email))
                    {
                        Socio auxSocio = new Socio(nombre.Trim(), apellido.Trim(), long.Parse(dni), (Socio.EGenero)this.cmbGenero.SelectedItem, this.dtpFechaNacimiento.Value, email, esEstudiante);

                        Biblioteca.AgregarSocio(auxSocio);

                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        this.MessageBoxCamposIncompletos();
                    }
                }
                else
                {
                    if (ValidarCampos(nombre, apellido, dni, email))
                    {
                        this.Socio.Nombre = this.txtNombre.Text;
                        this.Socio.Apellido = this.txtApellido.Text;
                        this.Socio.Dni = long.Parse(this.txtDni.Text);
                        this.Socio.Email = this.txtEmail.Text;
                        this.Socio.FechaNacimiento = this.dtpFechaNacimiento.Value;
                        this.Socio.Genero = (Socio.EGenero)this.cmbGenero.SelectedItem;
                        this.Socio.EsEstudiante = this.CheckearRadioButtons();

                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        this.MessageBoxCamposIncompletos();
                    }
                }
            }
            catch (Exception ex)
            {
                this.MessageBoxError(ex);
            }              
        }

        private void MessageBoxCamposIncompletos()
        {
            MessageBox.Show("Atención! Debe asegurarse de completar todos los campos correctamente", "Campos incorrectos o incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private bool CheckearRadioButtons()
        {
            return this.rbSi.Checked;
        }

        private void FrmAltaModificacion_Load(object sender, EventArgs e)
        {
            try
            {
                this.cmbGenero.DataSource = Enum.GetValues(typeof(Socio.EGenero));
                if (this.Socio is not null)
                {
                    this.Text = $"Modificar socio {this.Socio.Apellido}";
                    this.txtApellido.Text = this.Socio.Apellido;
                    this.txtNombre.Text = this.Socio.Nombre;
                    this.txtDni.Text = this.Socio.Dni.ToString();
                    this.txtEmail.Text = this.Socio.Email;
                    this.cmbGenero.SelectedIndex = (int)this.Socio.Genero;
                    this.dtpFechaNacimiento.Value = this.Socio.FechaNacimiento;
                    if (this.Socio.EsEstudiante)
                    {
                        this.rbSi.Checked = true;
                    }
                    else
                    {
                        this.rbNo.Checked = true;
                    }
                    this.btnConfirmar.Text = "Guardar Cambios";
                }
                else
                {
                    this.Text = "Agregar nuevo socio";
                    this.btnConfirmar.Text = "Confirmar";
                }
            }
            catch (Exception ex)
            {
                this.MessageBoxError(ex);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAltaModificacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult rta = MessageBox.Show("¿Desea cancelar?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rta == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
