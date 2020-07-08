using Blueberry.DLL.Models;
using Blueberry.WPF.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace Blueberry.Tests.ConvertersTests
{
    [TestClass]
    public class AdressToStringConveterTest
    {
        [TestMethod]
        public void NullArgumentTest()
        {
            var converter = new AddressToStringPConverter();
            Address value = null;
            var result = converter.Convert(value, typeof(string), null, CultureInfo.CurrentCulture);
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void ValidArgumentTest()
        {
            var converter = new AddressToStringPConverter();
            Address address = new Address()
            {
                City = "TestCity",
                House = 1,
                Street = "TestStreet"
            };
            var result = converter.Convert(address, typeof(string), null, CultureInfo.CurrentCulture);
            Assert.AreEqual($"Miasto: {address.City}, Ul: {address.Street}, Dom: {address.House}", result);
        }
    }
}