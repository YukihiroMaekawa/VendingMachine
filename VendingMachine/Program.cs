using System;

namespace VendingMachine
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("自販機へのチャージ金額(枚数)を入れてください(500円,100円,50円,10円)"); 
            System.Console.WriteLine("120円の例-->0,1,2,0"); 
            var coin = System.Console.ReadLine();
            string[] coins = coin.ToString().Split(',');

            // チャージ
            VendingMachine cls = new VendingMachine();
            cls.AddAmount(Int32.Parse(coins[0]), Int32.Parse(coins[1]), Int32.Parse(coins[2]), Int32.Parse(coins[3]));

            System.Console.WriteLine("投入金額と購入金額をいれてください"); 
            System.Console.WriteLine("例)200,120"); 
            var price = System.Console.ReadLine();
            string[] prices = price.ToString().Split(','); 

            // 金額
            cls.PutMoney(Int32.Parse(prices[0]));

            // 購入
            cls.Purchase(Int32.Parse(prices[1]));
        }
    }
}
