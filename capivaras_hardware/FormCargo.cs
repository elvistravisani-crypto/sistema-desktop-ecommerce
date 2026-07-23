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
    public partial class FormCargo : Form
    {
        public FormCargo()
        {
            InitializeComponent();
        }

        private void FormCargo_Load(object sender, EventArgs e)
        {
            { // A DATA AUTOMÁTICA DE CADASTRO DO CARGO
                lbDataCadastro.Text = DateTime.Now.ToShortDateString();
            }
        }
    }
}
