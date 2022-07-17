namespace HypixelAPI.Auction.Classes
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
