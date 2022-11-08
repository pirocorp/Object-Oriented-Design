namespace Observer;

using System;

public class PushPriceChangeNotifier: IObserver<decimal>
{
    private readonly decimal notificationThreshold;

    public PushPriceChangeNotifier(decimal notificationThreshold)
    {
        this.notificationThreshold = notificationThreshold;
    }

    public void Update(decimal currentBitcoinPrice)
    {
        if (currentBitcoinPrice > this.notificationThreshold)
        {
            Console.WriteLine($"Sending a push notification saying that" 
                              + $" the Bitcoin price exceeded"
                              + $" {this.notificationThreshold} and is now"
                              + $" {currentBitcoinPrice}");
        }
    }
}