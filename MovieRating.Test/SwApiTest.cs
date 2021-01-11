using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace MovieRating.Test
{
    [TestClass]
    public class SwApiTest
    {
        [TestMethod]
        public async Task CompareCharacters_WhenCalled_GetCharacterDetails()
        {
            //Arrange
            var swApiConector = new Connectors.SwApi.SwApiConnector();
            var mockupCharacter = new Connectors.SwApi.Models.Character()
            {
                Name = "Luke Skywalker",
                Height = "172",
                Mass = "77",
                HairColor = "blond",
                SkinColor = "fair",
                EyeColor = "blue",
                BirthYear = "19BBY",
                Gender = "male",
                Homeworld = "http://swapi.dev/api/planets/1/",
                Films = new List<string>() //nie działa
                {
                    "http://swapi.dev/api/films/1/",
                    "http://swapi.dev/api/films/2/",
                    "http://swapi.dev/api/films/3/",
                    "http://swapi.dev/api/films/6/"
                },
                Species = new List<object>(), // nie działa
                Vehicles = new List<string>() // nie działa
                {
                    "http://swapi.dev/api/vehicles/14/",
                    "http://swapi.dev/api/vehicles/30/"
                },
                Starships = new List<string>() // nie działa
                {
                    "http://swapi.dev/api/starships/12/",
                    "http://swapi.dev/api/starships/22/"
                },
                Url = "http://swapi.dev/api/people/1/",
                Created = DateTime.SpecifyKind(Convert.ToDateTime("2014-12-09T13:50:51.644000"), DateTimeKind.Utc),
                Edited = DateTime.SpecifyKind(Convert.ToDateTime("2014-12-20T21:17:56.891000"), DateTimeKind.Utc)
            };

            //Act
            var result = await swApiConector.GetCharacterDetails(1);

            //Assert
            CollectionAssert.AreEquivalent(mockupCharacter.Films, result.Films);
            Assert.AreEqual(mockupCharacter.Name, result.Name);
        }
    }
}
