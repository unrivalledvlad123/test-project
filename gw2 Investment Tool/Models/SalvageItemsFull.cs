namespace gw2_Investment_Tool.Models
{
	public class SalvageItemsFull
	{

		public int id { get; set; }
		public string name { get; set; }
		public int upgrade1 { get; set; }
		public int buy_price { get; set; }
		public int sell_price { get; set; }
		public string type { get; set; }
		public int level { get; set; }
		public string rarity { get; set; }
		public bool? NoSalvage { get; set; }
		public string charm { get; set; }
		public int statID { get; set; }
		public string statName { get; set; }
		public string weaponType { get; set; }
	
	}
}
