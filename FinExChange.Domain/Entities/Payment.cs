using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinExChange.Domain.Entities
{
    public class Payment
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public decimal Amount { get; set; }
        public string Method { get; set; } // Ex: "Cartão de Crédito", "Transferência Bancária"
        public string Status { get; set; } // Ex: "Pendente", "Concluído"
        public DateTime ProcessedAt { get; set; }
    }
}
