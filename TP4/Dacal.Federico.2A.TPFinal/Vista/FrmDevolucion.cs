using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Vista
{
    public partial class FrmDevolucion : Form
    {
        private Socio socio;
        private List<Prestamo> prestamos;
        private Prestamo prestamoSeleccionado;

        private FrmDevolucion()
        {
            InitializeComponent();
        }

        public FrmDevolucion(Socio socio):this()
        {
            this.socio = socio;
        }

        private void FrmDevolucion_Load(object sender, EventArgs e)
        {
            try
            {
                this.prestamos = socio.ListaPrestamos;
                this.RecuperarDatos();
                this.RefrescarListBox();               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GuardarDatos()
        {
            Serializadora<List<Publicacion>>.Serializar(FrmPublicaciones.PathPublicaciones, Biblioteca.Publicaciones);
        }

        private void RecuperarDatos()
        {
            Biblioteca.Publicaciones = Serializadora<List<Publicacion>>.Deserializar(FrmPublicaciones.PathPublicaciones);
        }

        private void RefrescarListBox()
        {
            this.lstPrestamos.DataSource = null;
            this.lstPrestamos.DataSource = this.prestamos.ToList();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRecibir_Click(object sender, EventArgs e)
        {
            try
            {
                this.prestamoSeleccionado = (Prestamo)this.lstPrestamos.SelectedItem;

                if (this.prestamoSeleccionado is not null)
                {
                    Biblioteca.RecibirDevolucion(this.socio, this.prestamoSeleccionado);

                    if (PrestamoDAO.Borrar(this.prestamoSeleccionado.Id))
                    {
                        this.RefrescarListBox();
                        this.GuardarDatos();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un problema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
