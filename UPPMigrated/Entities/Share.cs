using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPPMigrated.Entities
{
    internal class Share
    {
        public int Id { get; set; }
        public string Name { get; set; } = "share";
        public List<Cost> Costs { get; set; } = new();
    }
}
