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
    public partial class FormCategoria : Form
    {
        public FormCategoria()
        {
            InitializeComponent();
        }

        private void FormCategoria_Load(object sender, EventArgs e)
        {
            { // A DATA AUTOMÁTICA DE CADASTRO DO FUNCIONÁRIO
                lbDataCadastro.Text = DateTime.Now.ToShortDateString();
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            //CRIAR OBJETO DA CLASSE CATEGORIA  
            classCategoria cCategoria = new classCategoria();

            //VALIDAÇÃO SE O COMPO OBRIGATÓRIO FOI PREENCHIDO PELO USUÁRIO
            if (string.IsNullOrWhiteSpace(tbxNome.Text))
            {
                MessageBox.Show("Favor, preencher o nome da categoria", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbxNome.BackColor = Color.FromArgb(188, 143, 143);
                tbxNome.Focus();
            }
            else // REALIZAR O CADASTRO
            {
                cCategoria.nome = tbxNome.Text;
                cCategoria.observacao = txbObs.Text;
                cCategoria.data_cadastro = Convert.ToDateTime(lbDataCadastro.Text);

       

                //CHAMAR O MÉTODO DE CADASTRO DA CLASSE CATEGORIA
                int resp = cCategoria.CadastrarCategoria();

                //MOSTRAR O RESULTADO DO MÉTODO PARA O USUÁRIO
                //SE DEU CERTO - CADASTRO REALIZADO 1
                if (resp == 1)
                {
                    MessageBox.Show($"Categoria: {cCategoria.nome} cadastrado com sucesso", "Sistema Loja Hardware", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbxNome.Clear();
                    txbObs.Clear();
                    tbxNome.Focus();
                    
                }
                else
                {
                    MessageBox.Show("Erro ao realizar o cadastro", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            }



        }













    }
}
