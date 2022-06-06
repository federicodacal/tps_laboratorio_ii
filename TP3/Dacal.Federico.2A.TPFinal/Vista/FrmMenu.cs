using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Vista
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void btnSocios_Click(object sender, EventArgs e)
        {
            FrmSocios frmSocios = new FrmSocios();
            frmSocios.ShowDialog();
        }

        private void btnPublicaciones_Click(object sender, EventArgs e)
        {
            FrmPublicaciones frmPublicaciones = new FrmPublicaciones();
            frmPublicaciones.ShowDialog();
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult rta = MessageBox.Show("¿Desea cerrar la aplicación?", "Cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rta == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
