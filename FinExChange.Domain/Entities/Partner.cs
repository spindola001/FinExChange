using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinExChange.Domain.Entities
{
    public class Partner
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ApiUrl { get; set; } // URL da API externa
    }
}
