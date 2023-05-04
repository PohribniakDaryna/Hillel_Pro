using System.Reflection.Metadata.Ecma335;

namespace LINQ
{
    public static class People
    {
        public static void DoActionWithPeople()
        {
            //task 6 
            Console.WriteLine("\n6.Person list:");
            var person = (int id, string name, int age) => new Person { Id = id, Name = name, Age = age };
            List<Person> people = new List<Person>()
            {
                person(1,"Mia",31),
                person(2,"Emilia",7),
                person(3,"Hanna",92),
                person(4,"Emma",25),
                person(5,"Sophia",92),
                person(6,"Lina",2),
                person(7,"Ella",16),
                person(8,"Mila",33),
                person(9,"Clara",6),
                person(10,"Lea", 15),
                person(11,"Noah",40),
                person(12,"Oliver",40),
                person(13,"George",22),
                person(14,"George",16),
                person(15,"Muhammad",40),
                person(16,"Leo",22),
                person(17,"Harry",17),
                person(18,"Oscar",6),
                person(19,"Archie",8),
                person(20,"Henry",22),
            };
            foreach (var item in people)
            {
                Console.WriteLine($"id: {item.Id} - name: {item.Name} - age: {item.Age}.");
            }

            //task 7
            Console.WriteLine("\n7. Name of people, whose age is over 20:");
            var peopleWithAgeOver20 = people.Where(person => person.Age > 20)
                .Select(person => person.Name);

            foreach (var item in peopleWithAgeOver20)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            //task 8
            Console.WriteLine("\n8. Collection of people, whose age is over 20, ordered by name:");
            var peopleWithAgeOver20OrderedByName = people.Where(person => person.Age > 20)
                .Select(person => new { person.Id, person.Name })
                .OrderBy(person => person.Name).ToList();

            foreach (var item in peopleWithAgeOver20OrderedByName)
            {
                Console.WriteLine(item);
            }

            //task 9
            Console.WriteLine("\n9. Collection of people, whose age is over 20, grouped by age and transformed to dictionary:");
            var peopleWithAgeOver20OrderedByAge = people.Where(person => person.Age > 20)
                .GroupBy(person => person.Age)
                .Select(group => new
                {
                    Age = group.Key,
                    People = group.ToDictionary(person => new { person.Id, person.Name })
                });

            foreach (var item in peopleWithAgeOver20OrderedByAge)
            {
                Console.WriteLine($"Age {item.Age}: ");

                foreach (var p in item.People)
                {
                    Console.WriteLine($"{ p.Value.Name} ");
                }
            }

            //task 10
            Console.WriteLine("\n10. Result of LINQ method which return penultimate element from the end:");
            var element = people.ReturnELement();
            Console.WriteLine(element.Name);
        }

        public static Person ReturnELement(this IEnumerable<Person> collection)
        {
            int count = collection.Count();
            int index = count - 2;
            if (count > 2)
            {
                return collection.ElementAt(index);
            }
            else
            {
                Console.WriteLine("Element doesn't exist.");
                return null;
            }
        }
    }
}