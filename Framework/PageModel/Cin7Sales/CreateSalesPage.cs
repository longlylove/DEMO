using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Framework.DataModel.Cin7Sales;
using Framework.Drivers;
using Framework.Elements;
using Framework.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Framework.PageModel.Cin7Sales
{
    public class CreateSalesPage
    {
        private readonly IWebDriver _driverInUse = Driver.DriverInstance;
        private static readonly ElementHelper ElementHelper = new ElementHelper();

        [Name("ProductId Selector")]
        [FindsBy(How = How.XPath, Using = "//select[@id='ProductId']")]
        private IWebElement _productIdSelector;

        [Name("Customer Name")]
        [FindsBy(How = How.XPath, Using = "//input[@id='CustomerName']")]
        private IWebElement _customerName;

        [Name("Create Sales Button")]
        [FindsBy(How = How.XPath, Using = "//input[@value='Create']")]
        private IWebElement _createSalesButton;

        public CreateSalesPage()
        {
            PageFactory.InitElements(_driverInUse, this);
        }

        public void InitProductIdSelector(Pants.PantsAttr pants)
        {
            SelectPantsProduct(pants);
        }

        private void SelectPants(Pants.PantsAttr pants)
        {
            if (ElementHelper.ValidateElement(_productIdSelector, _productIdSelector.GetAttribute("Name")))
            {
                _productIdSelector.Click();
                var selectElement = new SelectElement(_productIdSelector);
                selectElement.SelectByText(pants.ProductName);
            }
        }

        public void SelectPantsProduct(Pants.PantsAttr pants)
        {
            SelectPants(pants);
            Thread.Sleep(1500);
        }

        public void PressToCreateSales(Pants.PantsAttr pants)
        {
            if (ElementHelper.ValidateElement(_customerName, _customerName.GetAttribute("Name")))
            {
                _customerName.SendKeys(pants.CustomerName);
            }
            if (ElementHelper.ValidateElement(_createSalesButton, _createSalesButton.GetAttribute("Name")))
            {
                _createSalesButton.Click();
            }
            Thread.Sleep(1500);
        }
    }
}
