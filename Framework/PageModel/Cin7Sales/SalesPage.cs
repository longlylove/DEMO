using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.DataModel.Cin7Sales;
using Framework.Drivers;
using Framework.Elements;
using Framework.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Framework.PageModel.Cin7Sales
{
    public class SalesPage
    {
        private readonly IWebDriver _driverInUse = Driver.DriverInstance;
        private static readonly ElementHelper ElementHelper = new ElementHelper();

        [Name("Sales Record Lines")]
        [FindsBy(How = How.XPath, Using = "//tbody/tr")]
        private IList<IWebElement> _salesRecordLine;

        public SalesPage()
        {
            PageFactory.InitElements(_driverInUse, this);
        }

        private int CountSalesRecordLines()
        {
            return _salesRecordLine.Count;
        }

        public bool SalesIsCreated(Pants.PantsAttr pants)
        {
            var newestLine = CountSalesRecordLines();
            var pantType =
                    _driverInUse.FindElement(
                        By.XPath("//tbody/tr[" + newestLine + "]/td[1]")).Text;
            var customerName =
                    _driverInUse.FindElement(
                        By.XPath("//tbody/tr[" + newestLine + "]/td[2]")).Text;
            if (pantType.Contains(pants.ProductName) && customerName.Contains(pants.CustomerName))
            {
                return true;
            }
            throw new Exception("Sales record for " + pants.CustomerName + " not found!");
        }

        public bool SalesIsCorrectlyCalculated(Pants.PantsAttr pants)
        {
            var newestLine = CountSalesRecordLines();
            var productPrice =
                    int.Parse(_driverInUse.FindElement(
                        By.XPath("//tbody/tr[" + newestLine + "]/td[3]")).Text);
            var discountPrice =
                    int.Parse(_driverInUse.FindElement(
                        By.XPath("//tbody/tr[" + newestLine + "]/td[4]")).Text);
            var totalPrice =
                    int.Parse(_driverInUse.FindElement(
                        By.XPath("//tbody/tr[" + newestLine + "]/td[5]")).Text);
            if (productPrice == pants.ProductPrice)
            {
                if (discountPrice == pants.DiscountPrice)
                {
                    if (totalPrice == pants.TotalPrice)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            throw new Exception("Product price for " + pants.ProductName + " does not match spec!");
        }
    }
}
