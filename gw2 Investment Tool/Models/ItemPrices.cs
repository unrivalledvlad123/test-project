using System.Collections.Generic;

namespace gw2_Investment_Tool.Models
{
    public class ItemPrices
    {
        public int id { get; set; }
        public Prices buys { get; set; }
        public Prices sells { get; set; }
    }

    public class ItemListings
    {
        public int id { get; set; }
        public List<Prices> buys { get; set; }
        public List<Prices> sells { get; set; }
    }
}
