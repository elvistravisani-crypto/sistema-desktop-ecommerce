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
    public partial class formConsCliente : Form
    {
        public formConsCliente()
        {
            InitializeComponent();
            this.AcceptButton = btPesquisar;
        }

        private void btSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja fechar o formulário?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void formConsCliente_Load(object sender, EventArgs e)
        {
            //POVOANDO AS OPÇÕES PARA CONSULTA
            cbFiltro.Items.Add("Nome");
            cbFiltro.Items.Add("Cidade");
            cbFiltro.Items.Add("CPF");
            cbFiltro.Items.Add("Sexo");
            cbFiltro.Items.Add("Status");

            cbFiltro.SelectedIndex = 0;

           

        }





    }
}
