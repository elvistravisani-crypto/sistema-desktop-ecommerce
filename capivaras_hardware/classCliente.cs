using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capivaras_hardware
{
    class classCliente
    {
        //CONSTRUTOR DA CLASSE
        public classCliente()
        {
            codigo_cliente = 0;
            nome = null;
            cpf = null;
            data_nascimento = DateTime.Now;
            telefone = null;
            email = null;
            sexo = null;
            data_cadastro = DateTime.Now;
            status = 0;
        }
        //PROPRIEDADES: LER OU ARMAZENAR OS DADOS QUE SERÃO ENVIADOS OU RETORNADOS DO BD
        //GET LÊ OS DADOS -- SET GRAVA OS DADOS
        public int codigo_cliente { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public DateTime data_nascimento { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public string sexo { get; set; }

        public DateTime data_cadastro { get; set; }
        public int status { get; set; }

        public int cadastrarCliente()
        {

            //CRIAR A VARIÁVEL PARA COLOCAR O COMANDO QUE SERÁ USADO
            string sql = $"INSERT INTO funcionario VALUES(0, {codigo_cliente}, '{nome}', '{cpf}', '{data_nascimento.ToString("yyyy-MM-dd")}', '{telefone}',  '{email}', '{sexo}','{status}', '{salario.ToString().Replace(",", ".")}', , 1, NOW() );   ";

            classConexao cConexao = new classConexao();

            return cConexao.ExecutaQuery(sql);


        }







    }
}
