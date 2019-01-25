namespace gw2_Investment_Tool.Models
{
	public class ItemFull
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
