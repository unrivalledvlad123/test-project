using System.Collections.Generic;
using gw2_Investment_Tool.Classes;

namespace gw2_Investment_Tool.Models
{
	public class Recipe
	{
		public int id { get; set; }
		public int output_item_id { get; set; }
		public int output_item_count { get; set; }
		public List<Ingredient> ingredients { get; set; }
		public string type { get; set; }
		public int min_rating { get; set; }
		public string[] disciplines { get; set; }
		public string[] flags { get; set; }
		public List<GuildIngridient> guild_ingredients { get; set; }
		public int output_upgrade_id { get; set; }
		public string OutputItemName { get; set; }
		public string Description { get; set; }
		public string Rarity { get; set; }
		public string DisciplinesString { get; set; }
		public string FlagsString { get; set; }
	}
	
}
