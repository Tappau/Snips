using System.Collections.Generic;
using NUnit.Framework;
using SnipsSolution.Extensions;

namespace Snips.Test.ExtensionTests
{
    
    [TestFixture]
    public class ListExtensionsTests
    {
        [Test]
        public void AddIf_ObjectToAddIsNull_Then_WontAddToList()
        {
            var list = new List<Person>();
            list.Add(new Person(){Name = "First Name"});
            list.AddIf(o => o != null, null);
            Assert.That(list.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddIf_ObjectToAddIsValidButAProperty_DoesNot_Match_Then_WontAddToList()
        {
            var list = new List<Person>
            {
                new() { Name = "First Name" }
            };
            var newModel = new Person() {Name = "Test Name", Age = "18"};

            //Wont add as Age is 18 however Name is correct
            list.AddIf(o => o.Name == "Test Name" && o.Age== "20", newModel);
            Assert.That(list.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddIf_ObjectToAddIsValidAndPredicateIsValid_Then_WillAddToList()
        {
            var list = new List<Person>
            {
                new() { Name = "First Name" }
            };
            var newModel = new Person() {Name = "Test Name", Age = "18"};

            //Wont add as Age is 18 however Name is correct
            list.AddIf(o => o.Name == "Test Name" && o.Age== "18", newModel);
            Assert.That(list.Count, Is.EqualTo(2));
        }
    }
}