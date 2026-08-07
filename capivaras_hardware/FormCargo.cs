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

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            //CRIAR OBJETO DA CLASSE PARA USAR PROPRIEDADES E  MÉTODOS DA CLASSE
            classCargo cCargo = new classCargo();

            //VERIFICAR SE TODOS OS CAMPOS OBRIGATÓRIOS QUE DEVEM SER PREENCHIDOS PELO USUÁRIO ESTÃO PREENCHIDOS
            if (string.IsNullOrWhiteSpace(txbNome.Text))
            {
                MessageBox.Show("Favor informar o nome do cargo", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbNome.BackColor = Color.FromArgb(188, 143, 143);
                txbNome.Focus();

            }
            else
            {
                //PASSAR PARA AS PROPRIEDADES DA CLASSE O CONTEÚDO DE TOSO OS ELEMENTOS QUE PODEM SER PREENCHIDO PELO USUÁRIO DE TODO
                cCargo.nome = txbNome.Text;
                cCargo.observacao = tbxObs.Text;


                //CHAMAR MÉTODO CADASTRAR DA CLASSE CARGO
                //MÉTODO RETORNA UM NÚMERO 0 ERRADO 1 CERTO
                int resp = cCargo.CadastrarCargo();


                //EXIBIR A MENSAGEM PARA O USUÁRIO
                //SE DEU CERTO MOSTRAR A MENSAGEM E LIMPAR O FORM
                if (resp == 1)
                {
                    MessageBox.Show($"Cargo: {cCargo.nome} Cadastrado com Sucesso", "Sistema loja Hardwares", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txbNome.Clear();
                    tbxObs.Clear();
                    txbNome.Focus();

                }
                else
                {
                    MessageBox.Show("Erro ao realizar cadastro", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }

    }
}
