namespace Observer;

using System;

public class EmailPriceChangeNotifier: IObserver<decimal>
{
    private readonly decimal notificationThreshold;

    public EmailPriceChangeNotifier(decimal notificationThreshold)
    {
        this.notificationThreshold = notificationThreshold;
    }

    public void Update(decimal currentBitcoinPrice)
    {
        if (currentBitcoinPrice > this.notificationThreshold)
        {
            Console.WriteLine($"Sending an email saying that" 
                              + $" the Bitcoin price exceeded"
                              + $" {this.notificationThreshold} and is now"
                              + $" {currentBitcoinPrice}");
        }
    }
}