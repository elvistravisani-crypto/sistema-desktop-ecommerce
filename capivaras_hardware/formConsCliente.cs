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

            //CARREGAR COMBO CIDADE
            classCliente cCliente = new classCliente();
            cbCidade.DataSource = cCliente.CarregarComboCidade();
            cbCidade.DisplayMember = "cidade";
            cbCidade.ValueMember = "cidade";
            cbCidade.SelectedIndex = 0;

            //COMBO SEXO
            cbSexo.Items.Add("Feminino");
            cbSexo.Items.Add("Masculino");
            cbSexo.Items.Add("Não informado");
        }

        private void OcultarFiltros()
        {
            gbNome.Visible = false;
            gbCargo.Visible = false;
            gbCidade.Visible = false;
            gbCPF.Visible = false;
            gbSexo.Visible = false;
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
                    gbCidade.Visible = true;
                    break;

                case 2:
                    gbCPF.Visible = true;
                    break;

                case 3:
                    gbSexo.Visible = true;
                    break;

                case 4:
                    gbStatus.Visible = true;
                    break;
            }
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            //CRIANDO UM OBJETO DA CLASSE CLIENTE PARA USAR OS MÉTODOS DE CONSULTA E PROPRIEDADES
            classCliente cCliente = new classCliente();

            //CRIAR VARIÁVEL QUE VAI ALIMENTAR O SWITCH
            int filtro = cbFiltro.SelectedIndex;

            switch (filtro) //USUÁRIO ESCOLHE A OPÇÃO E O SISTEMA LÊ A POSIÇÃO DO ITEM NA LISTA (SELECTDINDEX)
            {
                //CIDADE
                case 1:
                    dgvFuncionario.DataSource = cCliente.ConsClienteCidade(cbCidade.SelectedValue.ToString());
                    break;

                //CPF
                case 2:
                    //VALIDAR SE USUÁRIO INFORMOU UM CPF
                    if (mskCpf.Text != "   .   .   -")
                    {
                        dgvFuncionario.DataSource = cCliente.ConsClienteCpf(mskCpf.Text);
                    }
                    else
                    {
                        MessageBox.Show("Favor inserir um CPF completo", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        mskCpf.Focus();
                    }
                    break;

                //SEXO
                case 3:
                    //FEMININO
                    if (cbSexo.SelectedIndex == 0)
                    {
                        dgvFuncionario.DataSource = cCliente.ConsClienteSexo("F");
                    }
                    else if (cbSexo.SelectedIndex == 1) //MASCULINO
                    {
                        dgvFuncionario.DataSource = cCliente.ConsClienteSexo("M");
                    }
                    else //NÃO INFORMADO
                    {
                        dgvFuncionario.DataSource = cCliente.ConsClienteSexo("N");
                    }
                    break;

                //STATUS
                case 4:
                    //ATIVO
                    if (rbAtivo.Checked)
                    {
                        dgvFuncionario.DataSource = cCliente.ConsClienteStatus(1);
                    }
                    else //INATIVO
                    {
                        dgvFuncionario.DataSource = cCliente.ConsClienteStatus(0);
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
                        if (rbContem.Checked)
                        {
                            dgvFuncionario.DataSource = cCliente.ConsClienteNomeContm(txtNome.Text);
                        }
                        else //OPÇÃO INICIO
                        {
                            dgvFuncionario.DataSource = cCliente.ConsClienteNomeInicio(txtNome.Text);
                        }
                    }
                    break;

            }//FIM DO SWITCH
        }
    }
}