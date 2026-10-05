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
        private void Limpar()
        {
            tbxNome.Clear();

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

                tbxNome.BackColor = Color.FromArgb(188, 143, 143);
                cmbCategoria.BackColor = Color.FromArgb(188, 143, 143);
                cmbMarca.BackColor = Color.FromArgb(188, 143, 143);
                txbPreco.BackColor = Color.FromArgb(188, 143, 143);
                txbFaturamento.BackColor = Color.FromArgb(188, 143, 143);

                tbxNome.Focus();

            }

            else
            {

                cProduto.nome = tbxNome.Text;

                cProduto.codigo_categoria = Convert.ToInt32(cmbCategoria.SelectedValue);

                cProduto.codigo_marca = Convert.ToInt32(cmbMarca.SelectedValue);

                cProduto.descricao = tbxDescricao.Text;

                cProduto.preco_produto = Convert.ToInt32(txbPreco.Text);

                cProduto.valor_faturamento = Convert.ToInt32(txbFaturamento.Text);

                cProduto.valor_lucro = Convert.ToInt32(txbLucro.Text);

                cProduto.valor_desconto = Convert.ToInt32(txbDesconto.Text);




                int resp = cProduto.cadastrarProduto();

                if (resp == 1)
                {
                    MessageBox.Show($"Produto: {cProduto.nome} cadastrado com sucesso", "Sistema Loja Hardware", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Erro ao realizar o cadastro", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }





            }


        }

        private void txbPreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }












    }
}
