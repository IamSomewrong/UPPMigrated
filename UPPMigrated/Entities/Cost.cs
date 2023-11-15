using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPPMigrated.Entities
{
    public class Cost
    {
        public int Id { get; set; }
        public int ShareId { get; set; }
        public Share? Share { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public List<Buy> Buys { get; set; } = new();
        public List<Sell> Sell { get; set;} = new();
    }
}
