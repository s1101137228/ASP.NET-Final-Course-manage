using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCore.Models
{
    public class Goods
    {
        public string id { get; set; }

        public string name { get; set; }

        public Int32 price { get; set; }

        public Int32 num { get; set; }
        
        public string describe { get; set; }

        public DateTime time { get; set; }

        public string type { get; set; }

        public override string ToString()
        {
            return "Goods: id = " + id + ", name = " + name + ".";
        }
    }
}
