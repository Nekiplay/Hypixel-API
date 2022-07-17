namespace HypixelAPI.Auction.Classes
{
    public class AuctionRoot
    {
        public bool success { get; set; }
        public int page { get; set; }
        public int totalPages { get; set; }
        public int totalAuctions { get; set; }
        public long lastUpdated { get; set; }
        public List<Auction> auctions { get; set; }
    }
}
