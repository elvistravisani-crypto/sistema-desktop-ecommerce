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

        /*CONSULTA DE FUNCIONÁRIO*/
        /* FILTROS: NOME(INÍCIO E CONTÉM), SEXO, CIDADE, CARGO, CPF, DATA ADMISSÃO E STATUS */
        /* CAMPOS EXIBIDOS NA CONSULTA: CODIGO, NOME, CPF, NASCIMENTO, CARGO, SEXO, CIDADE E CELULAR */

        //CONSUTA DE FUNCIONÁRIO POR NOME (INÍCIO)
        public DataTable ConsFuncNomeInicio(string nomei)
        {
            string sql = $"SELECT funcionario.codigo_funcionario 'ID', funcionario.nome 'Nome', funcionario.cpf 'CPF', funcionario.data_nascimento 'Nascimento', cargo.nome 'Cargo', funcionario.sexo 'Sexo', funcionario.cidade 'Cidade', funcionario.telefone_celular 'Celular' FROM funcionario JOIN cargo ON funcionario.codigo_cargo = cargo.codigo_cargo WHERE funcionario.status = 1 AND funcionario.nome LIKE '{nomei}%' ORDER BY funcionario.nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);

        }

        //CONSUTA DE FUNCIONÁRIO POR NOME (CONTÉM)
        public DataTable ConsFuncNomeContm(string nomec)
        {
            string sql = $"SELECT funcionario.codigo_funcionario 'ID', funcionario.nome 'Nome', funcionario.cpf 'CPF', funcionario.data_nascimento 'Nascimento', cargo.nome 'Cargo', funcionario.sexo 'Sexo', funcionario.cidade 'Cidade', funcionario.telefone_celular 'Celular' FROM funcionario JOIN cargo ON funcionario.codigo_cargo = cargo.codigo_cargo WHERE funcionario.status = 1 AND funcionario.nome LIKE '%{nomec}%' ORDER BY funcionario.nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);

        }

        //CONSUTA DE FUNCIONÁRIO POR SEXO   
        public DataTable ConsFuncSexo(string sexo)
        {
            string sql = $"SELECT funcionario.codigo_funcionario 'ID', funcionario.nome 'Nome', funcionario.cpf 'CPF', funcionario.data_nascimento 'Nascimento', cargo.nome 'Cargo', funcionario.sexo 'Sexo', funcionario.cidade 'Cidade', funcionario.telefone_celular 'Celular' FROM funcionario JOIN cargo ON funcionario.codigo_cargo = cargo.codigo_cargo WHERE funcionario.status = 1 AND funcionario.sexo = '{sexo}' ORDER BY funcionario.nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);

        }

        //CONSUTA DE FUNCIONÁRIO POR CIDADE  
        public DataTable ConsFuncCidade(string cidade)
        {
            string sql = $"SELECT funcionario.codigo_funcionario 'ID', funcionario.nome 'Nome', funcionario.cpf 'CPF', funcionario.data_nascimento 'Nascimento', cargo.nome 'Cargo', funcionario.sexo 'Sexo', funcionario.cidade 'Cidade', funcionario.telefone_celular 'Celular' FROM funcionario JOIN cargo ON funcionario.codigo_cargo = cargo.codigo_cargo WHERE funcionario.status = 1 AND funcionario.cidade = '{cidade}' ORDER BY funcionario.nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);

        }

        //CONSULTA DE FUNCIONÁRIO POR CARGO
        public DataTable ConsFuncCargo(int cargo)
        {
            string sql = $"SELECT funcionario.codigo_funcionario 'ID', funcionario.nome 'Nome', funcionario.cpf 'CPF', funcionario.data_nascimento 'Nascimento', cargo.nome 'Cargo', funcionario.sexo 'Sexo', funcionario.cidade 'Cidade', funcionario.telefone_celular 'Celular' FROM funcionario JOIN cargo ON funcionario.codigo_cargo = cargo.codigo_cargo WHERE funcionario.status = 1 AND funcionario.codigo_cargo = {cargo} ORDER BY funcionario.nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        //CONSULTA DE FUNCIONÁRIO POR CPF
        public DataTable ConsFunCpf(string cpf)
        {
            string sql = $"SELECT funcionario.codigo_funcionario 'ID', funcionario.nome 'Nome', funcionario.cpf 'CPF', funcionario.data_nascimento 'Nascimento', cargo.nome 'Cargo', funcionario.sexo 'Sexo', funcionario.cidade 'Cidade', funcionario.telefone_celular 'Celular' FROM funcionario JOIN cargo ON funcionario.codigo_cargo = cargo.codigo_cargo WHERE funcionario.status = 1 AND funcionario.cpf = '{cpf}' ORDER BY funcionario.nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        //CONSULTA DE FUNCIONÁRIO POR  DATA DE ADMISSÃO(CADASTRO)
        public DataTable ConsFuncDataAdmissao(DateTime datai, DateTime dataf)
        {
            string sql = $"SELECT funcionario.codigo_funcionario 'ID', funcionario.nome 'Nome', funcionario.cpf 'CPF', funcionario.data_nascimento 'Nascimento', cargo.nome 'Cargo', funcionario.sexo 'Sexo', funcionario.cidade 'Cidade', funcionario.telefone_celular 'Celular' FROM funcionario JOIN cargo ON funcionario.codigo_cargo = cargo.codigo_cargo WHERE funcionario.status = 1 AND CAST(funcionario.data_cadastro AS DATE) BETWEEN '{datai.ToString("yyyy-MM-dd")}' AND '{dataf.ToString("yyyy-MM-dd")}'  ORDER BY funcionario.nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        //CONSULTA DE FUNCIONÁRIO POR STATUS
        public DataTable ConsFunStatus(int status)
        {
            string sql = $"SELECT funcionario.codigo_funcionario 'ID', funcionario.nome 'Nome', funcionario.cpf 'CPF', funcionario.data_nascimento 'Nascimento', cargo.nome 'Cargo', funcionario.sexo 'Sexo', funcionario.cidade 'Cidade', funcionario.telefone_celular 'Celular' FROM funcionario JOIN cargo ON funcionario.codigo_cargo = cargo.codigo_cargo WHERE funcionario.status = {status} ORDER BY funcionario.nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }

        //MÉTODO PARA BUSCAR TODOS OS DADOS DO FUNCIONÁRIO SELECIONADO PELO USUÁRIO NO FORM DE CONSULTA
        public bool DadosFuncionario(int codigo)
        {
            string sql = $"SELECT * FROM funcionario WHERE codigo_funcionario = {codigo}";

            classConexao classConexao = new classConexao();

            //MONTAR O DATABLE QUE RECEBERÁ TODOS OS DADOS DO FUNCIONÁRIO ESCOLHIDO PELO USUÁRIO
            DataTable dt = classConexao.RetornaDados(sql);

            //SE A CONSULTA RETORNOU DADOS
            if (dt.Rows.Count > 0)
            {
                //EXIBIR TODOS OS CAMOS DA TABELA FUNCIONARIO
                codigo_funcionario = Convert.ToInt32(dt.Rows[0]["codigo_funcionario"]);
                nome = Convert.ToString(dt.Rows[0]["nome"]);
                nome_social = Convert.ToString(dt.Rows[0]["nome_social"]);
                foto = Convert.ToString(dt.Rows[0]["foto"]);
                data_nascimento = Convert.ToDateTime(dt.Rows[0]["data_nascimento"]);
                sexo = Convert.ToString(dt.Rows[0]["sexo"]);
                estado_civil = Convert.ToString(dt.Rows[0]["estado_civil"]);
                cpf = Convert.ToString(dt.Rows[0]["cpf"]);
                rg = Convert.ToString(dt.Rows[0]["rg"]);
                salario = Convert.ToDecimal(dt.Rows[0]["salario"]);
                endereco = Convert.ToString(dt.Rows[0]["endereco"]);
                numero = Convert.ToInt32(dt.Rows[0]["numero"]);
                complemento = Convert.ToString(dt.Rows[0]["complemento"]);
                bairro = Convert.ToString(dt.Rows[0]["bairro"]);
                cidade = Convert.ToString(dt.Rows[0]["cidade"]);
                estado = Convert.ToString(dt.Rows[0]["estado"]);
                cep = Convert.ToString(dt.Rows[0]["cep"]);
                telefone_residencial = Convert.ToString(dt.Rows[0]["telefone_residencial"]);
                telefone_celular = Convert.ToString(dt.Rows[0]["telefone_celular"]);
                email = Convert.ToString(dt.Rows[0]["email"]);
                usuario = Convert.ToString(dt.Rows[0]["usuario"]);
                senha = Convert.ToString(dt.Rows[0]["senha"]);
                tipo_acesso = Convert.ToInt32(dt.Rows[0]["tipo_acesso"]);
                status = Convert.ToInt32(dt.Rows[0]["status"]);
                data_cadastro = Convert.ToDateTime(dt.Rows[0]["data_cadastro"]);
                codigo_cargo = Convert.ToInt32(dt.Rows[0]["codigo_cargo"]);
                return true;

            }
            else
            {
                return false;
            }
        }

        //MÉTODO PARA ATUALIZAR FUNCIONÁRIO
        public int AtualizarFuncionario()
        {
           string sql =  $"UPDATE funcionario SET codigo_cargo = { codigo_cargo}, nome = '{nome}', nome_social= '{nome_social}', foto = '{foto}', data_nascimento ='{data_nascimento.ToString("yyyy-MM-dd")}', sexo = '{sexo}', estado_civil = '{estado_civil}', cpf = '{cpf}', rg = '{rg}', salario = '{salario.ToString().Replace(",", ".")}', endereco = '{endereco}', numero = { numero},  complemento = '{complemento}', bairro = '{bairro}', cidade = '{cidade}', estado = '{estado}', cep = '{cep}', telefone_residencial = '{telefone_residencial}', telefone_celular = '{telefone_celular}', email = '{email}', usuario =  '{usuario}', senha = '{senha}', tipo_acesso = { tipo_acesso}, status = { status} WHERE codigo_funcionario = { codigo_funcionario };";

        classConexao cConexao = new classConexao();
        return cConexao.ExecutaQuery(sql);

        }

        //MÉTODO PARA EXCLUIR FUNCIONÁRIO

        public int ExcluirFuncionario()
        {
            string sql = $"DELETE FROM funcionario WHERE codigo_funcionario = {codigo_cargo}";
            classConexao cConexao = new classConexao();
            return cConexao.ExecutaQuery(sql);
        }

        //MÉTODO PARA CARREGAR AS CIDADES CADASTRADAS DA TABELA DE FUNCIONÁRIO NO FORM DE CONSULTA
        public DataTable CarregarComboCidade()
        {
            string sql = $"SELECT DISTINCT cidade FROM funcionario WHERE status = 1 ORDER BY cidade;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDados(sql);
        }




    }
}
