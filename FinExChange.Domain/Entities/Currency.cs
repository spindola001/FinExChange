using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinExChange.Domain.Entities
{
    public class Currency
    {
        public string Code { get; set; } // Ex: "USD", "EUR"
        public string Name { get; set; } // Ex: "Dólar Americano", "Euro"
        public string Symbol { get; set; } // "$", "€"
    }
}
