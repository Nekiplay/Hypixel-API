using Hypixel_Trackers.Auction.Implemantation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Hypixel_Trackers.Auction
{
    public class Manager
    {
        public Manager()
        {

        }
        public AuctionRoot GetRoot(int page = 0)
        {
            using (WebClient wc = new WebClient())
            {
                string url = "https://api.hypixel.net/skyblock/auctions?page=" + page;
                string json = wc.DownloadString(url);
                AuctionRoot auctionRoot = JsonConvert.DeserializeObject<AuctionRoot>(json);
                return auctionRoot;
            }
        }
        public List<AuctionRoot> GetRoots()
        {
            List<AuctionRoot> roots = new List<AuctionRoot>();
            int max_pages = 1;
            int page = 0;

            do
            {
                Console.WriteLine(page);
                using (WebClient wc = new WebClient())
                {
                    string url = "https://api.hypixel.net/skyblock/auctions?page=" + page;
                    string json = wc.DownloadString(url);
                    AuctionRoot auctionRoot = JsonConvert.DeserializeObject<AuctionRoot>(json);
                    roots.Add(auctionRoot);
                    max_pages = auctionRoot.totalPages;
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
                        if (action != null)
                        {
                            action(auctionRoot);
                        }
                    };
                }
                page++;
            }
            while (page < max_pages);
        }
    }
}
