// Observer design pattern allows objects to notify other objects about
// changes in their state
namespace Observer
{
    using System;

    public static class Program
    {
        public static void Main()
        {
            var bitcoinPriceReader = new BitcoinPriceReader();

            var emailNotifier = new EmailPriceChangeNotifier(25000);
            var pushNotifier = new PushPriceChangeNotifier(40000);

            bitcoinPriceReader.AttachObserver(emailNotifier);
            bitcoinPriceReader.AttachObserver(pushNotifier);

            for (var i = 0; i < 2; i++)
            {
                bitcoinPriceReader.ReadCurrentPrice(); // chooses the price randomly
            }

            bitcoinPriceReader.DetachObserver(emailNotifier);
            Console.WriteLine("Emails DETACHED");

            for (var i = 0; i < 10; i++)
            {
                bitcoinPriceReader.ReadCurrentPrice();
            }
        }
    }
}
