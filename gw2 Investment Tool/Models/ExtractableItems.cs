namespace gw2_Investment_Tool.Models
{
	public class ExtractableItems
	{
		public int id { get; set; }
		public int buy_price { get; set; }
		public int sell_price { get; set; }
		public string name { get; set; }
		public int upgrade1 { get; set; }//upgradeId
		public int BuyoutProfit { get; set; }
		public int OrderProfit { get; set; }
		public string charm { get; set; }
		public ExtractableUpgradeComponents UpgradeComponent { get; set; }
	}
}
