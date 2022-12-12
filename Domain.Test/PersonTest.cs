using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Domain.Test
{
    public class PersonTest
    {
        [Fact]
        public void constructor_should_create_person()
        {
            var firstName = "Akbar";
            var lastName = "Dizaji";
            var person = new Person(firstName, lastName);
            Assert.Equal(firstName, person.FirstName);
            Assert.Equal(lastName, person.LastName);
        }
        [Fact]
        public void parameterles_constructor_should_create_person()
        {
            var person = new Person();
            Assert.IsType<Person>(person);
        }
        [Fact]
        public void builderMethods_should_change_personFields_inChain()
        {
            var firstName = "Akbar";
            var lastName = "Dizaji";
            var person = new Person();
            person.addFirstName(firstName).addLastName(lastName);
            Assert.Equal(firstName, person.FirstName);
            Assert.Equal(lastName, person.LastName);
        }
    }
}
