using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capivaras_hardware
{
    public partial class FormCliente : Form
    {
        public FormCliente()
        {
            InitializeComponent();
        }

        private void FormCliente_Load(object sender, EventArgs e)
        {
            { // A DATA AUTOMÁTICA DE CADASTRO DO CLIENTE
                lbDataCadastro.Text = DateTime.Now.ToShortDateString();
            }
        }
    }
}
