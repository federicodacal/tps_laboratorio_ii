﻿using System;
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
    public partial class FrmSocios : Form
    {
        private List<Socio> listaSocios;

        public FrmSocios()
        {
            InitializeComponent();
        }

        private Socio Socio
        {
            get { return (Socio)this.dgvSocios.CurrentRow.DataBoundItem; }
        }

        private void MessageBoxError(Exception ex)
        {
            MessageBox.Show(ex.Message, "Ocurrió un problema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAltaModificacion frmAltaModificacion = new FrmAltaModificacion();
                frmAltaModificacion.ShowDialog();

                if (frmAltaModificacion.DialogResult == DialogResult.OK)
                {
                    this.RefrescarDatagrid();
                }

            }
            catch (Exception ex)
            {
                this.MessageBoxError(ex);
            }        
        }

        private void RefrescarDatagrid()
        {
            try
            {
                this.RecuperarDatos();
                this.dgvSocios.DataSource = null;
                this.dgvSocios.DataSource = this.listaSocios.ToList();
                this.dgvSocios.Columns["FechaNacimiento"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrio un problema {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void FrmSocios_Load(object sender, EventArgs e)
        {
            try
            {
                this.RecuperarDatos();
                this.RefrescarDatagrid();
            }
            catch (Exception ex)
            {
                this.MessageBoxError(ex);
            }                
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAltaModificacion frmAltaModificacion = new FrmAltaModificacion(this.Socio);

                frmAltaModificacion.ShowDialog();

                if (frmAltaModificacion.DialogResult == DialogResult.OK)
                {
                    this.RefrescarDatagrid();
                }
            }
            catch (Exception ex)
            {
                this.MessageBoxError(ex);
            }            
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Socio is not null)
                {
                    if(this.Socio.ListaPrestamos.Count > 0)
                    {
                        MessageBox.Show($"El socio {this.Socio.Apellido}, aún tiene préstamos vigentes, no puede ser dando de baja hasta no completar las devoluciones", "Remover Socio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        DialogResult rta = MessageBox.Show($"Atención! ¿Desea quitar a socio {this.Socio.Apellido}?", "Remover Socio", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (rta == DialogResult.Yes)
                        {
                            SocioDAO.Eliminar(this.Socio.Dni);
                            this.RefrescarDatagrid();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.MessageBoxError(ex);
            }            
        }

        private void RecuperarDatos()
        {
            Biblioteca.Socios = SocioDAO.Leer();
            this.listaSocios = Biblioteca.Socios;

            Biblioteca.Prestamos = PrestamoDAO.Leer();
            Biblioteca.CargarPrestamos();
        }

        private void btnPrestamo_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Socio is not null)
                {
                    FrmPublicaciones frmPublicaciones = new FrmPublicaciones(this.Socio);
                    DialogResult rta = frmPublicaciones.ShowDialog();

                    if(rta == DialogResult.OK)
                    {
                        MessageBox.Show("Préstamo realizado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un socio antes de asignar un préstamo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Socio is not null)
                {
                    string desktop = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Mis_SociosJson");


                    Serializadora<Socio> serializadoraSocio = new Serializadora<Socio>();

                    ((ISerializableJson<Socio>)serializadoraSocio).Serializar(desktop, this.Socio);

                    MessageBox.Show("Socio guardado correctamente", "Socio Json", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                this.MessageBoxError(ex);
            }
        }

        private void btnDevolucion_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.Socio is not null && this.Socio.ListaPrestamos.Count > 0)
                {
                    FrmDevolucion frmDevolucion = new FrmDevolucion(this.Socio);
                    frmDevolucion.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No tiene devoluciones pendientes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                this.MessageBoxError(ex);
            }
        }
    }
}
