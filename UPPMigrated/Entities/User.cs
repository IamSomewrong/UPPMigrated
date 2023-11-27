using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPPMigrated.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = "user";    
        public double Balance { get; set; }
        public List<Buy> Buys { get; set; } = new();
        public List<Sell> Sells { get; set; } = new();
    }
}
