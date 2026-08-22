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
            endereco = null;
            numero = 0;
            complemento = null;
            bairro = null;
            cidade = null;
            estado = null;
            cep = null;
            senha = null;
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
        public string endereco { get; set; }
        public int numero { get; set; }
        public string complemento{ get; set; }
        public string bairro { get; set; }
        public string cidade{ get; set; }
        public string estado { get; set; }
        public string cep { get; set; }
        public string senha { get; set; }
        public string sexo { get; set; }
        public DateTime data_cadastro { get; set; }
        public int status { get; set; }



        //CRIAR  VARIÁVEL PARA EXECUTAR O COMANDO QUE SERÁ USADO
        public int cadastrarCliente()
        {
            string sql = $"INSERT INTO cliente VALUES(0, '{nome}', '{cpf}', '{data_nascimento.ToString("yyyy-MM-dd")}', '{telefone}', '{endereco}', '{numero}', '{complemento}', '{bairro}', '{cidade}', '{estado}', '{cep}', '{email}', '{senha}', '{sexo}', NOW(), 1);";
            classConexao cConexao = new classConexao();
            return cConexao.ExecutaQuery(sql);
        }







    }
}
