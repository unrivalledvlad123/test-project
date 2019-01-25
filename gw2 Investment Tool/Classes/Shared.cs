using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gw2_Investment_Tool.Models;
using gw2_Investment_Tool.ServiceAccess;

namespace gw2_Investment_Tool.Classes
{
	public static class Shared
	{
		public static async Task<List<Recipe>> CombineFullRecipeData(List<Recipe> input)
		{
			List<int> recipeItemIds = new List<int>();
			List<int> recipeGuildItemIds = new List<int>();
			int globalMissingItemIndex = 0;

			foreach (Recipe recipe in input)
			{
				if (recipe.type == "GuildConsumable" || recipe.type == "GuildDecoration" ||
					recipe.type == "GuildConsumableWvw")
				{
					if (recipe.guild_ingredients != null)
					{
						recipeGuildItemIds.AddRange(
							recipe.guild_ingredients.Select(ingredients => ingredients.upgrade_id));
					}

					recipeGuildItemIds.Add(recipe.output_upgrade_id);
					if (recipe.ingredients != null)
					{
						recipeItemIds.AddRange(recipe.ingredients.Select(ingredients => ingredients.item_id));
					}

					recipeItemIds.Add(recipe.output_item_id);
				}
				else
				{
					recipeItemIds.AddRange(recipe.ingredients.Select(ingredients => ingredients.item_id));
					recipeItemIds.Add(recipe.output_item_id);
				}
			}

			//remove dublicate Ids to reduce apiCalls
			var noDupesGuildItems = recipeGuildItemIds.Distinct().ToList();
			var noDupesItems = recipeItemIds.Distinct().ToList();

			// do mass calls
			var allGuildItemsDetails = await SAItems.GetAllGuildItemsAsync(noDupesGuildItems);
			var allItemsDetails = await SAItems.GetAlItemsAsync(noDupesItems);

			foreach (var recipe in input)
			{
				if (recipe.type == "GuildConsumable" || recipe.type == "GuildDecoration" ||
					recipe.type == "GuildConsumableWvw")
				{
					if (recipe.guild_ingredients != null)
					{
						foreach (var ingredients in recipe.guild_ingredients)
						{
							GuildItemFull ingData = allGuildItemsDetails.First(p => p.id == ingredients.upgrade_id);
							ingredients.name = ingData.name;
						}
					}

					if (recipe.ingredients != null)
					{
						foreach (var ingredients in recipe.ingredients)
						{
							ItemFull ingData = allItemsDetails.FirstOrDefault(p => p.id == ingredients.item_id);
							if (ingData != null) ingredients.name = ingData.name;
						}
					}

					GuildItemFull nameData =
						allGuildItemsDetails.FirstOrDefault(p => p.id == recipe.output_upgrade_id);
					if (nameData == null)
					{
						globalMissingItemIndex++;
						recipe.OutputItemName = "Missing Name" + globalMissingItemIndex;
						recipe.Description = "Missing Description";
						recipe.Rarity = "Common";
					}
					else
					{
						recipe.OutputItemName = nameData.name;
						recipe.Description = nameData.description;
						recipe.Rarity = "Common";
					}
				}
				else
				{
					foreach (var ingredients in recipe.ingredients)
					{
						ItemFull ingData = allItemsDetails.FirstOrDefault(p => p.id == ingredients.item_id);
						if (ingData != null)
						{
							ingredients.name = ingData.name;
						}
					}

					ItemFull nameData = allItemsDetails.FirstOrDefault(p => p.id == recipe.output_item_id);
					if (nameData != null)
					{
						recipe.OutputItemName = nameData.name;
						if (nameData.details != null)
						{
							recipe.Description = nameData.details.description ?? nameData.description;
						}
						else
						{
							recipe.Description = nameData.description;
						}

						recipe.Rarity = nameData.rarity;
						recipe.type = nameData.type;
						recipe.flags = nameData.flags;
					}
				}
			}

			return input;
		}
	}
}
