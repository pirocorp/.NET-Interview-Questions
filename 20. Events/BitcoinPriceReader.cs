namespace Events;

using System;

public class BitcoinPriceReader
{
    private decimal currentBitcoinPrice;

    // Events cannot be invoked outside their class
    // Only the class that owns the event can raise it
    private event EventHandler<PriceReadEventArgs>? PriceRead;

    public event EventHandler<PriceReadEventArgs>? PriceReadEvent
    {
        add => this.PriceRead += value;
        remove => this.PriceRead -= value;
    }

    public void ReadCurrentPrice()
    {
        this.currentBitcoinPrice = new Random().Next(0, 50_000);
        this.OnPriceRead(this.currentBitcoinPrice);
    }

    private void OnPriceRead(decimal currentPrice)
    {
        var args = new PriceReadEventArgs(currentPrice);

        this.PriceRead?.Invoke(this, args);
    }
}
