using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypixel_Trackers.Auction.Implemantation
{
    public class Bid
    {
        public string auction_id { get; set; }
        public string bidder { get; set; }
        public string profile_id { get; set; }
        public int amount { get; set; }
        public object timestamp { get; set; }
    }
}
