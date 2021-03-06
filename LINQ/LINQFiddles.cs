﻿/*
 * Test class with some linq experiments.
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LINQ
{
    [TestClass]
    public class LINQFiddles
    {
        [TestMethod]
        public void SelectWithFunc()
        {
            var people = Person.GetPeople();

            var f = new Func<int, bool>((l) =>
            {
                return l > 40;
            });

            var result = people.Where(p => f(p.Age));
            Assert.AreEqual("Herman", result.First().Name);
        }

        [TestMethod]
        public void Take()
        {
            var people = Person.GetPeople();

            var result = people.Take(2).ToArray();
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("Piet", result.First().Name);
            Assert.AreEqual("Karolien", result.Last().Name);
        }

        [TestMethod]
        public void Skip()
        {
            var people = Person.GetPeople();

            var result = people.Skip(2).ToArray();
            Assert.AreEqual(10, result.Count());
            Assert.AreEqual("Karel", result.First().Name);
            Assert.AreEqual("Teresa", result.Last().Name);
        }

        [TestMethod]
        public void TakeWhile()
        {
            var people = Person.GetPeople();

            var result = people.TakeWhile(p => p.Age < 40);
            Assert.AreEqual(7, result.Count());
        }

        [TestMethod]
        public void SkipWhile()
        {
            var people = Person.GetPeople();

            var result = people.SkipWhile(p => p.Age < 40);
            Assert.AreEqual(5, result.Count());
        }

        [TestMethod]
        public void ElementAtOrDefaultInLimit()
        {
            var people = Person.GetPeople();

            var result = people.ElementAtOrDefault(2);
            Assert.AreEqual("Karel", result.Name);
        }

        [TestMethod]
        public void ElementAtOrDefaultOutsideLimit()
        {
            var people = Person.GetPeople();

            var result = people.ElementAtOrDefault(500);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Exists()
        {
            var people = Person.GetPeople();

            var result = people.Exists(p => p.Name == "Johan");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SelectMany()
        {
            var people = Person.GetPeople();

            var result = people.SelectMany(person => person.Family, (p, p2) => new { p.Name, Familymember = p2.Name });
            Assert.AreEqual(36, result.Count());
        }

        [TestMethod]
        public void LookUp()
        {
            var people = Person.GetPeople();

            var families = people.ToLookup(p => p.LastName, p => p);

            Assert.IsTrue(families.Select(r => r.Key == "Piet").Any());

            var pietsFamilyCount = (from family in families
                                    where family.Key == "Keizer"
                                    select family.Count()).SingleOrDefault();

            Assert.AreEqual(3, pietsFamilyCount);
        }

        [TestMethod]
        public void ToDictionary()
        {
            var people = Person.GetPeople();

            var result = people.ToDictionary(p => p.Name);

            Assert.IsTrue(result.Select(r => r.Key == "Piet").Any());
        }

        [TestMethod]
        public void ThreeColumns()
        {
            var people = Person.GetPeople().OrderBy(p => p.Name + p.LastName);

            var grouped = Enumerable.Range(0, people.Count())
                   .Select(index => index)
                   .GroupBy(index => index % 3)
                   .Select(indexes => indexes.Select(index => people.ElementAt(index)))
                   .ToArray();


            grouped.Dump();
        }

        [TestMethod]
        public void ThreeColumns2()
        {
            var grouped = from e in Enumerable.Range(0, (int)Math.Ceiling((double)(Person.GetPeople().Count() - 1 / 3)))
                          select new
                          {
                              Col1 = Person.GetPeople().Select((p, i) => new { Person = p, col = i % 3 }).Where(p => p.col == 1),
                              Col2 = Person.GetPeople().Select((p, i) => new { Person = p, col = i % 3 }).Where(p => p.col == 2),
                              Col3 = Person.GetPeople().Select((p, i) => new { Person = p, col = i % 3 }).Where(p => p.col == 3),
                          }
                          ;

            grouped.Dump();
        }

        [TestMethod]
        public void ThreeColumns3()
        {
            var people =
                                    from groupedAndRowed in (
                                         from groupedPeople in (
                                            from person in Person.GetPeople().Select((p, i) => new { Col = i % 3, Person = p })
                                            group person by person.Col into g
                                            select g
                                            )
                                         select groupedPeople.Select((g, i) => new { Row = i, Persons = g.Person, Col = g.Col })
                                    )
                                    from row in Enumerable.Range(0, 3)
                                    select new
                                    {
                                        Col1 = groupedAndRowed.Where(x => x.Row == row && x.Col == 0),
                                        Col2 = groupedAndRowed.Where(x => x.Row == row && x.Col == 1),
                                        Col3 = groupedAndRowed.Where(x => x.Row == row && x.Col == 2),
                                    };


        }

        [TestMethod]
        public void Expressions_SelectPeopleByLastName()
        {
            var people = Person.GetPeople();
            var person = Expression.Parameter(typeof(Person));
            var compare = Expression.Lambda<Func<Person, bool>>(
                Expression.Equal(
                    Expression.PropertyOrField(person, "LastName"),
                    Expression.Constant("Keizer", typeof(string))),
                person);

            var selectedPeople = people.Where(compare.Compile());

            foreach (var selectedPerson in selectedPeople)
            {
                Console.WriteLine(selectedPerson.Name);
            }
        }

        [TestMethod]
        public void Expressions_ContainsLambda()
        {            
            Expression<Func<string, bool>> exp = (s) => new string[] { "A", "B", "C" }.Contains(s);

            Console.WriteLine(exp.Compile()("E")); // False
            Console.WriteLine(exp.Compile()("A")); // True
        }

        [TestMethod]
        public void Expressions_SelectPeopleIfTheirFirstNameContains_A_E_F()
        {
            var people = Person.GetPeople();

            var letters = new string[] { "A", "E", "F" };
            var person = Expression.Parameter(typeof(Person));

            var fieldLambda = Expression.Lambda<Func<Person, string>>(Expression.PropertyOrField(person, "Name"), person);

            // Get the Contains method from Enumerable.
            var containsMethod = typeof(Enumerable).GetMethods().Where(m => m.Name == "Contains" && m.GetParameters().Count() == 2);

           
        }
    }

    public class Person
    {
        public Person()
        {
            this.Family = new List<Person>();
        }

        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public List<Person> Family { get; set; }
        public string Gender { get; set; }

        public static List<Person> GetPeople()
        {
            var persons = new List<Person>
            {
                new Person
                {
                    Name = "Piet",
                    LastName = "Keizer",
                    Age = 39,
                    Gender = Genders.Male.ToString(),
                },
                new Person
                {
                    Name = "Karolien",
                    LastName = "Keizer",
                    Age = 38,
                    Gender= Genders.Female.ToString(),
                },
                new Person
                {
                    Name = "Karel",
                    LastName = "Keizer",
                    Age = 12,
                    Gender = Genders.Male.ToString(),

                },
                new Person
                {
                    Name = "Marie",
                    LastName = "Smit",
                    Age = 35,
                    Gender = Genders.Female.ToString(),
                },
                new Person
                {
                    Name = "Jamie",
                    LastName = "Smit",
                    Age = 8,
                    Gender = Genders.Male.ToString(),
                },
                new Person
                {
                    Name = "Merel",
                    LastName = "Smit",
                    Age = 6,
                    Gender = Genders.Female.ToString(),
                },
                new Person
                {
                    Name = "Ilse",
                    LastName = "de Vos",
                    Age = 24,
                    Gender = Genders.Female.ToString(),
                },
                new Person
                {
                    Name = "Herman",
                    LastName = "de Vos",
                    Age = 56,
                    Gender = Genders.Male.ToString(),
                },
                new Person
                {
                    Name = "Sofie",
                    LastName = "de Vos",
                    Age = 54,
                    Gender = Genders.Female.ToString()

                },
                new Person
                {
                    Name = "Johan",
                    LastName = "Johnson",
                    Age = 44,
                    Gender = Genders.Male.ToString(),
                },
                new Person
                {
                    Name = "Gerda",
                    LastName = "Johnson",
                    Age = 56,
                    Gender = Genders.Female.ToString(),
                },
                new Person
                {
                    Name = "Teresa",
                    LastName = "Johnson",
                    Age = 19,
                    Gender = Genders.Female.ToString(),
                },
            };

            foreach (var person in persons)
            {
                var fullName = person.Name + person.LastName;
                var family = from people in persons
                             where people.LastName == person.LastName
                             where people.Name + people.LastName != fullName
                             select people;

                person.Family = family.ToList();
            }

            return persons;
        }
    }

    public enum Genders
    {
        Male,
        Female,
    }
}
