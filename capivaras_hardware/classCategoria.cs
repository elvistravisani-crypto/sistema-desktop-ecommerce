using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace capivaras_hardware
{
    class classCategoria
    {
        //CONSTRUTOR DA CLASSE
        public classCategoria()
        {
            codigo_categoria = 0;
            nome = null;
            data_cadastro = DateTime.Now;
            observacao = null;
            status = 1;

        }
        //PROPRIEDADES: LER OU ARMAZENAR OS DADOS QUE SERÃO ENVIADOS OU RETORNADOS DO BD
        //GET LÊ OS DADOS -- SET GRAVA OS DADOS
        public int codigo_categoria { get; set; }
        public string nome { get; set; }
        public string observacao { get; set; }
        public DateTime data_cadastro { get; set; }
        public int status { get; set; }

        public int CadastrarCategoria()
        {
            //CRIAR A VARIÁVEL PARA COLOCAR O COMANDO QUE SERÁ USADO
            string sql = $"INSERT INTO categoria VALUES(0, '{nome}', NOW(),'{observacao}',  1 );   ";

            classConexao cConexao = new classConexao();

            return cConexao.ExecutaQuery(sql);



        }



    }
}
 