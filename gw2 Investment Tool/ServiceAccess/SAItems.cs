using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using gw2_Investment_Tool.Classes;
using gw2_Investment_Tool.Models;

namespace gw2_Investment_Tool.ServiceAccess
{
    class SAItems
    {

        public static async Task<ItemFull> GetItemsAsync(int itemId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.guildwars2.com");

                HttpResponseMessage response = await client.GetAsync($"/v2/items/{itemId}");
                if (response.IsSuccessStatusCode)
                {
                    var item = await response.Content.ReadAsAsync<ItemFull>();
                    return item;
                }

                return null;
            }
        }
 
        public static async Task<int[]> GetRecipesOutputAsync(int itemId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.guildwars2.com");

                HttpResponseMessage response = await client.GetAsync($"/v2/recipes/search?output={itemId}");
                if (response.IsSuccessStatusCode)
                {
                    var recipe = await response.Content.ReadAsAsync<int[]>();
                    return recipe;
                }

                return null;
            }
        }

        public static async Task<Recipe> GetRecipesIngredientsAsync(int recipeId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.guildwars2.com");

                HttpResponseMessage response = await client.GetAsync($"/v2/recipes/{recipeId}");
                if (response.IsSuccessStatusCode)
                {
                    var recipe = await response.Content.ReadAsAsync<Recipe>();
                    return recipe;
                }

                return null;
            }
        }

	    public static async Task<List<ItemPrices>> GetAllItemPrices(List<int> itemIds)
	    {
		    List<int> newCollection = itemIds.Distinct().ToList();
			using (HttpClient client = new HttpClient())
			{
				List<ItemPrices> results = new List<ItemPrices>();
				client.BaseAddress = new Uri("https://api.guildwars2.com");
				int counter = 0;
				while (counter <= newCollection.Count)
				{
					List<int> currentLoop = new List<int>();
					for (int i = counter; i < counter + 100; i++)
					{
						if (i < newCollection.Count)
						{
							currentLoop.Add(newCollection[i]);
						}
					}
					counter += 100;
					StringBuilder sb = new StringBuilder();
					foreach (var id in currentLoop)
					{
						sb.Append(id.ToString());
						sb.Append(",");
					}
					HttpResponseMessage response = await client.GetAsync($"/v2/commerce/prices?ids={sb}");
					if (response.IsSuccessStatusCode)
					{
						List<ItemPrices> items = await response.Content.ReadAsAsync<List<ItemPrices>>();
						results.AddRange(items);
					}
				}
				return results;
			}
		}

        public static async Task<List<ItemListings>> GetAllItemListnings(List<int> itemIds)
        {
	        List<int> newCollection = itemIds.Distinct().ToList();
			using (HttpClient client = new HttpClient())
            {
                List<ItemListings> results = new List<ItemListings>();
                client.BaseAddress = new Uri("https://api.guildwars2.com");
                int counter = 0;
                while (counter <= newCollection.Count)
                {
                    List<int> currentLoop = new List<int>();
                    for (int i = counter; i < counter + 100; i++)
                    {
                        if (i < newCollection.Count)
                        {
                            currentLoop.Add(newCollection[i]);
                        }
                    }
                    counter += 100;
                    StringBuilder sb = new StringBuilder();
                    foreach (var id in currentLoop)
                    {
                        sb.Append(id.ToString());
                        sb.Append(",");
                    }
                    HttpResponseMessage response = await client.GetAsync($"/v2/commerce/listings?ids={sb}");
                    if (response.IsSuccessStatusCode)
                    {
                        List<ItemListings> items = await response.Content.ReadAsAsync<List<ItemListings>>();
                        results.AddRange(items);
                    }
                }
                return results;
            }
        }



        public static async Task<List<int>> GetAllrecipeIdsAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.guildwars2.com");

                HttpResponseMessage response = await client.GetAsync("/v2/recipes");
                if (response.IsSuccessStatusCode)
                {
                    List<int> ids = await response.Content.ReadAsAsync<List<int>>();
                    return ids;
                }

                return null;
            }
        }

        public static async Task<List<OutputItemId>> GetRecipeOutputIdAsync(List<int> itemIds)
        {
	        List<int> newCollection = itemIds.Distinct().ToList();
			using (HttpClient client = new HttpClient())
            {
                List<OutputItemId> results = new List<OutputItemId>();
                client.BaseAddress = new Uri("https://api.guildwars2.com");
                int counter = 0;
                while (counter <= newCollection.Count)
                {
                    List<int> currentLoop = new List<int>();
                    for (int i = counter; i < counter + 100; i++)
                    {
                        if (i < newCollection.Count)
                        {
                            currentLoop.Add(newCollection[i]);
                        }
                    }
                    counter += 100;
                    StringBuilder sb = new StringBuilder();
                    foreach (var id in currentLoop)
                    {
                        sb.Append(id.ToString());
                        sb.Append(",");
                    }
                    HttpResponseMessage response = await client.GetAsync($"/v2/recipes?ids={sb}");
                    if (response.IsSuccessStatusCode)
                    {
                        List<OutputItemId> ids = await response.Content.ReadAsAsync<List<OutputItemId>>();
                        foreach (var id in ids)
                        {
                            if (results.FirstOrDefault(p => p.output_item_id == id.output_item_id) == null)
                            {
                                results.AddRange(ids);
                            }
                        }
                    }
                }
                return results;
            }
        }

        public static async Task<List<ItemFull>> GetItemNamesAsync(List<OutputItemId> itemIds)
        {
            using (HttpClient client = new HttpClient())
            {
                List<ItemFull> results = new List<ItemFull>();
                client.BaseAddress = new Uri("https://api.guildwars2.com");
                int counter = 0;
                while (counter <= itemIds.Count)
                {
                    List<int> currentLoop = new List<int>();
                    for (int i = counter; i < counter + 100; i++)
                    {
                        if (i < itemIds.Count)
                        {
                            currentLoop.Add(itemIds[i].output_item_id);
                        }
                    }
                    counter += 100;
                    StringBuilder sb = new StringBuilder();
                    foreach (var id in currentLoop)
                    {
                        sb.Append(id.ToString());
                        sb.Append(",");
                    }
                    HttpResponseMessage response = await client.GetAsync($"/v2/items?ids={sb}");
                    if (response.IsSuccessStatusCode)
                    {
                        List<ItemFull> items = await response.Content.ReadAsAsync<List<ItemFull>>();
                        results.AddRange(items);
                    }
                }
                return results;
            }
        }

        public static async Task<List<Recipe>> GetRecipeFullAsync(List<int> itemIds)
        {
	        List<int> newCollection = itemIds.Distinct().ToList();
			using (HttpClient client = new HttpClient())
            {
                List<Recipe> results = new List<Recipe>();
                client.BaseAddress = new Uri("https://api.guildwars2.com");
                int counter = 0;
                while (counter <= newCollection.Count)
                {
                    List<int> currentLoop = new List<int>();
                    for (int i = counter; i < counter + 100; i++)
                    {

                        if (i < newCollection.Count)
                        {
                            currentLoop.Add(newCollection[i]);
                        }
                    }
                    counter += 100;
                    StringBuilder sb = new StringBuilder();
                    foreach (var id in currentLoop)
                    {
                        sb.Append(id.ToString());
                        sb.Append(",");
                    }
                    HttpResponseMessage response = await client.GetAsync($"/v2/recipes?ids={sb}");
                    if (response.IsSuccessStatusCode)
                    {
                        List<Recipe> ids = await response.Content.ReadAsAsync<List<Recipe>>();
                        foreach (var id in ids)
                        {
                            if (results.FirstOrDefault(p => p.output_item_id == id.output_item_id) == null)
                            {
                                results.AddRange(ids);
                            }
                        }
                    }
                }
                return results;
            }
        }

		public static async Task<List<GuildItemFull>> GetAllGuildItemsAsync(List<int> itemIds)
        {
	        List<int> newCollection = itemIds.Distinct().ToList();
			using (HttpClient client = new HttpClient())
            {
                List<GuildItemFull> results = new List<GuildItemFull>();
                client.BaseAddress = new Uri("https://api.guildwars2.com");
                int counter = 0;
                while (counter <= newCollection.Count)
                {
                    List<int> currentLoop = new List<int>();
                    for (int i = counter; i < counter + 100; i++)
                    {
                        if (i < newCollection.Count)
                        {
                            currentLoop.Add(newCollection[i]);
                        }
                    }
                    counter += 100;
                    StringBuilder sb = new StringBuilder();
                    foreach (var id in currentLoop)
                    {
                        sb.Append(id.ToString());
                        sb.Append(",");
                    }
                    HttpResponseMessage response = await client.GetAsync($"/v2/guild/upgrades?ids={sb}");
                    if (response.IsSuccessStatusCode)
                    {
                        List<GuildItemFull> items = await response.Content.ReadAsAsync<List<GuildItemFull>>();
                        results.AddRange(items);
                    }
                }
                return results;
            }
        }
        public static async Task<List<ItemFull>> GetAlItemsAsync(List<int> itemIds)
        {
	        List<int> newCollection = itemIds.Distinct().ToList();
			using (HttpClient client = new HttpClient())
            {
                List<ItemFull> results = new List<ItemFull>();
                client.BaseAddress = new Uri("https://api.guildwars2.com");
                int counter = 0;
                while (counter <= newCollection.Count)
                {
                    List<int> currentLoop = new List<int>();
                    for (int i = counter; i < counter + 100; i++)
                    {
                        if (i < newCollection.Count)
                        {
                            currentLoop.Add(newCollection[i]);
                        }
                    }
                    counter += 100;
                    StringBuilder sb = new StringBuilder();
                    foreach (var id in currentLoop)
                    {
                        sb.Append(id.ToString());
                        sb.Append(",");
                    }
                    HttpResponseMessage response = await client.GetAsync($"/v2/items?ids={sb}");
                    if (response.IsSuccessStatusCode)
                    {
                        List<ItemFull> items = await response.Content.ReadAsAsync<List<ItemFull>>();
                        results.AddRange(items);
                    }
                }
                return results;
            }
        }
    }
}
