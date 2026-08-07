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
        public FormFuncionario()
        {
            InitializeComponent();
        }

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

            //CMB CARGO - TRAZER DADOS DA TABELA CARGO DO BANDO DE DADOS
            //CREIAR OBJETO DA CLASSE CARGO PARA USAR O MÉTODO QUE VAI CARREGAR A COMBO

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
    }
}
