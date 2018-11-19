using System;

namespace gw2_Investment_Tool.Models
{
	public class Item 
	{
		public int ItemId { get; set; }
		public int Quantity { get; set; }
		public string Discipline { get; set; }
		public Decimal? KarmaPerItem { get; set; }
		public bool Active { get; set; }
		public string Name { get; set; }
		public float? TotalKarma { get; set; }
        public int? CraftingPrice { get; set; }
	}
}
