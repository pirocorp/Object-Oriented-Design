namespace Observer;

using System;
using System.Collections.Generic;

public class BitcoinPriceReader: IObservable<decimal>
{
    private decimal currentBitcoinPrice;
    private readonly List<IObserver<decimal>> observers = new();

    public BitcoinPriceReader()
    {
    }

    public void ReadCurrentPrice()
    {
        this.currentBitcoinPrice = new Random().Next(0, 50000);
        this.NotifyObservers();
    }

    public void AttachObserver(IObserver<decimal> observer)
    {
        this.observers.Add(observer);
    }

    public void DetachObserver(IObserver<decimal> observer)
    {
        this.observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(this.currentBitcoinPrice);
        }
    }
}