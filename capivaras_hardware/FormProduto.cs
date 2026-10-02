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
    public partial class FormProduto : Form
    {
        public FormProduto()
        {
            InitializeComponent();
        }

        private void FormProdutos_Load(object sender, EventArgs e)
        {   // data de cadastro d
            lbDataCadastro.Text = DateTime.Now.ToShortDateString();

            //TRAZER DO BANCO A CATEGORIA PARA POVOAR A CMB DE CATEGORIA
            classCategoria cCategoria = new classCategoria();
            cmbCategoria.DataSource = cCategoria.CarregarComboCategoria();
            cmbCategoria.DisplayMember = "nome";
            cmbCategoria.ValueMember = "codigo_categoria";
            cmbCategoria.SelectedIndex = -1;




            //TRAZER DO BANCO A MARCA PARA POVOAR A CMB DE MARCA
            classMarca cMarca = new classMarca();
            cmbMarca.DataSource = cMarca.CarregarComboMarca();
            cmbMarca.DisplayMember = "nome";
            cmbMarca.ValueMember = "codigo_marca";
            cmbMarca.SelectedIndex = -1;



        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            //EVENTO DE CADASTRO DE PRODUTO
            //OBJETO DA CLASSE PRODUTO
            classProduto cProduto = new classProduto();

            //VALIDAÇÃO DE TODOS OS COMPOS OBRIGATÓRIOS ESTÃO PREENCHIDOS, SENÃO, GERAR AVISO !
            if (string.IsNullOrWhiteSpace(tbxNome.Text) || string.IsNullOrWhiteSpace(txbPreco.Text) || string.IsNullOrWhiteSpace(txbFaturamento.Text))
            {
                MessageBox.Show("Favor verificar se todos os campos obrigatórios estão preenchidos", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



        }












    }
}
