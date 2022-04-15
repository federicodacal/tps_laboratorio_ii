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
        /// <summary>
        /// Constructor de FormCalculadora
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Se carga el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            cmbOperador.Items.Add("");
            cmbOperador.Items.Add('+');
            cmbOperador.Items.Add('-');
            cmbOperador.Items.Add('*');
            cmbOperador.Items.Add('/');

            this.Limpiar();

        }

        /// <summary>
        /// Llama al método Limpiar que reestablece los campos del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Reestablece y limpia los campos txtNumero1, txtNumero2, lblResultado, lstOperaciones y cmbOperador
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.cmbOperador.SelectedIndex = 0; 
            this.lblResultado.Text = "";
            this.lstOperaciones.Items.Clear();
        }

        /// <summary>
        /// Realiza la operacion aritmetica a traves del metodo Operar de la Clase Calculadora
        /// </summary>
        /// <param name="numero1">Obtenido del txtNumero1</param>
        /// <param name="numero2">Obtenido del txtNumero2</param>
        /// <param name="operador">Obtenido del cmbOperador</param>
        /// <returns>Resultado de la operacion</returns>
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

        /// <summary>
        /// Obtiene los valores de los campos textbox y el operador del combobox para realizar su operacion mediante el metodo Operar del Form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Cierra el formulario en caso de hacerse efectiva la confirmacion del usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Maneja el cierre de la aplicacion, se pide la confirmacion del usuario para finalizar el programa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Se realiza conversion a binario mediante el metodo DecimalBinario de la Clase Operando
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.lblResultado.Text))
            {
                Operando numDecimal = new Operando();
                this.lblResultado.Text = numDecimal.DecimalBinario(this.lblResultado.Text);
            }
        }

        /// <summary>
        /// Se realiza la conversion a decimal mediante el metodo DecimalBinario de la Clase Operando
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
