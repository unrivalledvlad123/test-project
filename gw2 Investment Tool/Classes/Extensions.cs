using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gw2_Investment_Tool.Classes
{
	public static class Extensions
	{
		public static List<Recipe> PrepareForFilter(this List<Recipe> recipes)
		{
			foreach (var recipe in recipes)
			{
				var str = string.Join(" ", recipe.disciplines);
				var str2 = string.Join(" ", recipe.flags);
				recipe.DisciplinesString = str;
				recipe.FlagsString = str2;
			}

			return recipes;
		}
	}
}
