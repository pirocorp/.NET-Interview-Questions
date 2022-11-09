namespace Cashing
{
    using System.Collections.Generic;

    public interface IRepository<out T>
    {
        IEnumerable<T> GetByName(string firstName, string lastName);
    }
}
