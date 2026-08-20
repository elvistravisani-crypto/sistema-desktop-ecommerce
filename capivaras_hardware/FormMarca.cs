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
    public partial class FormMarca : Form
    {
        public FormMarca()
        {
            InitializeComponent();
        }

        private void FormMarca_Load(object sender, EventArgs e)
        {
            { // A DATA AUTOMÁTICA DE CADASTRO DA MARCA
                lbDataCadastro.Text = DateTime.Now.ToShortDateString();
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {

            //CRIAR OBJETO DA CLASSE FUNCIONÁRIO
            classMarca cMarca = new classMarca();
            if (string.IsNullOrWhiteSpace(txbNome.Text))
            {
                MessageBox.Show("Favor, preencher o nome da Marca", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbNome.BackColor = Color.FromArgb(188, 143, 143);
                txbNome.Focus();
            }
           
            else
            {
                cMarca.nome = txbNome.Text;
                cMarca.descricao = txbDescricao.Text;
                cMarca.data_cadastro = Convert.ToDateTime(lbDataCadastro.Text);
                cMarca.status = 1;
                //CHAMAR O MÉTODO DE CADASTRO DA CLASSE CATEGORIA
                int resp = cMarca.CadastrarMarca();

                //MOSTRAR O RESULTADO DO MÉTODO PARA O USUÁRIO
                //SE DEU CERTO - CADASTRO REALIZADO 1
                if (resp == 1)
                {
                    MessageBox.Show($"Marca: {cMarca.nome} cadastrado com sucesso", "Sistema Loja Hardware", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Erro ao realizar o cadastro", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }



        }






    }
}
