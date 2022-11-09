namespace Cashing
{
    using System;
    using System.Collections.Generic;

    public class PeopleRepositoryMock : IRepository<Person>
    {
        public IEnumerable<Person> GetByName(string firstName, string lastName)
        {
            if (firstName == "John" && lastName == "Smith")
            {
                return new[] { new Person("John", "Smith") };
            }

            throw new NotImplementedException();
        }
    }
}
