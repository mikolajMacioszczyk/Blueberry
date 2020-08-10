using System;
using System.Collections.Generic;
using Blueberry.DLL.Enums;
using Blueberry.DLL.Models;
using Blueberry.WPF.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blueberry.Tests.ModelTests
{
    [TestClass]
    public class HomeVMTests
    {
        [TestMethod]
        public void SetOrdersStatisticsEmptyListTest()
        {
            var orders = new List<Order>();
            var model = new HomePageVM();
            model.SetOrdersStatistics(orders);
            Assert.AreEqual("", model.WaitingRoom1);
            Assert.AreEqual("", model.WaitingRoom2);
            Assert.AreEqual("", model.WaitingRoom3);
            Assert.AreEqual($"Sprzedane kilogramy: 0", model.SoldedInfo);
        }

        [TestMethod]
        public void SetOrdersStatisticsOneElementListTest()
        {
            var order1 = new Order()
            {
                Amount = 10,
                Customer = new Customer()
                { FirstName = "TestFirst", LastName = "TestLast" },
                DateOfRealization = DateTime.Now,
                Status = OrderStatus.Waiting
            };
            var order2 = new Order()
            {
                Amount = 20,
                Customer = new Customer()
                { FirstName = "TestFirst2", LastName = "TestLast2" },
                DateOfRealization = DateTime.Now,
                Status = OrderStatus.Realized
            };
            var orders = new List<Order>() { order1, order2 };
            var model = new HomePageVM();
            model.SetOrdersStatistics(orders);
            Assert.AreEqual($"1. {order1}", model.WaitingRoom1);
            Assert.AreEqual("", model.WaitingRoom2);
            Assert.AreEqual("", model.WaitingRoom3);
            Assert.AreEqual($"Sprzedane kilogramy: 20", model.SoldedInfo);
        }

        [TestMethod]
        public void SetOrdersStatisticsTwoElementListTest()
        {
            var order1 = new Order()
            {
                Amount = 10,
                Customer = new Customer()
                { FirstName = "TestFirst", LastName = "TestLast" },
                DateOfRealization = DateTime.Now,
            };
            var order2 = new Order()
            {
                Amount = 20,
                Customer = new Customer()
                { FirstName = "TestFirst2", LastName = "TestLast2" },
                DateOfRealization = DateTime.Now.AddDays(-1)
            };
            var orders = new List<Order>() {
                order1,
                order2
            };
            var model = new HomePageVM();
            model.SetOrdersStatistics(orders);
            Assert.AreEqual($"1. {order2}", model.WaitingRoom1);
            Assert.AreEqual($"2. {order1}", model.WaitingRoom2);
            Assert.AreEqual("", model.WaitingRoom3);
            Assert.AreEqual($"Sprzedane kilogramy: 0", model.SoldedInfo);
        }

        [TestMethod]
        public void SetOrdersHarvestEmptyListTest()
        {
            var harvests = new List<Harvest>();
            var model = new HomePageVM();
            model.SetHarvestStatistics(harvests);
            Assert.AreEqual($"Zebrane kilogramy: 0", model.DropedInfo);
        }

        [TestMethod]
        public void SetHarvestStatisticsOneElementListTest()
        {
            var harvest1 = new Harvest()
            {
                Amount = 10,
                DateTime = DateTime.Now,
                Employee = new Employee() { FirstName = "First1", LastName = "Last1" },
                Id = 1
            };
            var harvests = new List<Harvest>() { harvest1 };
            var model = new HomePageVM();
            model.SetHarvestStatistics(harvests);
            Assert.AreEqual($"Zebrane kilogramy: 10", model.DropedInfo);
        }

        [TestMethod]
        public void SetHarvestStatisticsTwoElementListTest()
        {
            var harvest1 = new Harvest()
            {
                Amount = 10,
                DateTime = DateTime.Now,
                Employee = new Employee() { FirstName = "First1", LastName = "Last1" },
                Id = 1
            };
            var harvest2 = new Harvest()
            {
                Amount = 20,
                DateTime = DateTime.Now,
                Employee = new Employee() { FirstName = "First2", LastName = "Last2" },
                Id = 2
            };
            var harvest3 = new Harvest()
            {
                Amount = 30,
                DateTime = DateTime.Now,
                Employee = new Employee() { FirstName = "First3", LastName = "Last3" },
                Id = 3
            };
            var harvests = new List<Harvest>() { harvest1, harvest2, harvest3 };
            var model = new HomePageVM();
            model.SetHarvestStatistics(harvests);
            Assert.AreEqual($"Zebrane kilogramy: 60", model.DropedInfo);
        }

        [TestMethod]
        public void SetPriceWithPositiveValue()
        {
            float price = 10;
            var model = new HomePageVM();
            model.SetPrice(10);
            Assert.AreEqual($"Cena za kilogram: {price}", model.PricePerKgInfo);
        }

        [TestMethod]
        public void SetPriceWithNegativeValue()
        {
            float price = -10;
            var model = new HomePageVM();
            Assert.ThrowsException<ArgumentException>(() => model.SetPrice(price));
        }
    }
}
