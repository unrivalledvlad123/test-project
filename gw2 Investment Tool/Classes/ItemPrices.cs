using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gw2_Investment_Tool.Classes
{
    class ItemPrices
    {
        public int id { get; set; }
        public Prices buys { get; set; }
        public Prices sells { get; set; }
    }
}
