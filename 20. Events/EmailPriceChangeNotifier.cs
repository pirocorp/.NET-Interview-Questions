namespace Events;

using System;

public class EmailPriceChangeNotifier
{
    private readonly decimal notificationThreshold;

    public EmailPriceChangeNotifier(decimal notificationThreshold)
    {
        this.notificationThreshold = notificationThreshold;
    }

    public void Update(object? sender, PriceReadEventArgs eventArgs)
    {
        var currentBitcoinPrice = eventArgs.Price;

        if (currentBitcoinPrice > this.notificationThreshold)
        {
            Console.WriteLine($"Sending an email saying that"
                              + $" the Bitcoin price exceeded"
                              + $" {this.notificationThreshold} and is now"
                              + $" {currentBitcoinPrice}");
        }
    }
}
