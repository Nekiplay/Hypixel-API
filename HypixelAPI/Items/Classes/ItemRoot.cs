namespace HypixelAPI.Items.Classes
{
    public class ItemRoot
    {
        public bool success { get; set; }
        public long lastUpdated { get; set; }
        public List<Item> items { get; set; }
    }
}
