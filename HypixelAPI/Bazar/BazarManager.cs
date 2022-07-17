using HypixelAPI.Bazar.Classes;
using Newtonsoft.Json;
using System.Net;

namespace HypixelAPI.Bazar
{
    public class BazarManager
    {
        public BazarRoot GetRoot()
        {
            using (WebClient wc = new WebClient())
            {
                string url = "https://api.hypixel.net/skyblock/bazaar";
                string json = wc.DownloadString(url);
                BazarRoot bazarRoot = JsonConvert.DeserializeObject<BazarRoot>(json);
                wc.Dispose();
                return bazarRoot;
            }
        }

        public void GetRootAsync(Action<BazarRoot> action)
        {
            using (WebClient wc = new WebClient())
            {
                string url = "https://api.hypixel.net/skyblock/bazaar";
                wc.DownloadStringAsync(new Uri(url));
                wc.DownloadStringCompleted += (sender, e) =>
                {
                    BazarRoot bazarRoot = JsonConvert.DeserializeObject<BazarRoot>(e.Result);
                    if (action != null)
                    {
                        action(bazarRoot);
                    }
                    wc.Dispose();
                };
            }
        }
    }
}
