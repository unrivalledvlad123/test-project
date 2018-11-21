using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gw2_Investment_Tool.Models
{
	public class ExtractableUpgradeComponents
	{
		public int id { get; set; }
		public int buy_quantity { get; set; }
		public int buy_price { get; set; }
		public int sell_quantity { get; set; }
		public int sell_price { get; set; }
		public string name { get; set; }

	}
}
