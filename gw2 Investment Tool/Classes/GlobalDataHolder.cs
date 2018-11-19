using System.Collections.Generic;
using gw2_Investment_Tool.Models;

namespace gw2_Investment_Tool.Classes
{
	public static class GlobalDataHolder
	{
		public static int TotalGold = 0;
		public static float TotalKarma = 0;

		public static List<ItemFull> ItemNames = new List<ItemFull>();
		public static List<WhiteListedItem> WhiteListedItems = new List<WhiteListedItem>();
		
	}
}
