using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace capivaras_hardware
{
    class classCargo
    {

        //CONSTRUTOR DA CLASSE: INICIALIZAR TODAS AS PROPRIEDADES DA CLASSE
        //O MÉTODO CONSTRUTOR PRECISA TER O MESMO NOME DA CLASSE

        public classCargo()
        {
            codigo_cargo = 0;
            nome = null;
            observacao = null;
            status = 0;
            data_cadastro = DateTime.Now;
        }
        //PROPRIEDADES: LER ARMAZENAS E CALCULAR OS DADOS QUE SERÃO ENVIADOS OU RETORNADOS DO BD
        //MESMO NOME E TIPO DE DADO DOS CAMPOS DO BD
        //ATALHO PARA CRIAR PROPRIEDADE NO C#: PROP TAB TAB 

        //get lê os dados -- set grava os dados.
        public int codigo_cargo { get; set; }
        public String nome { get; set; }
        public string observacao { get; set; }
        public int status { get; set; }
        public DateTime data_cadastro { get; set; }

        //MÉTODOS: FUNCIONALIDADES DO SISTEMA 
        //CRIAR MÉTODO: ENCAPSULAMENTO (PUBLIC/PRIVATE), TIPO DE RETORNO DO MÉTODO (INT/STRING/ BOOL/ DATATABLE), NOME DO MÉTODO, PARÂMETROS  () - CONDIÇÕES 

        //MÉTODO PARA CADASTRAR CARGO
        public int CadastrarCargo()
        {
            //VARIÁVEL STRING PARA ESCREVER O COMANDO QUE O MÉTODO TERÁ QUE EXECUTAR
            //USANDO INTERPOLAÇÃO DE STRING $ {} - CONCATENAÇÃO
            string sql = $"INSERT INTO cargo VALUES(0, '{nome}', '{observacao}', 1, NOW() ) ";
            //USANDO CONCATENAÇÃO PADRÃO DA LINGUAGEM +

            string sql1 = "INSERT INTO CARGO cargo VALUES(0, '" + nome + "', '" + observacao + "', 1, NOW()  );";


            //CRIAR O OBJETO DA CLASSE CONEXAO PARA USAR O MÉTODO QUE VAI EXECUTAR O COMANDO QUE ESCREVEMOS -- MÉTODO EXECUTAQUERY()
            classConexao cConexao = new classConexao();

            //CHAMAR O MÉTODO DA CLASSE CONEXAO QUE VAI EXECUTAR O COMANDO
            //RETURN 0 SE DEU ERRO 1 SE DEU CERTO
            return cConexao.ExecutaQuery(sql);

        }
        //MÉTODO PARA CARREGAR OS CARGOS NO FORMULÁRIO DE FUNCIONÁRIO

        public DataTable CarregarComboCargo()
        {
            string sql = "SELECT codigo_cargo, nome FROM cargo WHERE status = 1 ORDER BY nome;";


            //CRIAR O OBJETO DA CLASSE CONEXAO 

            classConexao cConexao = new classConexao();

            return cConexao.RetornaDados(sql);
        }





































    }
}
