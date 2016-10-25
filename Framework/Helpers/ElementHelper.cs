using System;
using OpenQA.Selenium;

namespace Framework.Helpers
{
    public class ElementHelper
    {
        public bool ValidateElement(IWebElement element, string elementName)
        {
            if (!element.Displayed)
            {
                throw new Exception("Element" + elementName + " is not displayed!");
            }
            if (!element.Enabled)
            {
                throw new Exception("Element" + elementName + " is not enabled!");
            }
            return true;
        }
    }
}
