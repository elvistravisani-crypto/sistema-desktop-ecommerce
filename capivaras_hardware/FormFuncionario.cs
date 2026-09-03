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
    public partial class FormFuncionario : Form
    {
        //MÉTODO PARA LIMPAR TODOS OS CAMPOS DO FORMULÁRIO QUANDO O CADASTRO FOR FINALIZADO////////////
        private void Limpar()
        {
            txbNome.Clear();
            txbNomeSocial.Clear();
            mtxbDataNascimento.Clear();
            rdbSxFeminino.Checked = true;
            cmbEstadoCivil.SelectedIndex = 0; //SELECIONE ESTADO CIVIL
            mtxbCpf.Clear();
            mtxbRg.Clear();
            txbSalario.Clear();
            txbRua.Clear();
            txbNumero.Clear();
            txbComplemento.Clear();
            txbBairro.Clear();
            txbCidade.Clear();
            cmbEstado.SelectedItem = "SP";
            mtxbCep.Clear();
            mtxbTelefoneFixo.Clear();
            mtxbTelefoneCelular.Clear();
            txbEmail.Clear();
            txbUsuario.Clear();
            txbSenha.Clear();
            rdbTipoAcessoComum.Checked = true; //COMUM
            cmbCargo.SelectedIndex = -1; //NENHUM CARGO PRÉ SELECIONADO

        }
        
        public FormFuncionario()
        {
            InitializeComponent();

        }
        //CRIAR VARIÁVEIS QEUE SERÃO UTILIZADAS NO FORM DE CONSULTA 
        //TIPO - MANEIRA QUE FORM SER´[A ABERTO 
        //OUTRAS VARIÁVEIS - EXIBIR OS DADOS QU ESTÃO ARMAZENADO NO BD E NÃO OS DECLARADOS NO LOAD DO FORM, TUDO QUE FOR COMBOBOX PRECISA TER UMA VARIÁVEL E DATA CADASTRO
        public string tipo, estado_civil, estado;
        public int cargo, tipo_acesso;
        public DateTime data_cadastro;




        private void FormFuncionario_Load(object sender, EventArgs e)
        {
            { // A DATA AUTOMÁTICA DE CADASTRO DO FUNCIONÁRIO - PARA EXIBIÇÃO
                lbDataCadastro.Text = DateTime.Now.ToShortDateString();
            }

            //CARREGAR COMBOS
            //COMBO ESTADO CIVIL

            cmbEstadoCivil.Items.Add("Solteiro(a)"); //  PRIMEIRA POSIÇÃO COMEÇA NO INDICE EM ZERO
            cmbEstadoCivil.Items.Add("Casado(a)");
            cmbEstadoCivil.Items.Add("Divorciado(a)");
            cmbEstadoCivil.Items.Add("Viúvo(a)");
            cmbEstadoCivil.Items.Add("Solteiro(a)");
            cmbEstadoCivil.Items.Add("Separado(a) Judicialmente");
            cmbEstadoCivil.Items.Add("União Estável(a)");
            //DEIXAR UM ESTADO CIVIL PRÉ SELECIONADO
            cmbEstadoCivil.SelectedIndex = 0;

            //SE UTILIZAR CMB NO TIPO DE ACESSO
            //cbmTipoAcesso.Items.Add("Comum");
            //cbmTipoAcesso.Items.Add("Administrador");
            //cbmTipoAcesso.SelectedIndex("Comum");

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

            //CMB CARGO - TRAZER DADOS DA TABELA CARGO DO BANCO DE DADOS
            //CRIAR OBJETO DA CLASSE CARGO PARA USAR O MÉTODO QUE VAI CARREGAR A COMBO

            classCargo cCargo = new classCargo();
            //CHAMAR O MÉTODO NA COMBO DE CARGO
            cmbCargo.DataSource = cCargo.CarregarComboCargo();
            //DISPLAY MEMBER - PARA MOSTRAR O QUE SERÁ EXIBIDO NA COMBO- NOME DA COLUNA DO BD
            cmbCargo.DisplayMember = "nome";
            //VALUE MEMBER - O QUE SERÁ ARMAZENADO NO BD - NOME DA COLUNA IGUAL ESTA NO BD
            cmbCargo.ValueMember = "codigo_cargo";
            //NÃO DEIXAR NENHUM CARGO SELECIONADO
            cmbCargo.SelectedIndex = -1;

        }
        //MÉTODO PARA PINTAR OS CAMPOS OBRIGATÓRIOS NO FORM
        private void CamposObrigatorios()
        {
            txbNome.BackColor = Color.FromArgb(188, 143, 143);
            mtxbDataNascimento.BackColor = Color.FromArgb(188, 143, 143);
            lbSexo.BackColor = Color.FromArgb(188, 143, 143);
            mtxbCpf.BackColor = Color.FromArgb(188, 143, 143);
            txbRua.BackColor = Color.FromArgb(188, 143, 143);
            txbNumero.BackColor = Color.FromArgb(188, 143, 143);
            txbBairro.BackColor = Color.FromArgb(188, 143, 143);
            txbCidade.BackColor = Color.FromArgb(188, 143, 143);
            cmbEstado.BackColor = Color.FromArgb(188, 143, 143);
            mtxbTelefoneCelular.BackColor = Color.FromArgb(188, 143, 143);
            mtxbTelefoneFixo.BackColor = Color.FromArgb(188, 143, 143);
            lbTipoAcesso.BackColor = Color.FromArgb(188, 143, 143);
            cmbCargo.BackColor = Color.FromArgb(188, 143, 143);
            txbEmail.BackColor = Color.FromArgb(188, 143, 143);
            mtxbCep.BackColor = Color.FromArgb(188, 143, 143);
            lbEstado.BackColor = Color.FromArgb(188, 143, 143);
            txbUsuario.BackColor = Color.FromArgb(188, 143, 143);
            txbSenha.BackColor = Color.FromArgb(188, 143, 143);
            lbCargo.BackColor = Color.FromArgb(188, 143, 143);
            txbNome.Focus();



        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {



            //CRIAR OBJETO DA CLASSE FUNCIONÁRIO
            classFuncionario cFuncionario = new classFuncionario();

            //VERIFICAR SE TODOS OS CAMPOS OBRIGATÓRIOS FORAM PREENCHIDOS PELO USUÁRIO
            if (string.IsNullOrWhiteSpace(txbNome.Text) || mtxbDataNascimento.Text == "  /  /    " || mtxbCpf.Text == "   .   .   -  " || string.IsNullOrWhiteSpace(txbRua.Text) || string.IsNullOrWhiteSpace(txbNumero.Text) || string.IsNullOrWhiteSpace(txbBairro.Text) || string.IsNullOrWhiteSpace(txbCidade.Text) || mtxbCep.Text == "     -   " || mtxbTelefoneCelular.Text == "(  )     -    " || mtxbTelefoneFixo.Text == "(  )    -    " || string.IsNullOrWhiteSpace(txbEmail.Text) || string.IsNullOrWhiteSpace(txbUsuario.Text) || string.IsNullOrWhiteSpace(txbSenha.Text) || cmbCargo.SelectedIndex == -1) 
            {
                MessageBox.Show("Favor verificar todos os campos obrigatórios", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CamposObrigatorios();

            }
            else // REALIZAR O CADASTRO, USUÁRIO PREENCHEU OS CAMPOS - MANDAR PARA AS PROPRIEDADES DA CLASSE TODOS OS CAMPOS QUE O USUÁRIO PODE PREENCHER DO FORMULÁRIO
            {
                cFuncionario.nome = txbNome.Text;
                cFuncionario.nome_social = txbNomeSocial.Text;
                cFuncionario.foto = "";
                cFuncionario.data_nascimento = Convert.ToDateTime(mtxbDataNascimento.Text);

                //SEXO RADIOBUTTON - VERIFICAR QUAL OPÇÃO USUÁRIO ESCOLHEU
                if (rdbSxFeminino.Checked)
                {
                    cFuncionario.sexo = "F";
                }
                else if (rdbSxMasculino.Checked)
                {
                    cFuncionario.sexo = "M";
                }
                else 
                {
                    cFuncionario.sexo = "N";
                }

         

                //ESTADO CIVIL - COMBO PRÉ SELECIONADA COM A OPÇÃO SELECIONE UM ESTADO CIVIL, FAZER IF SE OPÇÃO PADRÃO ESTIVER SELECIONADA MANDAR VAZIO PARA O BANCO
                if (cmbEstadoCivil.SelectedIndex == 0)
                {
                    cFuncionario.estado_civil = "";
                }
                else
                {
                    cFuncionario.estado_civil = cmbEstadoCivil.SelectedItem.ToString();
                }

                cFuncionario.cpf = mtxbCpf.Text;

                //RG - MÁSCARA CAMPO NÃO OBRIGATÓRIO, FAZER IF CASO USUÁRIO NÃO PREENCHA O CAMPO PARA MANDAR VAZIO NO BD E NÃO A MÁSCARA
                if (mtxbRg.Text == "  .   .   - ")
                {
                    cFuncionario.rg = "";
                }
                else
                {
                    cFuncionario.rg = mtxbRg.Text;
                }

                //SALÁRIO - CAMPO DECIMAL NÃO OBRIGATÓRIO NO BD, FAZER IF PARA MANDAR 0 CASO O USUÁRIO NÃO PREENCHA O CAMPO
                if (string.IsNullOrWhiteSpace(txbSalario.Text))
                {
                    cFuncionario.salario = 0;
                }
                else
                {
                    cFuncionario.salario = Convert.ToDecimal(txbSalario.Text);
                }
                cFuncionario.endereco = txbRua.Text;
                cFuncionario.numero = Convert.ToInt32(txbNumero.Text);
                cFuncionario.complemento = txbComplemento.Text;
                cFuncionario.bairro = txbBairro.Text;
                cFuncionario.cidade = txbCidade.Text;
                //ESTADO - COMBOBOX, MANDAR PARA O BD O ITEM SELECIONADO PELO USUÁRIO
                cFuncionario.estado = cmbEstado.SelectedItem.ToString();
                cFuncionario.cep = mtxbCep.Text;

                //CAMPOS TELEFONE - MASCARA CAMPO NÃO OBRIGATÓRIO NO BD, FAZER IF PARA NÃO IR A MÁSCARA PARA O BD, CASO USUÁRIO NÃO PREENCHA
                if (mtxbTelefoneFixo.Text == "(  )    -    ")
                {
                    cFuncionario.telefone_residencial = "";
                }
                else
                {
                    cFuncionario.telefone_residencial = mtxbTelefoneFixo.Text;
                }

                if (mtxbTelefoneCelular.Text == "(  )     -    ")
                {
                    cFuncionario.telefone_celular = "";
                }
                else
                {
                    cFuncionario.telefone_celular = mtxbTelefoneCelular.Text;
                }
                cFuncionario.email = txbEmail.Text;
                cFuncionario.usuario = txbUsuario.Text;
                cFuncionario.senha = txbSenha.Text;

                //TIPO DE ACESSO - COMBO -- INDEX 0 COMUM - INDEX 1 ADMINISTRADOR
                //cFuncionario.tipo_acesso = rdbTipoAcesso.SelectedIndex;
                //IF PARA TRATAR O  TIPO DE ACESSO SELECIONADO
                if (rdbTipoAcessoComum.Checked)
                {
                    cFuncionario.tipo_acesso = 0;
                }
                else
                {
                    cFuncionario.tipo_acesso = 1;
                }
             

                //CÓDIGO CARGO - FK - USAR A PROPRIEDADE SELECTEDVALUE DA COMBO, PARA PEGAR O CÓDIGO DO CARGO SELECIONADO PELO USUÁRIO
                cFuncionario.codigo_cargo = Convert.ToInt32(cmbCargo.SelectedValue);

                //CHAMAR O MÉTODO DE CADASTRO DA CLASSE FUNCIONÁRIO
                int resp = cFuncionario.CadastrarFuncionario();

                //MOSTRAR O RESULTADO DO MÉTODO PARA O USUÁRIO
                //SE DEU CERTO - CADASTRO REALIZADO 1
                if (resp == 1)
                {
                    MessageBox.Show($"Funcionário: {cFuncionario.nome} cadastrado com sucesso", "Sistema Loja Hardware", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpar();
                }
                else
                {
                    MessageBox.Show("Erro ao realizar o cadastro", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                



            }
        }

        private void txbSalario_KeyPress(object sender, KeyPressEventArgs e)
        {
           
                // SÓ ACEITA A TECLA BACKSPACE E DIGITOS, SE NÃO FOR NÃO EXIBE
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    //IMMPEDE QUE O EVENTO SEJA EXEBIDO
                    e.Handled = true;
                }
            
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            //BTN LIMPAR CHAMA O MÉTODO PARA LIMPAR TODO O FORMULÁRIO
            Limpar();
        }
    }
}
