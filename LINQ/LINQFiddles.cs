/*
 * Test class with some linq experiments.
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Assert.AreEqual(result.Single().Name, "Johan");
        }

        [TestMethod]
        public void Take()
        {
            var people = Person.GetPeople();

            var result = people.Take(2).ToArray();
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("Piet", result.First().Name);
            Assert.AreEqual("Marie", result.Last().Name);
        }

        [TestMethod]
        public void Skip()
        {
            var people = Person.GetPeople();

            var result = people.Skip(2).ToArray();
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("Ilse", result.First().Name);
            Assert.AreEqual("Johan", result.Last().Name);
        }

        [TestMethod]
        public void TakeWhile()
        {
            var people = Person.GetPeople();

            var result = people.TakeWhile(p => p.Age < 40);
            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        public void SkipWhile()
        {
            var people = Person.GetPeople();

            var result = people.SkipWhile(p => p.Age < 40);
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void ElementAtOrDefaultInLimit()
        {
            var people = Person.GetPeople();

            var result = people.ElementAtOrDefault(2);
            Assert.AreEqual("Ilse", result.Name);
        }

        [TestMethod]
        public void ElementAtOrDefaultOutsideLimit()
        {
            var people = Person.GetPeople();

            var result = people.ElementAtOrDefault(5);
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
            Assert.AreEqual(8, result.Count());
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public List<Person> Family { get; set; }

        public static List<Person> GetPeople()
        {
            return new List<Person>
            {
                new Person
                {
                    Name = "Piet",
                    LastName = "Keizer",
                    Age = 39,
                    Family = new List<Person>
                    {
                        new Person
                        {
                            Name= "Karolien",
                            LastName = "Keizer",
                            Age = 38
                        },
                        new Person
                        {
                            Name= "Karel",
                            LastName = "Keizer",
                            Age = 12
                        }
                    }
                },
                new Person
                {
                    Name = "Marie",
                    LastName = "Smit",
                    Age = 35,
                    Family = new List<Person>
                    {
                        new Person
                        {
                            Name= "Jamie",
                            LastName = "Smit",
                            Age = 8
                        },
                        new Person
                        {
                            Name= "Merel",
                            LastName = "Smit",
                            Age = 6
                        }
                    }
                },
                new Person
                {
                    Name = "Ilse",
                    LastName = "de Vos",
                    Age = 24,
                    Family = new List<Person>
                    {
                        new Person
                        {
                            Name= "Herman",
                            LastName = "de Vos",
                            Age = 56
                        },
                        new Person
                        {
                            Name= "Sofie",
                            LastName = "de Vos",
                            Age = 54
                        }
                    }
                },
                new Person
                {
                    Name = "Johan",
                    LastName = "Johnson",
                    Age = 44,
                    Family = new List<Person>
                    {
                        new Person
                        {
                            Name= "Gerda",
                            LastName = "Johnson",
                            Age = 56
                        },
                        new Person
                        {
                            Name= "Teresa",
                            LastName = "Johnson",
                            Age = 19
                        }
                    }
                }
            };
        }
    }
}
