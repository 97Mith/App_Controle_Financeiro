using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppControleFinanceiro.Models
{
    public class Transacao
    {
        public int Id { get; set; }
        public TransacaoTipo Type { get; set; }
        public String Nome { get; set; }
        public DateTimeOffset Data { get; set; } //DateTimeOffset quarda a data e hora do lugar que ela estava
        public decimal Valor { get; set; }
    }

    public enum TransacaoTipo
    {
        Income,
        Expenses
    }
}
