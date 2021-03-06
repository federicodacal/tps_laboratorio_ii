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
    public partial class FrmPublicaciones : Form
    {
        private Socio socio;
        private List<Publicacion> publicaciones;
        private static string pathPublicaciones;

        private enum ETipoPublicacion { Todos, Novela, PublicacionUniversitaria, Paper }

        static FrmPublicaciones()
        {
            FrmPublicaciones.pathPublicaciones = @$"{AppDomain.CurrentDomain.BaseDirectory}\publicaciones.xml";
        }

        public FrmPublicaciones()
        {
            InitializeComponent();
        }

        public FrmPublicaciones(Socio socio):this()
        {
            this.socio = socio;
        }

        private Publicacion Publicacion
        {
            get { return (Publicacion)this.dgvPublicaciones.CurrentRow.DataBoundItem; }
        }

        public static string PathPublicaciones
        {
            get { return FrmPublicaciones.pathPublicaciones; }
        }

        private void MessageBoxError(Exception ex)
        {
            MessageBox.Show(ex.Message, "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void FrmPublicaciones_Load(object sender, EventArgs e)
        {
            try
            {
                Biblioteca.LimitePrestamosAlcanzado += new LimitePrestamosDelegado(this.AvisarLimitePrestamos);

                this.cmbTipo.DataSource = Enum.GetValues(typeof(ETipoPublicacion));
                this.btnAsignar.Visible = false;
                this.RecuperarDatos();
                this.publicaciones = Biblioteca.Publicaciones;
                this.RefrescarDatagrid();

                if (this.socio is not null)
                {
                    this.btnAsignar.Visible = true;
                }
            }
            catch (Exception ex)
            {
                this.MessageBoxError(ex);
            }         
        }

        private void RefrescarDatagrid()
        {
            this.dgvPublicaciones.DataSource = null;
            if(this.publicaciones is not null)
            {
                this.dgvPublicaciones.DataSource = this.publicaciones.ToList();
            }
        }

        private void GuardarDatos()
        {
            Serializadora<List<Publicacion>>.Serializar(FrmPublicaciones.pathPublicaciones, Biblioteca.Publicaciones);           
        }

        private void RecuperarDatos()
        {
            Biblioteca.Publicaciones = Serializadora<List<Publicacion>>.Deserializar(FrmPublicaciones.pathPublicaciones);
        }

        public void AvisarLimitePrestamos(Socio socio, SocioEventArgs e)
        {
            MessageBox.Show($"El socio {socio}alcanzó el límite de prestamos. Tiene {e.PrestamosVigentes} préstamos vigentes", "Limite de préstamos alcanzado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Publicacion is not null && this.socio is not null)
                {
                    if (!this.Publicacion.EstaDisponible)
                    {
                        MessageBox.Show($"No es posible realizar ese préstamo. \n'{this.Publicacion.Titulo}' ya fue prestado.", "Publicacion no disponbile", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    if (Biblioteca.PrestarPublicacion(this.socio, this.Publicacion))
                    {
                        if (PrestamoDAO.Guardar(new Prestamo(this.Publicacion, this.socio)))
                        {
                            this.GuardarDatos();
                            this.RefrescarDatagrid();
                            this.DialogResult = DialogResult.OK;
                        }
                    }                
                }
            }
            catch (Exception ex)
            {
                this.MessageBoxError(ex);
            }          
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.publicaciones = null;
                this.publicaciones = new List<Publicacion>();
                switch (this.cmbTipo.SelectedItem)
                {
                    case ETipoPublicacion.Novela:
                        foreach (Publicacion item in Biblioteca.Publicaciones)
                        {
                            if (item.Tipo == "Novela")
                            {
                                this.publicaciones.Add(item);
                            }
                        }
                        break;
                    case ETipoPublicacion.PublicacionUniversitaria:
                        foreach (Publicacion item in Biblioteca.Publicaciones)
                        {
                            if (item.Tipo == "PublicacionUniversitaria")
                            {
                                this.publicaciones.Add(item);
                            }
                        }
                        break;
                    case ETipoPublicacion.Paper:
                        foreach (Publicacion item in Biblioteca.Publicaciones)
                        {
                            if (item.Tipo == "Paper")
                            {
                                this.publicaciones.Add(item);
                            }
                        }
                        break;
                    default: // ETipoPublicacion.Todos
                        this.publicaciones = Biblioteca.Publicaciones;
                        break;
                }

                this.RefrescarDatagrid();
            }
            catch (Exception ex)
            {
                this.MessageBoxError(ex);
            }           
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }       
    }
}
