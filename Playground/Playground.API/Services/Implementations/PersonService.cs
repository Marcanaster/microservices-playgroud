using Playground.API.Model;

namespace Playground.API.Services.Implementations
{
    public class PersonService : IPersonService
    {
        private volatile int count;
        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for(int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);

            }
            return persons;
        }


        public Person FindById(long id)
        {
            return new Person { 
                Id = 1,
                FirstName= "Marcos",
                LastName="Almeida",
                Address="Rio de Janeiro",
                Gender="Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Person name" + i,
                LastName = "Person lastname" + i,
                Address = "Some address",
                Gender = "Male"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
