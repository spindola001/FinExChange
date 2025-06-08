using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinExChange.Domain.Entities
{
    public class TransactionHistory
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid TransactionId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Status { get; set; } // Ex: "Concluído", "Falha"
    }
}
