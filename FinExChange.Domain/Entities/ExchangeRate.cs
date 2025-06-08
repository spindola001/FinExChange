using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinExChange.Domain.Entities
{
    public class ExchangeRate
    {
        public Guid Id { get; set; }
        public string FromCurrency { get; set; } // Código da moeda de origem
        public string ToCurrency { get; set; } // Código da moeda de destino
        public decimal Rate { get; set; } // Taxa de câmbio
        public DateTime UpdatedAt { get; set; } // Data da última atualização
    }
}
