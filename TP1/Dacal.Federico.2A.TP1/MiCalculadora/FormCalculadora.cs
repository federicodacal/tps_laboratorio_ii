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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            cmbOperador.Items.Add("");
            cmbOperador.Items.Add('+');
            cmbOperador.Items.Add('-');
            cmbOperador.Items.Add('*');
            cmbOperador.Items.Add('/');

            this.Limpiar();

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void Limpiar()
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.cmbOperador.SelectedIndex = 0; 
            this.lblResultado.Text = "";
            this.lstOperaciones.Items.Clear();
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            double resultado;
            char auxOperador;

            Char.TryParse(operador, out auxOperador);

            Operando operando1 = new Operando(numero1);
            Operando operando2 = new Operando(numero2);

            resultado = Calculadora.Operar(operando1, operando2, auxOperador);

            return resultado;
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado;
            string numero1 = txtNumero1.Text;
            string numero2 = txtNumero2.Text;
            string auxOperador = cmbOperador.Text;
            string auxNumero1 = "0";
            string auxNumero2 = "0";


            resultado = FormCalculadora.Operar(numero1, numero2, auxOperador);

            if(!String.IsNullOrWhiteSpace(numero1))
            {
                auxNumero1 = numero1;
            }
            if (!String.IsNullOrWhiteSpace(numero2))
            {
                auxNumero2 = numero2;
            }
            if(cmbOperador.SelectedItem is null)
            {
                auxOperador = "+";
            }
            this.lstOperaciones.Items.Add($"{auxNumero1} {auxOperador} {auxNumero2} = {resultado}");
            this.lblResultado.Text = resultado.ToString();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult respuesta = MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(respuesta == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.lblResultado.Text))
            {
                Operando numDecimal = new Operando();
                this.lblResultado.Text = numDecimal.DecimalBinario(this.lblResultado.Text);
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string auxBinario;
            if(!String.IsNullOrEmpty(this.lblResultado.Text))
            {
                Operando numBinario = new Operando();
                auxBinario = numBinario.BinarioDecimal(this.lblResultado.Text);
                this.lblResultado.Text = auxBinario;
            }
        }
    }
}
