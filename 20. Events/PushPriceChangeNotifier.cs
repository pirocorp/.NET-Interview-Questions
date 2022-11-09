namespace Events;
using System;

public class PushPriceChangeNotifier
{
    private readonly decimal notificationThreshold;

    public PushPriceChangeNotifier(decimal notificationThreshold)
    {
        this.notificationThreshold = notificationThreshold;
    }

    public void Update(object? sender, PriceReadEventArgs eventArgs)
    {
        var currentBitcoinPrice = eventArgs.Price;

        if (currentBitcoinPrice > this.notificationThreshold)
        {
            Console.WriteLine($"Sending a push notification saying that"
                              + $" the Bitcoin price exceeded"
                              + $" {this.notificationThreshold} and is now"
                              + $" {currentBitcoinPrice}");
        }
    }
}
