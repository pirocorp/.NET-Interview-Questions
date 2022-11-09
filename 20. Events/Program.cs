// An event is a message send by an object to signal the occurrence of an action
// Events are the .NET implementation of the Observer design pattern
namespace Events
{
    public static class Program
    {
        public static void Main()
        {
            var bitcoinReader = new BitcoinPriceReader();

            var emailNotifier = new EmailPriceChangeNotifier(25_000);
            var pushNotifier = new PushPriceChangeNotifier(40_000);

            bitcoinReader.PriceReadEvent += emailNotifier.Update;
            bitcoinReader.PriceReadEvent += pushNotifier.Update;

            bitcoinReader.ReadCurrentPrice();
            bitcoinReader.ReadCurrentPrice();

            // It's important to unsubscribe from event before discarding an object
            // to avoid memory leaks
            bitcoinReader.PriceReadEvent -= emailNotifier.Update;
            bitcoinReader.PriceReadEvent -= pushNotifier.Update;
        }
    }
}
