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
    public partial class formConsFuncionario : Form
    {
        public formConsFuncionario()
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

        private void formConsFuncionario_Load(object sender, EventArgs e)
        {
            //CARREGAR COMBO DE OPÇOES DE CONSULTA
            cbFiltro.Items.Add("Nome");
            cbFiltro.Items.Add("Cargo");
            cbFiltro.Items.Add("Cidade");
            cbFiltro.Items.Add("CPF");
            cbFiltro.Items.Add("Sexo");
            cbFiltro.Items.Add("Data de Admissão");
            cbFiltro.Items.Add("Status");

            cbFiltro.SelectedIndex = 0;

            //CMB CARGO - TRAZER DADOS DA TABELA CARGO DO BANCO DE DADOS
            //CRIAR OBJETO DA CLASSE CARGO PARA USAR O MÉTODO QUE VAI CARREGAR A COMBO

            classCargo cCargo = new classCargo();
            //CHAMAR O MÉTODO NA COMBO DE CARGO
            cbCargo.DataSource = cCargo.CarregarComboCargo();
            //DISPLAY MEMBER - PARA MOSTRAR O QUE SERÁ EXIBIDO NA COMBO- NOME DA COLUNA DO BD
            cbCargo.DisplayMember = "nome";
            //VALUE MEMBER - O QUE SERÁ ARMAZENADO NO BD - NOME DA COLUNA IGUAL ESTA NO BD
            cbCargo.ValueMember = "codigo_cargo";
            //NÃO DEIXAR NENHUM CARGO SELECIONADO
            cbCargo.SelectedIndex = -1;

            //COMBO SEXO
            cbSexo.Items.Add("Feminino");
            cbSexo.Items.Add("Masculino");
            cbSexo.Items.Add("Não informado");

            //CARREGAR COMBO CIDADE
            classFuncionario cFuncionario = new classFuncionario();
            cbCidade.DataSource = cFuncionario.CarregarComboCidade();
            cbCidade.DisplayMember = "cidade";
            cbCidade.ValueMember = "cidade";
            cbCidade.SelectedIndex = 0;


            
            


        }
        
        

        private void OcultarFiltros()
        {
            gbNome.Visible = false;
            gbCargo.Visible = false;
            gbCidade.Visible = false;
            gbCPF.Visible = false;
            gbSexo.Visible = false;
            gbDataAdmissao.Visible = false;
            gbStatus.Visible = false;
        }

        private void cbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            OcultarFiltros();

            int filtro = cbFiltro.SelectedIndex;

            switch (filtro)
            {
                case 0:
                    gbNome.Visible = true;
                    txtNome.Focus();
                    break;

                case 1:
                    gbCargo.Visible = true;
                    break;

                case 2:
                    gbCidade.Visible = true;                 
                    break;

                case 3:
                    gbCPF.Visible = true;
                    break;              

                case 4:
                    gbSexo.Visible = true;                    
                    break;

                case 5:
                    gbDataAdmissao.Visible = true;                   
                    break;

                case 6:
                    gbStatus.Visible = true;                   
                    break;
            }
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            //CRIANDO UM OBJETO DA CLASSE FUNCIONÁRIO PARA USAR OS MÉTODOS DE CONSULTA E PROPRIEDADES
            classFuncionario cFuncionario = new classFuncionario();

            //CRIAR VARIÁVEL QUE VAI ALIMENTAR O SWITCH
            int filtro = cbFiltro.SelectedIndex;
            
         
            switch(filtro) //USUÁRIO ESCOLHO OPÇÃO E SISTEMA LÊ A POSIÇÃO DO ITEM NA LISTA (SELECTDINDEX)
            {
                //CARGO
                case 1:
                    dgvFuncionario.DataSource = cFuncionario.ConsFuncCargo(Convert.ToInt32(cbCargo.SelectedValue));

                    break;

                //CIDADE
                case 2:
                    dgvFuncionario.DataSource = cFuncionario.ConsFuncCidade(cbCidade.SelectedValue.ToString());
                    break;

                //CPF
                case 3:
                    //VALIDAR SE USUÁRIO INFORMOU UM CPF
                    if(mskCpf.Text != "   .   .   -")
                    {
                        dgvFuncionario.DataSource = cFuncionario.ConsFunCpf(mskCpf.Text);
                    }
                    else
                    {
                        MessageBox.Show("Favor inserir um CPF completo", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        mskCpf.Focus();
                    }

                    break;

                //SEXO
                case 4:
                    //FEMININO
                    if(cbSexo.SelectedIndex == 0)
                    {
                        dgvFuncionario.DataSource = cFuncionario.ConsFuncSexo("F");
                    }
                    else if(cbSexo.SelectedIndex == 1) //MASCULINO
                    {
                        dgvFuncionario.DataSource = cFuncionario.ConsFuncSexo("M");
                    }
                    else //NÃO INFORMADO
                    {
                        dgvFuncionario.DataSource = cFuncionario.ConsFuncSexo("N");
                    }
                    break;
                //DATA ADMISSÃO
                //VOLTAR PARA VALIDAR DATA INICIAL E DATA FINAL
                case 5:
                    dgvFuncionario.DataSource = cFuncionario.ConsFuncDataAdmissao(dtpDataInicial.Value, dtpDataFinal.Value);
                    break;

                //STATUS
                case 6:
                    //ATIVO
                    if(rbAtivo.Checked)
                    {
                        dgvFuncionario.DataSource = cFuncionario.ConsFunStatus(1);
                    }
                    else //INATIVO
                    {
                        dgvFuncionario.DataSource = cFuncionario.ConsFunStatus(0);
                    }


                    break;
                //NOME
                //VALIDAR SE USUÁRIO PREENCHEU O NOME
                    default:
                    if (string.IsNullOrWhiteSpace(txtNome.Text))
                    {
                        MessageBox.Show("Favor informar um nome", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else 
                    {
                        //USUÁRIO ESCOLHEU A OPÇÃO CONTÉM
                        if(rbContem.Checked)
                        {
                            dgvFuncionario.DataSource = cFuncionario.ConsFuncNomeContm(txtNome.Text);
                        }
                        else //OPÇÃO INICIO
                        {
                            dgvFuncionario.DataSource = cFuncionario.ConsFuncNomeInicio(txtNome.Text);
                        }

                    }
                    break;







            }//FIM DO SWITCH



        }

        private void dgvFuncionario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Deseja alterar ou exluir o funcionário selecionado?","Atenção!" , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //INSTANCIAR A CLASSE FUNCIONÁRIO
                classFuncionario cFuncionario = new classFuncionario();

                //INSTANCIAR O FORMULÁRIO DE CADASTRO DE FUNCIONÁRIO - PARA MANDAR AS INFORMAÇÕES DO BANCO PARA O FORM
                FormFuncionario fFuncionario = new FormFuncionario();

                //PEGAR O FUNCIONÁRIO ESCOLHIDO PELO USUÁRIO ATRAVÉS DA SELEÇÃO NA GRID
                cFuncionario.DadosFuncionario(Convert.ToInt32(dgvFuncionario.SelectedRows[0].Cells[0].Value));

                //passar os dados do bd para os elementos do form de cadastro
                fFuncionario.codigo_funcionario.Text = cFuncionario.codigo_funcionario.ToString();
                fFuncionario.txbNome.Text = cFuncionario.nome.ToString();
                fFuncionario.txbNomeSocial.Text = cFuncionario.nome_social.ToString();
                fFuncionario.mtxbDataNascimento.Text = cFuncionario.data_nascimento.ToString();
                //SEXO - FAZER IF PARA LER O QUE ESTÁ ARMAZENADO NO BD E DEIXAR O RADIO BUTTON SELECIONADO
                if (cFuncionario.sexo == "F")
                {
                    fFuncionario.rdbSxFeminino.Checked = true;
                }
                else if (cFuncionario.sexo == "M") // Verifique se no seu banco 'M' é Masculino
                {
                    fFuncionario.rdbSxMasculino.Checked = true;
                }
                else // "N" ou Não informado
                {
                    fFuncionario.rdbSxNaoInformado.Checked = true;
                }
                //ESTADO CIVIL - 
                fFuncionario.estado_civil = cFuncionario.estado_civil;
                fFuncionario.mtxbCpf.Text = cFuncionario.cpf.ToString();
                fFuncionario.mtxbRg.Text = cFuncionario.rg.ToString();
                fFuncionario.txbSalario.Text = cFuncionario.salario.ToString();
                fFuncionario.txbRua.Text = cFuncionario.endereco.ToString();
                fFuncionario.txbNumero.Text = cFuncionario.numero.ToString();
                fFuncionario.txbComplemento.Text = cFuncionario.complemento.ToString();
                fFuncionario.txbBairro.Text = cFuncionario.bairro.ToString();
                fFuncionario.txbCidade.Text = cFuncionario.cidade.ToString();
                fFuncionario.estado = cFuncionario.estado.ToString();
                fFuncionario.mtxbCep.Text = cFuncionario.cep.ToString();
                fFuncionario.mtxbTelefoneFixo.Text = cFuncionario.telefone_residencial.ToString();
                fFuncionario.mtxbTelefoneCelular.Text = cFuncionario.telefone_celular.ToString();
                fFuncionario.txbEmail.Text = cFuncionario.email.ToString();
                fFuncionario.txbUsuario.Text = cFuncionario.usuario.ToString();
                fFuncionario.txbSenha.Text = cFuncionario.senha.ToString();
                fFuncionario.tipo_acesso = cFuncionario.tipo_acesso;

                //STATUS 
                if (cFuncionario.status == 1)
                {
                    fFuncionario.rdbStatusAtivo.Checked = true;
                }
                else
                {
                    fFuncionario.rdbStatusInativo.Checked = true;
                }

                //DATA CADASTRO MANDAR PARA A VARIÁVEL O VALOR ARMAZENADO NO BD
                fFuncionario.data_cadastro = cFuncionario.data_cadastro;
                //CÓDIGO CARGO - COMBO - MANDAR PARA A VARIÁVEL O VALOR ARMAZENADO NO BD
                fFuncionario.cargo = cFuncionario.codigo_cargo;

                //PASSAR A VARIÁVEL TIPO DECLARADA NO FORM DE CADASTRO COMO ELE SERÁ ABERTO - ATUALIZAÇÃO 
                fFuncionario.tipo = "Atualização";

                //CHAMAR O FORM DE CADASTRO COM OS DADOS CARREGADOR DO BD - MODO EXCLUSIVO: SHOWDIALOG
                fFuncionario.ShowDialog();

                //ATUALIZAR A GRID DE CONSULTA
                btPesquisar_Click(this, new EventArgs());







            }

        }









    }
}
