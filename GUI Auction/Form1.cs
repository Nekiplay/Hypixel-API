using HypixelAPI.Auction;
using HypixelAPI.Auction.Classes;
using HypixelAPI.Bazar;
using System.Diagnostics;

namespace GUI_Auction
{
    public partial class Form1 : Form
    {
        AuctionManager auctionManager = new AuctionManager();
        BazarManager bazarManager = new BazarManager();
        
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            bazarManager.GetRootAsync((Bazar) =>
            {
                var carrot = Bazar.products.TOIL_LOG;
                Debug.WriteLine(carrot.buy_summary.Count);
            });
        }
    }
}