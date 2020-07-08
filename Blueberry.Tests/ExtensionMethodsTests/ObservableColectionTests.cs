using System;
using System.Collections.ObjectModel;
using System.Linq;
using Blueberry.DLL.Models;
using Blueberry.WPF.ExtensionMethods;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blueberry.Tests.ExtensionMethodsTests
{
    [TestClass]
    public class ObservableColectionTests
    {
        [TestMethod]
        public void SortSingleElementTests()
        {
            var customer1 = new Customer() { Id = 1 };
            var list = new ObservableCollection<Customer>() { customer1 };
            list.Sort((c1, c2) => c1.Id.CompareTo(c2.Id));
            Assert.IsTrue(list.SequenceEqual(new Customer[] { customer1 }));
        }

        [TestMethod]
        public void SortTwoElementsTests()
        {
            var customer1 = new Customer() { Id = 1 };
            var customer2 = new Customer() { Id = 2 };
            var list = new ObservableCollection<Customer>() { customer2, customer1 };
            list.Sort((c1, c2) => c1.Id.CompareTo(c2.Id));
            Assert.IsTrue(list.SequenceEqual(new Customer[] { customer1, customer2 }));
        }

        [TestMethod]
        public void SortFewElementsAlreadySortedTests()
        {
            var customer1 = new Customer() { Id = 1 };
            var customer2 = new Customer() { Id = 2 };
            var customer3 = new Customer() { Id = 3 };
            var list = new ObservableCollection<Customer>() { customer1, customer2, customer3 };
            list.Sort((c1, c2) => c1.Id.CompareTo(c2.Id));
            Assert.IsTrue(list.SequenceEqual(new Customer[] { customer1, customer2, customer3 }));
        }

        [TestMethod]
        public void SortFewElementsTests()
        {
            var customer1 = new Customer() { Id = 1 };
            var customer2 = new Customer() { Id = 2 };
            var customer3 = new Customer() { Id = 3 };
            var list = new ObservableCollection<Customer>() { customer2, customer3, customer1 };
            list.Sort((c1, c2) => c1.Id.CompareTo(c2.Id));
            Assert.IsTrue(list.SequenceEqual(new Customer[] { customer1, customer2, customer3 }));

        }
    }
}
