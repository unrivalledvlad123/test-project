using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gw2_Investment_Tool.Classes
{
    public class WhiteListedItem
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public bool Active { get; set; }
        public int CurrentPrice { get; set; }
    }
}
