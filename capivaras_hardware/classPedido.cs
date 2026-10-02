using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace capivaras_hardware
{
    class classPedido

    {
        public classPedido()
        {
            codigo_pedido = 0;
            forma_pagamento = null;
            data_cadastro = DateTime.Now;
            desconto = 0;
            total = 0;
            codigo_cliente = 0;
            codigo_funcionario = 0;

        }

        public int codigo_pedido { get; set; }
        public string forma_pagamento { get; set; }
        public DateTime data_cadastro { get; set; }
        public int desconto { get; set; }
        public int total { get; set; }
        public int codigo_cliente { get; set; }
        public int codigo_funcionario { get; set; }







    }
  
}
