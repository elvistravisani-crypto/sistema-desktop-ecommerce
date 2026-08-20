using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace capivaras_hardware
{
    class classMarca
    {
        public classMarca()
        {
            codigo_marca = 0;
            nome = null;
            descricao = null;
            data_cadastro = DateTime.Now;
            status = 1;

        }
        public int codigo_marca { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public DateTime data_cadastro { get; set; }
        public int status { get; set; }


        public int CadastrarMarca()
        {
            //CRIAR A VARIÁVEL PARA COLOCAR O COMANDO QUE SERÁ USADO
            string sql = $"INSERT INTO categoria VALUES(0, '{nome}','{descricao}', NOW(),  1 );   ";

            classConexao cConexao = new classConexao();

            return cConexao.ExecutaQuery(sql);



        }










    }
}
