using System;
using System.Collections.Generic;
using System.Text;

namespace App_BancoDigital.Model
{
    public class Transacao
    {
        /**
         * Transação:
         * ContaOrigem:
         * ContaDestino:
         */
        public int Id { get; set; }
        public Conta ContaOrigem { get; set; }
        public Conta ContaDestino { get; set; }
        public double Valor { get; set; }
        public DateTime Data_Transacao { get; set; }    
    }
}
