using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace capivaras_hardware
{
    class classFuncionario
    {
        //CONSTRUTOR DA CLASSE

        public classFuncionario()
        {
            codigo_funcionario = 0;
            nome = null;
            nome_social = null;
            foto = null;
            data_nascimento = DateTime.Now;
            sexo = null;
            estado_civil = null;
            cpf = null;
            rg = null;
            salario = 0;
            endereco = null;
            numero = 0;
            complemento = null;
            bairro = null;
            cidade = null;
            estado = null;
            cep = null;
            telefone_residencial = null;
            telefone_celular = null;
            email = null;
            usuario = null;
            senha = null;
            tipo_acesso = 0;
            status = 0;
            data_cadastro = DateTime.Now;
            codigo_cargo = 0;

        }
        //PROPRIEDADES: LER OU ARMAZENAR OS DADOS QUE SERÃO ENVIADOS OU RETORNADOS DO BD
        //GET LÊ OS DADOS -- SET GRAVA OS DADOS
        public int codigo_funcionario { get; set; }
        public string nome { get; set; }
        public string nome_social { get; set; }
        public string foto { get; set; }
        public DateTime data_nascimento { get; set; }
        public string sexo { get; set; }
        public string estado_civil { get; set; }
        public string cpf { get; set; }
        public string rg { get; set; }
        public decimal salario { get; set; }
        public string endereco { get; set; }
        public int numero { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string cep { get; set; }
        public string telefone_residencial { get; set; }
        public string telefone_celular { get; set; }
        public string email { get; set; }
        public string usuario { get; set; }
        public string senha { get; set; }
        public int tipo_acesso { get; set; }
        public int status { get; set; }
        public DateTime data_cadastro { get; set; }
        public int codigo_cargo { get; set; }

        //MÉTODOS 
        //COMPOS DATE:  propriedade. ToString("yyyy-MM-DD")
        //COMPOS DECIMAL: propriedade. ToString().Replace("," , ".")
        //ÑÃO PODE MANDAR ASPAS SIMPLES EM CAMPOS DO TIPO BIT

        //CADASTRAR FUNCIONÁRIO

        public int CadastrarFuncionario()
        {
            //CRIAR A VARIÁVEL PARA COLOCAR O COMANDO QUE SERÁ USADO
            string sql = $"INSERT INTO funcionario VALUES(0, {codigo_cargo}, '{nome}', '{nome_social}','{foto}', '{data_nascimento.ToString("yyyy-MM-dd")}', '{sexo}',  '{estado_civil}', '{cpf}','{rg}', '{salario.ToString().Replace(",", ".")}', '{endereco}', {numero}, '{complemento}', '{bairro}', '{cidade}', '{estado}', '{cep}', '{telefone_residencial}', '{telefone_celular}', '{email}', '{usuario}', '{senha}', {tipo_acesso}, 1, NOW() );   ";

            classConexao cConexao = new classConexao();

            return cConexao.ExecutaQuery(sql);



        }
















    }
}
