using HypixelAPI.Auction.Classes;
using Newtonsoft.Json;
using System.Net;

namespace HypixelAPI.Auction
{
    public class AuctionManager
    {
        public int pages = 0;
        public AuctionRoot GetRoot(int page = 0)
        {
            using (WebClient wc = new WebClient())
            {
                string url = "https://api.hypixel.net/skyblock/auctions?page=" + page;
                string json = wc.DownloadString(url);
                AuctionRoot auctionRoot = JsonConvert.DeserializeObject<AuctionRoot>(json);
                pages = auctionRoot.totalPages;
                wc.Dispose();
                return auctionRoot;
            }
        }
        public void GetRootAsync(Action<AuctionRoot> action, int page = 0)
        {
            using (WebClient wc = new WebClient())
            {
                string url = "https://api.hypixel.net/skyblock/auctions?page=" + page;
                wc.DownloadStringAsync(new Uri(url));
                wc.DownloadStringCompleted += (sender, e) =>
                {
                    AuctionRoot auctionRoot = JsonConvert.DeserializeObject<AuctionRoot>(e.Result);
                    pages = auctionRoot.totalPages;
                    if (action != null)
                    {
                        action(auctionRoot);
                    }
                    wc.Dispose();
                };
            }
        }
        public List<AuctionRoot> GetRoots()
        {
            List<AuctionRoot> roots = new List<AuctionRoot>();
            int max_pages = 1;
            int page = 0;

            do
            {
                using (WebClient wc = new WebClient())
                {
                    string url = "https://api.hypixel.net/skyblock/auctions?page=" + page;
                    string json = wc.DownloadString(url);
                    AuctionRoot auctionRoot = JsonConvert.DeserializeObject<AuctionRoot>(json);
                    max_pages = auctionRoot.totalPages;
                    pages = auctionRoot.totalPages;
                    roots.Add(auctionRoot);
                    wc.Dispose();
                }
                page++;
            }
            while (page < max_pages);
            return roots;
        }
        public void GetRootsAsync(Action<AuctionRoot> action)
        {
            int max_pages = 1;
            int page = 0;

            max_pages = GetRoot(0).totalPages;

            do
            {
                using (WebClient wc = new WebClient())
                {
                    string url = "https://api.hypixel.net/skyblock/auctions?page=" + page;
                    wc.DownloadStringAsync(new Uri(url));
                    wc.DownloadStringCompleted += (sender, e) =>
                    {
                        AuctionRoot auctionRoot = JsonConvert.DeserializeObject<AuctionRoot>(e.Result);
                        max_pages = auctionRoot.totalPages;
                        pages = auctionRoot.totalPages;
                        if (action != null)
                        {
                            action(auctionRoot);
                        }
                        wc.Dispose();
                    };
                }
                page++;
            }
            while (page < max_pages);
        }
    }
}
