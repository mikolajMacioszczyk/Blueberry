using Blueberry.DLL.Enums;
using Blueberry.WPF.Pages.Orders;
using Blueberry.WPF.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blueberry.Tests.CommandTests
{
    [TestClass]
    public class SortByCommandTests
    {
        [TestMethod]
        public void ChangeSortByTestNullParameter()
        {
            var model = new OrderPageVM();
            var command = model.SortCommand;
            command.Execute(0);
            Assert.AreEqual(SortBy.Date, model.SelectedSort);
        }
        
        [TestMethod]
        public void ChangeSortByTestNullParameterSetByInvokedMethod()
        {
            var model = new OrderPageVM();
            model.SelectedSort = SortBy.Customer;
            var command = model.SortCommand;
            command.Execute(0);
            Assert.AreEqual(SortBy.Date, model.SelectedSort);
        }
        
        [TestMethod]
        public void ChangeSortByTestIntParameter()
        {
            var model = new OrderPageVM();
            var command = model.SortCommand;
            command.Execute(1);
            Assert.AreEqual(SortBy.Customer, model.SelectedSort);
            command.Execute(2);
            Assert.AreEqual(SortBy.Priority, model.SelectedSort);
            command.Execute(0);
            Assert.AreEqual(SortBy.Date, model.SelectedSort);
        }
    }
}