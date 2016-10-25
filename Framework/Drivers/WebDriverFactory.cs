using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Remote;

namespace Framework.Drivers
{
    public static class WebDriverFactory
    {
        public enum DriverFlavour
        {
            ChromeDriver
        }

        //public static RemoteWebDriver CreateDriver(DriverFlavour driverFlavour)
        //{
        //    RemoteWebDriver driver;

        //    switch (driverFlavour)
        //    {
        //            case DriverFlavour.ChromeDriver:
        //            var cap = DesiredCapabilities.Chrome();
        //    }
        //}
    }
}
