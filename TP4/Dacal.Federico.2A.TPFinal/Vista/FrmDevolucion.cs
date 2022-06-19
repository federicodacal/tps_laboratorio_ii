using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
        private CancellationTokenSource cts;

        private FrmDevolucion()
        {
            InitializeComponent();
            this.cts = new CancellationTokenSource();
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
            try
            {
                Serializadora<List<Publicacion>>.Serializar(FrmPublicaciones.PathPublicaciones, Biblioteca.Publicaciones);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un problema {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }  
        }

        private void RecuperarDatos()
        {
            Biblioteca.Publicaciones = Serializadora<List<Publicacion>>.Deserializar(FrmPublicaciones.PathPublicaciones);
        }

        private void RefrescarListBox()
        {
            try
            {
                this.lstPrestamos.DataSource = null;
                this.lstPrestamos.DataSource = this.prestamos.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un problema {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnRecibir_Click(object sender, EventArgs e)
        {
            try
            {
                this.prestamoSeleccionado = (Prestamo)this.lstPrestamos.SelectedItem;

                if (this.prestamoSeleccionado is not null)
                {
                    Biblioteca.RecibirDevolucion(this.socio, this.prestamoSeleccionado);                                 
                    if (PrestamoDAO.Borrar(this.prestamoSeleccionado))
                    {
                        this.btnCancelarComprobante.Enabled = true;

                        bool rtaComprobante = await Biblioteca.EntregarComprobante(this.socio, this.prestamoSeleccionado, cts.Token);

                        if (rtaComprobante)
                        {
                            MessageBox.Show("Devolución exitosa!", "Publicación recibida",      MessageBoxButtons.OK, MessageBoxIcon.Information);                      
                        }
                    }
                }
            }
            catch (TaskCanceledException ex)
            {
                MessageBox.Show($"No se emitió comprobante: {ex.Message}", "Comprobante cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.RefrescarListBox();
                this.GuardarDatos();
            }
        }

        private void btnCancelarComprobante_Click(object sender, EventArgs e)
        {
            this.cts.Cancel();
            this.btnCancelarComprobante.Enabled = false;
        }
    }
}
