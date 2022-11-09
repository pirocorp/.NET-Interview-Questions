namespace IDisposable
{
    using System;
    using System.IO;

    /// <summary>
    /// Reading file line by line oversimplified
    /// </summary>
    public class FileReader : IDisposable
    {
        private StreamReader? streamReader;
        private readonly string path;

        public FileReader(string path)
        {
            this.path = path;
        }

        public string? ReadLine()
        {
            this.streamReader ??= new StreamReader(path);

            return this.streamReader.ReadLine();
        }

        // GC does not call Dispose method. It's not even aware of it.
        // We must call it ourselves, and the best way is by using the using statement
        public void Dispose()
        {
            this.streamReader?.Dispose();
        }
    }
}
