using HypixelAPI.Items.Classes;
using Newtonsoft.Json;
using System.Net;

namespace HypixelAPI.Items
{
    public class ItemManager
    {
        public ItemRoot GetRoot()
        {
            using (WebClient wc = new WebClient())
            {
                string url = "https://api.hypixel.net/resources/skyblock/items";
                string json = wc.DownloadString(url);
                ItemRoot itemRoot = JsonConvert.DeserializeObject<ItemRoot>(json);
                wc.Dispose();
                return itemRoot;
            }
        }

        public void GetRootAsync(Action<ItemRoot> action)
        {
            using (WebClient wc = new WebClient())
            {
                string url = "https://api.hypixel.net/resources/skyblock/items";
                wc.DownloadStringAsync(new Uri(url));
                wc.DownloadStringCompleted += (sender, e) =>
                {
                    ItemRoot itemRoot = JsonConvert.DeserializeObject<ItemRoot>(e.Result);
                    if (action != null)
                    {
                        action(itemRoot);
                    }
                    wc.Dispose();
                };
            }
        }
    }
}
