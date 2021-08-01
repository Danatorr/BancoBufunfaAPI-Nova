using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoBufunfaNovo.Models
{
    public class Conta
    {
        public int Id { get; set; }

        public int NumeroConta { get; set; }
        
        public double Saldo { get; private set; }

        public int clienteId { get; set; }
        public Cliente Cliente { get; set; }

        public char TipoDeConta { get; set; } //C || P 
    }
}
