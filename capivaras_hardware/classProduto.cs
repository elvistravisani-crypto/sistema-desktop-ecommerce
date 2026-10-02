using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capivaras_hardware
{
    class classProduto
    {
        public classProduto()
        {
            codigo_produto = 0;
            codigo_categoria = 0;
            codigo_marca = 0;
            nome = null;
            valor_faturamento = 0;
            preco_produto = 0;
            data_cadastro = DateTime.Now;
            descricao = null;
            valor_lucro = 0;
            valor_desconto = 0;
            status = 0;
            ft_produto_1 = null;
            ft_produto_2 = null;
            ft_produto_3 = null;

        }

        public int codigo_produto { get; set; }
        public int codigo_categoria { get; set; }
        public int codigo_marca { get; set; }
        public string nome { get; set; }
        public decimal valor_faturamento { get; set; }
        public decimal preco_produto { get; set; }
        public DateTime data_cadastro { get; set; }
        public string descricao { get; set; }
        public decimal valor_lucro { get; set; }
        public decimal valor_desconto { get; set; }
        public int status { get; set; }
        public string ft_produto_1 { get; set; }
        public string ft_produto_2 { get; set; }
        public string ft_produto_3 { get; set; }


        //COMANDO SQL PARA CADASTRAR PRODUTO

        public int cadastrarProduto()
        {
            string sql = $"INSERT INTO produto VALUES (0,  {codigo_categoria}, {codigo_marca}, '{nome}', {valor_faturamento}, {preco_produto}, NOW(), '{descricao}', {valor_lucro}, {valor_desconto} 1, '{ft_produto_1}', '{ft_produto_2}', '{ft_produto_3}',)";

            classConexao cConexao = new classConexao();
            return cConexao.ExecutaQuery(sql);



        }










    }
}
