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
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void timerPrincipal_Tick(object sender, EventArgs e)
        {
            { // DEFININDO A DATA E HORA ATUAL PARA EXIBIÇÃO NO FORM PRINCIPAL
                statuslbData.Text = DateTime.Now.ToShortDateString();
                statuslbHora.Text = DateTime.Now.ToShortTimeString();
            }
        }

        private void btnSairPrincipal_Click(object sender, EventArgs e)
        {
            // Fechar a aplicação , O sistema Todo
            if (MessageBox.Show("Deseja fechar o sistema ?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void cadCargo_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<FormCargo>().Count()> 0)
            {
                MessageBox.Show("O formulário de cadastro de cargo já está aberto", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                    //CRIAR O OBJETO DO FORM E ESTANCIAR O OBJETO
                     FormCargo Forfilho = new FormCargo();
                    //Tornar o formulario cargo filho do form Principal
                    Forfilho.MdiParent = this;
                    //  ABRIR O FORMULÁRIO DE CADASTRO DE CARGO NO MODO MDI
                    Forfilho.Show();


            }
        }

        private void cadFuncionarios_Click(object sender, EventArgs e)
        {

            if (Application.OpenForms.OfType<FormFuncionario>().Count() > 0)
            {
                MessageBox.Show("O formulário de cadastro de Funcionários já está aberto", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                //CRIAR O OBJETO DO FORM E ESTANCIAR O OBJETO
                FormFuncionario Forfilho = new FormFuncionario();
                //Tornar o formulario cargo filho do form Principal
                Forfilho.MdiParent = this;
                //  ABRIR O FORMULÁRIO DE CADASTRO DE FUNIONÁRIOS NO MODO MDI
                Forfilho.Show();


            }

        }

        private void btnCadCliMenu_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<FormCliente>().Count() > 0)
            {
                MessageBox.Show("O formulário de cadastro de Cliente já está aberto", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                //CRIAR O OBJETO DO FORM E ESTANCIAR O OBJETO
                FormCliente Forfilho = new FormCliente();
                //Tornar o formulario cargo filho do form Principal
                Forfilho.MdiParent = this;
                //  ABRIR O FORMULÁRIO DE CADASTRO DE CLIENTES NO MODO MDI
                Forfilho.Show();


            }

        }

        private void mnBtnCadPro_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<FormProduto>().Count()> 0)
            {
                MessageBox.Show("O formulário de cadastro de Produto já está aberto", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                FormProduto Forfilho = new FormProduto();
                Forfilho.MdiParent = this;
                Forfilho.Show();
            }
        }

        private void mnBtnCadCat_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<FormCategoria>().Count() > 0)
            {
                MessageBox.Show("O formulário de cadastro de Categoria já está aberto", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                //CRIAR O OBJETO DO FORM E ESTANCIAR O OBJETO
                FormCategoria Forfilho = new FormCategoria();
                //Tornar o formulario cargo filho do form Principal
                Forfilho.MdiParent = this;
                //  ABRIR O FORMULÁRIO DE CADASTRO DE CLIENTES NO MODO MDI
                Forfilho.Show();


            }

        }

        private void mnBtnCadMar_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<FormMarca>().Count() > 0)
            {
                MessageBox.Show("O formulário de cadastro da Marca já está aberto", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                //CRIAR O OBJETO DO FORM E ESTANCIAR O OBJETO
                FormMarca Forfilho = new FormMarca();
                //Tornar o formulario cargo filho do form Principal
                Forfilho.MdiParent = this;
                //  ABRIR O FORMULÁRIO DE CADASTRO DE CLIENTES NO MODO MDI
                Forfilho.Show();


            }
        }
    }
}
