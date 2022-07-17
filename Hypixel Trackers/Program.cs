using System;
using System.Drawing;

namespace Hypixel_Trackers
{
    internal class Program
    {
        //static Logging logging = new Logging();
        static void Main(string[] args)
        {
            Logging.Reg();
            Auction.Manager auctionManager = new Auction.Manager();

            auctionManager.GetRootsAsync(OnRootAsync);
            Logging.WriteLine("Загружаю данные!");
            Console.ReadLine();
        }
        static int smallest = 9999999;
        static void OnRootAsync(Auction.Implemantation.AuctionRoot auctionRoot)
        {
            var auctions = auctionRoot.auctions;
            foreach (var auction in auctions)
            {
                if (auction.item_name == "God Potion")
                {
                    if (auction.bin)
                    {
                        Logging.Write("Предмет: " + auction.item_name, Color.Yellow);
                        Logging.Write(" ");
                        if (auction.starting_bid > smallest)
                        {
                            Logging.Write("" + auction.starting_bid, Color.Red);
                            Logging.Write("\n", Color.White);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Logging.Write(" " + auction.starting_bid);
                            Console.ForegroundColor = ConsoleColor.White;
                            Logging.Write("\n", Color.White);
                        }

                        if (auction.starting_bid < smallest)
                        {
                            smallest = auction.starting_bid;
                        }
                        Logging.WriteLine("");
                    }
                }
            }
        }
    }
}