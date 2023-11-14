using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPPMigrated.Entities
{
    internal class Sell
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int CostId { get; set; }
        public Cost? Cost { get; set; }
        public int Amount { get; set; }
    }
}
