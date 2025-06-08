using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinExChange.Domain.Entities
{
    public class TransactionLimit
    {
        public Guid Id { get; set; }
        public string Currency { get; set; }
        public decimal MinAmount { get; set; } // Valor mínimo permitido
        public decimal MaxAmount { get; set; } // Valor máximo permitido
    }
}
