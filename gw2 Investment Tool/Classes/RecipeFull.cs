using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gw2_Investment_Tool.Classes
{
    class RecipeFull : Recipe
    {
        public string type { get; set; }
        public int min_rating { get; set; }
        public string[] disciplines { get; set; }
        public string[] flags { get; set; }
        public List<GuildIngridient> guild_ingredients { get; set; }
        public int output_upgrade_id { get; set; }
        public string OutputItemName { get; set; }
        public string Description { get; set; }
        public string Rarity { get; set; }
     
    }
}
