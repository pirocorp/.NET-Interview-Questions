namespace Cashing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var peopleController = new PeopleController(
                new PeopleRepositoryMock());

            var john = peopleController.GetByName("John", "Smith");
            john = peopleController.GetByName("John", "Smith");
            john = peopleController.GetByName("John", "Smith");
            Console.WriteLine($"First Name: {john?.FirstName}, Last Name: {john?.LastName}");
        }
    }

    public class PeopleController
    {
        private readonly IRepository<Person?> peopleRepository;
        // Key - ValueTuple because of ValueTuple is Value Type and
        // it's hash code is calculated based on data values,
        // Value - Person 
        private readonly Cache<(string FirstName, string LastName), Person?> peopleCache;

        public PeopleController(IRepository<Person?> peopleRepository)
        {
            this.peopleRepository = peopleRepository;
            this.peopleCache = new Cache<(string FirstName, string LastName), Person?>();
        }

        public Person? GetByName(string firstName, string lastName)
        {
            return this.peopleCache.Get(
                key: (firstName, lastName),
                getValue: () => this.peopleRepository
                    .GetByName(firstName, lastName)
                    .FirstOrDefault());
        }
    }

    public class Cache<TKey, TValue> where TKey: notnull
    {
        private readonly Dictionary<TKey, TValue> cachedData = new();

        public TValue Get(
            TKey key,
            Func<TValue> getValue)
        {
            if (!cachedData.ContainsKey(key))
            {
                this.cachedData[key] = getValue();
            }

            return this.cachedData[key];
        }
    }
}
