using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace capivaras_hardware
{
    class classCliente
    {
        //CONSTRUTOR DA CLASSE
        public classCliente()
        {
            codigo_cliente = 0;
            nome = null;
            nome_social = null;
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
        public string nome_social { get; set; }
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
            string sql = $"INSERT INTO cliente VALUES(0, '{nome}','{nome_social}', '{cpf}', '{data_nascimento.ToString("yyyy-MM-dd")}', '{telefone}','{email}', '{endereco}', '{numero}', '{complemento}', '{bairro}', '{cidade}', '{estado}', '{cep}',  '{senha}', '{sexo}', NOW(), 1);";
            classConexao cConexao = new classConexao();
            return cConexao.ExecutaQuery(sql);
        }

        //FILTROS DE CONSULTA DO CLIENTE

        //CONSULTA DE CLIENTE POR NOME (INÍCIO)
        public DataTable ConsClienteNomeInicio(string nomei)
        {
            string sql = $"SELECT codigo_cliente 'ID', nome 'Nome', cpf 'CPF', data_nascimento 'Nascimento', sexo 'Sexo', cidade 'Cidade', telefone 'Telefone' FROM cliente WHERE status = 1 AND nome LIKE '{nomei}%' ORDER BY nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        //CONSULTA DE CLIENTE POR NOME (CONTÉM)
        public DataTable ConsClienteNomeContm(string nomec)
        {
            string sql = $"SELECT codigo_cliente 'ID', nome 'Nome', cpf 'CPF', data_nascimento 'Nascimento', sexo 'Sexo', cidade 'Cidade', telefone 'Telefone' FROM cliente WHERE status = 1 AND nome LIKE '%{nomec}%' ORDER BY nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        //CONSULTA DE CLIENTE POR CIDADE
        public DataTable ConsClienteCidade(string cidade)
        {
            string sql = $"SELECT codigo_cliente 'ID', nome 'Nome', cpf 'CPF', data_nascimento 'Nascimento', sexo 'Sexo', cidade 'Cidade', telefone 'Telefone' FROM cliente WHERE status = 1 AND cidade = '{cidade}' ORDER BY nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        //CONSULTA DE CLIENTE POR CPF
        public DataTable ConsClienteCpf(string cpf)
        {
            string sql = $"SELECT codigo_cliente 'ID', nome 'Nome', cpf 'CPF', data_nascimento 'Nascimento', sexo 'Sexo', cidade 'Cidade', telefone 'Telefone' FROM cliente WHERE status = 1 AND cpf = '{cpf}' ORDER BY nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        //CONSULTA DE CLIENTE POR SEXO
        public DataTable ConsClienteSexo(string sexo)
        {
            string sql = $"SELECT codigo_cliente 'ID', nome 'Nome', cpf 'CPF', data_nascimento 'Nascimento', sexo 'Sexo', cidade 'Cidade', telefone 'Telefone' FROM cliente WHERE status = 1 AND sexo = '{sexo}' ORDER BY nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        //CONSULTA DE CLIENTE POR STATUS
        public DataTable ConsClienteStatus(int status)
        {
            string sql = $"SELECT codigo_cliente 'ID', nome 'Nome', cpf 'CPF', data_nascimento 'Nascimento', sexo 'Sexo', cidade 'Cidade', telefone 'Telefone' FROM cliente WHERE status = {status} ORDER BY nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        //MÉTODO PARA CARRGAR AS CIDADES CADASTRADAS DA TABELA DE CLIENTE NO FORM DE CONSULTA
        public DataTable CarregarComboCidade()
        {
            string sql = $"SELECT DISTINCT cidade FROM cliente WHERE status = 1 ORDER BY cidade;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }


        //MÉTODO PARA BUSCAR TODOS OS DADOS DO CLIENTE SELECIONADO NO FORMULÁRIO DE CONSULTA
        public bool DadosFuncionario(int codigo)
        {
            string sql = $"SELECT * FROM funcionario WHERE codigo_funcionario = {codigo}";

            classConexao classConexao = new classConexao();

            //MONTAR O DATABLE QUE RECEBERÁ TODOS OS DADOS DO CLIENTE ESCOLHIDO PELO USUÁRIO
            DataTable dt = classConexao.RetornaDados(sql);

            //SE A CONSULTA RETORNOU DADOS
            if (dt.Rows.Count > 0)
            {
                //EXIBIR TODOS OS CAMPOS DA TABELA DE CLIENTE
                codigo_cliente = Convert.ToInt32(dt.Rows[0]["codigo_funcionario"]);
                nome = Convert.ToString(dt.Rows[0]["nome"]);
                nome_social = Convert.ToString(dt.Rows[0]["nome_social"]);
                cpf = Convert.ToString(dt.Rows[0]["cpf"]);
                data_nascimento = Convert.ToDateTime(dt.Rows[0]["data_nascimento"]);
                telefone = Convert.ToString(dt.Rows[0]["telefone_celular"]);
                email = Convert.ToString(dt.Rows[0]["email"]);
                endereco = Convert.ToString(dt.Rows[0]["endereco"]);
                numero = Convert.ToInt32(dt.Rows[0]["numero"]);
                complemento = Convert.ToString(dt.Rows[0]["complemento"]);
                bairro = Convert.ToString(dt.Rows[0]["bairro"]);
                cidade = Convert.ToString(dt.Rows[0]["cidade"]);
                estado = Convert.ToString(dt.Rows[0]["estado"]);
                cep = Convert.ToString(dt.Rows[0]["cep"]);
                sexo = Convert.ToString(dt.Rows[0]["sexo"]);
                data_cadastro = Convert.ToDateTime(dt.Rows[0]["data_cadastro"]);
                status = Convert.ToInt32(dt.Rows[0]["status"]);

                return true;

            }
            else
            {
                return false;
            }
        }
        //MÉTODO PARA ATUALIZAR O CLIENTE
        public int AtualizarCliente()
        {
            string sql = $"UPDATE cliente SET codigo_cargo =  nome = '{nome}', nome_social= '{nome_social}', cpf = '{cpf}', data_nascimento ='{data_nascimento.ToString("yyyy-MM-dd")}', telefone = '{telefone}', email = '{email}',   endereco = '{endereco}', numero = { numero},  complemento = '{complemento}', bairro = '{bairro}', cidade = '{cidade}', estado = '{estado}', cep = '{cep}',  sexo = '{sexo}', senha = '{senha}', status = { status} WHERE codigo_cliente = { codigo_cliente };";

            classConexao cConexao = new classConexao();
            return cConexao.ExecutaQuery(sql);

        }
        //MÉTODO PARA EXCLUIR O CLIENTE

        public int ExcluirCliente()
        {
            string sql = $"DELETE FROM cliente WHERE codigo_cliente = {codigo_cliente}";
            classConexao cConexao = new classConexao();
            return cConexao.ExecutaQuery(sql);
        }












    }
}
