using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gw2_Investment_Tool.Models;

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

		public static string ToGoldFormat(this int price)
		{
			string result;
			int copper = price % 100;
			int left = price / 100;
			int silver = left % 100;
			int gold = left / 100;
			if (gold == 0 && silver != 0)
			{
				result = $"{silver}s, {copper}c";
			}
			else if (gold == 0 && silver == 0)
			{
				result = $"{copper}c";
			}
			else
			{
				result = $"{gold}g, {silver}s, {copper}c";
			}
			return result;
		}
	}
}
