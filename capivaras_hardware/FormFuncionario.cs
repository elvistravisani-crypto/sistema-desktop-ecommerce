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
        // VARIÁVEIS QUE SERÃO UTILIZADAS NO FORM DE CONSULTA 
        public string tipo, estado_civil, estado;
        public int cargo, tipo_acesso;
        public DateTime data_cadastro;
        public bool status;

        public FormFuncionario()
        {
            InitializeComponent();
        }

        // MÉTODO PARA LIMPAR TODOS OS CAMPOS DO FORMULÁRIO QUANDO O CADASTRO FOR FINALIZADO
        private void Limpar()
        {
            txbNome.Clear();
            txbNomeSocial.Clear();
            mtxbDataNascimento.Clear();
            rdbSxFeminino.Checked = true;
            cmbEstadoCivil.SelectedIndex = 0; // SELECIONE ESTADO CIVIL
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
            rdbTipoAcessoComum.Checked = true; // COMUM
            cmbCargo.SelectedIndex = -1; // NENHUM CARGO PRÉ SELECIONADO
        }

        // MÉTODO PARA PINTAR OS CAMPOS OBRIGATÓRIOS NO FORM
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

        private void FormFuncionario_Load(object sender, EventArgs e)
        {
            // DATA AUTOMÁTICA DE CADASTRO DO FUNCIONÁRIO - PARA EXIBIÇÃO
            lbDataCadastro.Text = DateTime.Now.ToShortDateString();

            // CARREGAR COMBO ESTADO CIVIL
            cmbEstadoCivil.Items.Add("Solteiro(a)");
            cmbEstadoCivil.Items.Add("Casado(a)");
            cmbEstadoCivil.Items.Add("Divorciado(a)");
            cmbEstadoCivil.Items.Add("Viúvo(a)");
            cmbEstadoCivil.Items.Add("Separado(a) Judicialmente");
            cmbEstadoCivil.Items.Add("União Estável(a)");
            cmbEstadoCivil.SelectedIndex = 0;

            // POVOANDO A CMB ESTADO
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

            cmbEstado.Sorted = true;
            cmbEstado.SelectedItem = "SP";

            // CMB CARGO - TRAZER DADOS DA TABELA CARGO DO BANCO DE DADOS
            classCargo cCargo = new classCargo();
            cmbCargo.DataSource = cCargo.CarregarComboCargo();
            cmbCargo.DisplayMember = "nome";
            cmbCargo.ValueMember = "codigo_cargo";
            cmbCargo.SelectedIndex = -1;

            // VERIFICAÇÃO DO MODO DE ABERTURA - CASO FOR ATUALIZAÇÃO
            if (tipo == "Atualização")
            {
                lbTitulo.Text = "Atualização de funcionário";
                btnCadastrar.Enabled = false;
                plStatus.Enabled = true;
                lbDataCadastro.Text = data_cadastro.ToString();
                cmbEstado.SelectedItem = estado;
                cmbEstadoCivil.SelectedItem = estado_civil;
                cmbCargo.SelectedValue = cargo;

                if (tipo_acesso == 0)
                {
                    rdbTipoAcessoComum.Checked = true;
                    rdbTipoAcessoAdministrador.Checked = false;
                }
                else
                {
                    rdbTipoAcessoAdministrador.Checked = true;
                    rdbTipoAcessoComum.Checked = false;
                }
            }
            else
            {
                btnAtualizar.Enabled = false;
                btnExcluir.Enabled = false;
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            classFuncionario cFuncionario = new classFuncionario();

            // VERIFICAR SE TODOS OS CAMPOS OBRIGATÓRIOS FORAM PREENCHIDOS PELO USUÁRIO
            if (string.IsNullOrWhiteSpace(txbNome.Text) || mtxbDataNascimento.Text == "  /  /    " || mtxbCpf.Text == "   .   .   -  " || string.IsNullOrWhiteSpace(txbRua.Text) || string.IsNullOrWhiteSpace(txbNumero.Text) || string.IsNullOrWhiteSpace(txbBairro.Text) || string.IsNullOrWhiteSpace(txbCidade.Text) || mtxbCep.Text == "     -   " || mtxbTelefoneCelular.Text == "(  )      -    " || mtxbTelefoneFixo.Text == "(  )    -    " || string.IsNullOrWhiteSpace(txbEmail.Text) || string.IsNullOrWhiteSpace(txbUsuario.Text) || string.IsNullOrWhiteSpace(txbSenha.Text) || cmbCargo.SelectedIndex == -1)
            {
                MessageBox.Show("Favor verificar todos os campos obrigatórios", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CamposObrigatorios();
            }
            else
            {
                cFuncionario.nome = txbNome.Text;
                cFuncionario.nome_social = txbNomeSocial.Text;
                cFuncionario.foto = "";
                cFuncionario.data_nascimento = Convert.ToDateTime(mtxbDataNascimento.Text);

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

                if (cmbEstadoCivil.SelectedIndex == 0)
                {
                    cFuncionario.estado_civil = "";
                }
                else
                {
                    cFuncionario.estado_civil = cmbEstadoCivil.SelectedItem.ToString();
                }

                cFuncionario.cpf = mtxbCpf.Text;

                if (mtxbRg.Text == "  .   .   - ")
                {
                    cFuncionario.rg = "";
                }
                else
                {
                    cFuncionario.rg = mtxbRg.Text;
                }

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
                cFuncionario.estado = cmbEstado.SelectedItem.ToString();
                cFuncionario.cep = mtxbCep.Text;

                if (mtxbTelefoneFixo.Text == "(  )    -    ")
                {
                    cFuncionario.telefone_residencial = "";
                }
                else
                {
                    cFuncionario.telefone_residencial = mtxbTelefoneFixo.Text;
                }

                if (mtxbTelefoneCelular.Text == "(  )      -    ")
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

                if (rdbTipoAcessoComum.Checked)
                {
                    cFuncionario.tipo_acesso = 0;
                }
                else
                {
                    cFuncionario.tipo_acesso = 1;
                }

                cFuncionario.codigo_cargo = Convert.ToInt32(cmbCargo.SelectedValue);

                //LER O CODIGO DO FUNCIONÁRIO E MANDAR PARA A APROPRIEDADE DA CLASSE
                cFuncionario.codigo_funcionario = Convert.ToInt32(codigo_funcionario.Text);

                //LER O CODIGO DO FUNONÁRIO E MANDAR PARA A PROPRIEDADE DA CLASSE
                cFuncionario.codigo_funcionario = Convert.ToInt32(codigo_funcionario.Text);

                //FAZER IF PARA ATUALIZAÇÃO DO STATUS
                if (rdbStatusAtivo.Checked)
                {
                    cFuncionario.status = 1;
                }
                else
                {
                    cFuncionario.status = 0;
                }

                //CHAMAR O MÉTODO DE ATUALIZAÇÃO DA CLASSE FUNCIONÁRIO
                int resp = cFuncionario.AtualizarFuncionario();

                if (resp == 1)
                {
                    MessageBox.Show($"Funcionário: {cFuncionario.nome} Atualizado com sucesso", "Sistema Loja Hardware", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Deseja excluir o funcionário:{txbNome.Text}?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                classFuncionario cFuncionario = new classFuncionario();
                cFuncionario.codigo_funcionario = Convert.ToInt32(codigo_funcionario);

                int resp = cFuncionario.ExcluirFuncionario();

                if (resp == 1)
                {
                    MessageBox.Show("Funcionário excluído com sucesso", "Loja Hardwares", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Erro ao exluir", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            classFuncionario cFuncionario = new classFuncionario();

            // VERIFICAR SE TODOS OS CAMPOS OBRIGATÓRIOS FORAM PREENCHIDOS PELO USUÁRIO
            if (string.IsNullOrWhiteSpace(txbNome.Text) || mtxbDataNascimento.Text == "  /  /    " || mtxbCpf.Text == "   .   .   -  " || string.IsNullOrWhiteSpace(txbRua.Text) || string.IsNullOrWhiteSpace(txbNumero.Text) || string.IsNullOrWhiteSpace(txbBairro.Text) || string.IsNullOrWhiteSpace(txbCidade.Text) || mtxbCep.Text == "     -   " || mtxbTelefoneCelular.Text == "(  )      -    " || mtxbTelefoneFixo.Text == "(  )    -    " || string.IsNullOrWhiteSpace(txbEmail.Text) || string.IsNullOrWhiteSpace(txbUsuario.Text) || string.IsNullOrWhiteSpace(txbSenha.Text) || cmbCargo.SelectedIndex == -1)
            {
                MessageBox.Show("Favor verificar todos os campos obrigatórios", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CamposObrigatorios();
            }
            else
            {
                cFuncionario.nome = txbNome.Text;
                cFuncionario.nome_social = txbNomeSocial.Text;
                cFuncionario.foto = "";
                cFuncionario.data_nascimento = Convert.ToDateTime(mtxbDataNascimento.Text);

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

                if (cmbEstadoCivil.SelectedIndex == 0)
                {
                    cFuncionario.estado_civil = "";
                }
                else
                {
                    cFuncionario.estado_civil = cmbEstadoCivil.SelectedItem.ToString();
                }

                cFuncionario.cpf = mtxbCpf.Text;

                if (mtxbRg.Text == "  .   .   - ")
                {
                    cFuncionario.rg = "";
                }
                else
                {
                    cFuncionario.rg = mtxbRg.Text;
                }

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
                cFuncionario.estado = cmbEstado.SelectedItem.ToString();
                cFuncionario.cep = mtxbCep.Text;

                if (mtxbTelefoneFixo.Text == "(  )    -    ")
                {
                    cFuncionario.telefone_residencial = "";
                }
                else
                {
                    cFuncionario.telefone_residencial = mtxbTelefoneFixo.Text;
                }

                if (mtxbTelefoneCelular.Text == "(  )      -    ")
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

                if (rdbTipoAcessoComum.Checked)
                {
                    cFuncionario.tipo_acesso = 0;
                }
                else
                {
                    cFuncionario.tipo_acesso = 1;
                }

                cFuncionario.codigo_cargo = Convert.ToInt32(cmbCargo.SelectedValue);

                int resp = cFuncionario.CadastrarFuncionario();

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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }
    }
}