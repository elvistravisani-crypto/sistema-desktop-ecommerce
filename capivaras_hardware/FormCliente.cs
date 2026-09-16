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
        //MÉTODO PARA LIMPAR TODOS OS CAMPOS DO FORMULÁRIO QUANDO O CADASTRO FOR FINALIZADO////////////
        private void Limpar()
        {
            txbNome.Clear();
            txbNomeSocial.Clear();
            mtxbCpf.Clear();
            mtxbDataNascimento.Clear();
            mtxbCelular.Clear();
            txbEmail.Clear();
            txbSenha.Clear();
            mtxbCep.Clear();
            txbRua.Clear();
            txbNumero.Clear();
            txbComplemento.Clear();
            txbBairro.Clear();
            txbCidade.Clear();
            cmbEstado.SelectedItem = "SP";

        }
        public FormCliente()
        {
            InitializeComponent();
        }

        private void FormCliente_Load(object sender, EventArgs e)
        {
            { // A DATA AUTOMÁTICA DE CADASTRO DO CLIENTE
                lbDataCadastro.Text = DateTime.Now.ToShortDateString();
            }
            //POVOANDO A CMB ESTADO
            cmbEstado.Items.Add("AC");
            cmbEstado.Items.Add("AL");
            cmbEstado.Items.Add("AP");
            cmbEstado.Items.Add("AM");
            cmbEstado.Items.Add("BA");
            cmbEstado.Items.Add("CE");
            cmbEstado.Items.Add("DF");
            cmbEstado.Items.Add("ES");
            cmbEstado.Items.Add("GO");
            cmbEstado.Items.Add("MA");
            cmbEstado.Items.Add("MS");
            cmbEstado.Items.Add("MG");
            cmbEstado.Items.Add("PA");
            cmbEstado.Items.Add("PB");
            cmbEstado.Items.Add("PR");
            cmbEstado.Items.Add("PE");
            cmbEstado.Items.Add("PI");
            cmbEstado.Items.Add("RJ");
            cmbEstado.Items.Add("RN");
            cmbEstado.Items.Add("RS");
            cmbEstado.Items.Add("RO");
            cmbEstado.Items.Add("RR");
            cmbEstado.Items.Add("SC");
            cmbEstado.Items.Add("SP");
            cmbEstado.Items.Add("SE");
            cmbEstado.Items.Add("TO");

            //COLOCAR EM ORDEM ALFABÉTICA
            cmbEstado.Sorted = true;
            cmbEstado.SelectedItem = "SP";
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            //CLIAR OBJETO DA CLASSE CLIENTE
            classCliente cCliente = new classCliente();

            //VALIDAÇÃO SE TODOS OS COMPOS OBRIGATÓRIOS DO FORMULÁRIO ESTÃO PREENCHIDOS 
            if (string.IsNullOrWhiteSpace(txbNome.Text) || mtxbCpf.Text == "   .   .   -  " || mtxbDataNascimento.Text == "  /  /    " || mtxbCelular.Text == "(  )     -    " || string.IsNullOrWhiteSpace(txbEmail.Text) || string.IsNullOrWhiteSpace(txbSenha.Text) || mtxbCep.Text == "     -   " || string.IsNullOrWhiteSpace(txbRua.Text) || string.IsNullOrWhiteSpace(txbNumero.Text) || string.IsNullOrWhiteSpace(txbBairro.Text) || string.IsNullOrWhiteSpace(txbCidade.Text) )
            
                {
                    MessageBox.Show("Favor verificar se todos os campos obrigatórios estão preenchidos", "Atenção", MessageBoxButtons.OK,MessageBoxIcon.Warning);

                //DESTACAR OS COMPOS OBRIGATÓRIOS VISUALMENTE PARA O CLIETE
                txbNome.BackColor = Color.FromArgb(188, 143, 143);
                mtxbCpf.BackColor  = Color.FromArgb(188, 143, 143);
                mtxbDataNascimento.BackColor = Color.FromArgb(188, 143, 143);
                txbEmail.BackColor = Color.FromArgb(188, 143, 143);
                txbSenha.BackColor = Color.FromArgb(188, 143, 143);
                mtxbCep.BackColor = Color.FromArgb(188, 143, 143);
                txbRua.BackColor = Color.FromArgb(188, 143, 143);
                txbNumero.BackColor = Color.FromArgb(188, 143, 143);
                txbBairro.BackColor = Color.FromArgb(188, 143, 143);
                txbCidade.BackColor = Color.FromArgb(188, 143, 143);

            }
            // REALIZAR O CADASTRO, USUÁRIO PREENCHEU OS CAMPOS - MANDAR PARA AS PROPRIEDADES DA CLASSE TODOS OS CAMPOS QUE O USUÁRIO PODE PREENCHER DO FORMULÁRIO
            else
            {
                cCliente.nome = txbNome.Text;
                cCliente.nome_social = txbNomeSocial.Text;
                cCliente.data_nascimento = Convert.ToDateTime(mtxbDataNascimento.Text);
                //IF PARA VERIFICAR QUAL RADIOBUTON ESTA SELECIONADA PELO USUÁRIO
                if (rdbSxFeminino.Checked)
                {
                    cCliente.sexo = "F";
                }
                else if (rdbSxMasculino.Checked)
                {
                    cCliente.sexo = "M";
                }
                else
                {
                    cCliente.sexo = "N";
                }
                //SALVANDO O CPF NO BANCO 
                cCliente.cpf = mtxbCpf.Text;

                //SALVANDO O NUMERO DE CELULAR, CAMPO NÃO OBRIGATÓRIO
                if (mtxbCelular.Text == "(  )     -    ")
                {
                    cCliente.telefone = "";
                }
                else
                {
                    cCliente.telefone = mtxbCelular.Text;
                }

                //CAPTURA DAS CREDENCIAIS: EMAIL E SENHA

                cCliente.email = txbEmail.Text;
                cCliente.senha = txbSenha.Text;

                //SALVANDO O ENDEREÇO
                cCliente.endereco = txbRua.Text;
                cCliente.numero = Convert.ToInt32(txbNumero.Text);
                cCliente.complemento = txbComplemento.Text;
                cCliente.bairro = txbBairro.Text;
                cCliente.cidade = txbCidade.Text;
                cCliente.cep = mtxbCep.Text;

                //ESTADO - COMBOBOX, MANDAR PARA O BD O ITEM SELECIONADO PELO USUÁRIO
                cCliente.estado = cmbEstado.SelectedItem.ToString();

                //CHAMAR O MÉTODO DE CADASTRO DA CLASSE FUNCIONÁRIO
                int resp = cCliente.cadastrarCliente();

                //MOSTRAR O RESULTADO DO MÉTODO PARA O USUÁRIO
                //SE DEU CERTO - CADASTRO REALIZADO 1
                if (resp == 1)
                {
                    MessageBox.Show($"Cliente: {cCliente.nome} cadastrado com sucesso", "Sistema Loja Hardware", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpar();
                }
                else
                {
                    MessageBox.Show("Erro ao realizar o cadastro", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
          

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }
    }
}
