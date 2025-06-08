using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinExChange.Domain.Entities
{
    public class BankAccount
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; } // Ex: "Corrente", "Poupança"
        public string SwiftCode { get; set; } // Para transferências internacionais
    }

}
