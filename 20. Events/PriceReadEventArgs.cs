namespace Events
{
    using System;

    public class PriceReadEventArgs : EventArgs
    {
        public PriceReadEventArgs(decimal price)
        {
            Price = price;
        }

        public decimal Price { get; }
    }
}
