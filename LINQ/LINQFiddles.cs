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

            var ageOver40 = people.Where(p => f(p.Leeftijd));
            Assert.AreEqual(ageOver40.Single().Naam, "Johan");
        }
    }

    public class Person
    {
        public string Naam { get; set; }
        public string Achternaam { get; set; }
        public int Leeftijd { get; set; }

        public static List<Person> GetPeople()
        {
            return new List<Person>
        {
            new Person
            {
                Naam = "Piet",
                Achternaam = "Keizer",
                Leeftijd = 39,
            },
            new Person
            {
                Naam = "Marie",
                Achternaam = "Keizer",
                Leeftijd = 35
            },
            new Person
            {
                Naam = "Ilse",
                Achternaam = "de Vos",
                Leeftijd = 24
            },
            new Person
            {
                Naam = "Johan",
                Achternaam = "Johnson",
                Leeftijd = 44
            }
        };
        }
    }
}
