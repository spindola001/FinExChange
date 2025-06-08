using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinExChange.Domain.Entities
{
    public class Fee
    {
        public Guid Id { get; set; }
        public string FeeType { get; set; } // Ex: "Serviço", "Transferência", "Comissão"
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }
}
