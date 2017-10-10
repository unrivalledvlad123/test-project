using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gw2_Investment_Tool.Classes
{
    class ItemFull
    {
        public string name { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public string rarity { get; set; }
        public int id { get; set; }
        public string[] flags { get; set; }
        public ItemDetails details { get; set; }
	    public int level { get; set; }
	}
}
