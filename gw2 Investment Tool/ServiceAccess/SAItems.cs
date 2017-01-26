using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using gw2_Investment_Tool.Classes;

namespace gw2_Investment_Tool.ServiceAccess
{
    class SAItems
    {

        public static async Task<ItemApi> GetItemsAsync(int itemId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.guildwars2.com");

                HttpResponseMessage response = await client.GetAsync($"/v2/items/{itemId}");
                if (response.IsSuccessStatusCode)
                {
                    var item = await response.Content.ReadAsAsync<ItemApi>();
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

        public static async Task<ItemPrices> GetItemPricesAsync(int itemId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.guildwars2.com");

                HttpResponseMessage response = await client.GetAsync($"/v2/commerce/prices/{itemId}");
                if (response.IsSuccessStatusCode)
                {
                    var price = await response.Content.ReadAsAsync<ItemPrices>();
                    return price;
                }

                return null;
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
            using (HttpClient client = new HttpClient())
            {
                List<OutputItemId> results = new List<OutputItemId>();
                client.BaseAddress = new Uri("https://api.guildwars2.com");
                int counter = 0;
                while (counter <= itemIds.Count)
                {
                    List<int> currentLoop = new List<int>();
                    for (int i = counter; i < counter + 100; i++)
                    {
                        if (i < itemIds.Count)
                        {
                            currentLoop.Add(itemIds[i]);
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

        public static async Task<List<ItemApi>> GetItemNamesAsync(List<OutputItemId> itemIds)
        {
            using (HttpClient client = new HttpClient())
            {
                List<ItemApi> results = new List<ItemApi>();
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
                        List<ItemApi> items = await response.Content.ReadAsAsync<List<ItemApi>>();
                        results.AddRange(items);
                    }
                }
                return results;
            }
        }
    }
}
