using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Persistence.Entities
{
    public class Server
    {
        public bool Active { get; set; }
        public string Customer { get; set; }
        public string MachineName { get; set; }
        public string Source { get; set; }
    }
}
