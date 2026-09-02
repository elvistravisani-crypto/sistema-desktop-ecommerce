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
        
    }
}
