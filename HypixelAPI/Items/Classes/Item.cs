namespace HypixelAPI.Items.Classes
{
    public class Item
    {
        public string material { get; set; }
        public int durability { get; set; }
        public string skin { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public string tier { get; set; }
        public int npc_sell_price { get; set; }
        public string id { get; set; }
        public bool? glowing { get; set; }
        public bool? unstackable { get; set; }
    }
}
