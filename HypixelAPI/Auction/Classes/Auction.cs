namespace HypixelAPI.Auction.Classes
{
    public class Auction
    {
        public string uuid { get; set; }
        public string auctioneer { get; set; }
        public string profile_id { get; set; }
        public List<string> coop { get; set; }
        public object start { get; set; }
        public object end { get; set; }
        public string item_name { get; set; }
        public string item_lore { get; set; }
        public string extra { get; set; }
        public string category { get; set; }
        public string tier { get; set; }
        public int starting_bid { get; set; }
        public string item_bytes { get; set; }
        public bool claimed { get; set; }
        public List<object> claimed_bidders { get; set; }
        public int highest_bid_amount { get; set; }
        public object last_updated { get; set; }
        public bool bin { get; set; }
        public List<Bid> bids { get; set; }
        public string item_uuid { get; set; }
    }
}
