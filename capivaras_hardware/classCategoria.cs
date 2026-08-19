using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            status = 0;

        }
        //PROPRIEDADES: LER OU ARMAZENAR OS DADOS QUE SERÃO ENVIADOS OU RETORNADOS DO BD
        //GET LÊ OS DADOS -- SET GRAVA OS DADOS
        public int codigo_categoria { get; set; }
        public string nome { get; set; }
        public DateTime data_cadastro { get; set; }
        public int status { get; set; }


    }
}
 