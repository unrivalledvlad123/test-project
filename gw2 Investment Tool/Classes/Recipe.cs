using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gw2_Investment_Tool.Classes
{
   public class Recipe
    {
        public int id { get; set; }
        public int output_item_id { get; set; }
        public int output_item_count { get; set; }
        public List<Ingredient> ingredients { get; set; } 
    }
}
