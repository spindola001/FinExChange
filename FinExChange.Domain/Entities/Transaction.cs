using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinExChange.Domain.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public decimal Amount { get; set; } // Valor a ser convertido
        public decimal Rate { get; set; } // Taxa utilizada na conversão
        public decimal Fee { get; set; } // Taxa administrativa
        public DateTime ExecutedAt { get; set; }
    }
}
