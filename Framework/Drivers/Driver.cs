using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Framework.Drivers
{
    public class Driver
    {
        public static IWebDriver DriverInstance { get; set; }

        public static IWebDriver StartAndInitializeBrowser()
        {
            DriverInstance = new ChromeDriver();
            DriverInstance.Manage().Window.Maximize();
            WaitFor(TimeSpan.FromSeconds(5));
            return DriverInstance;
        }

        public static void CloseAndDispose()
        {
            DriverInstance.Quit();
            DriverInstance.Dispose();
        }

        public static void WaitFor(TimeSpan seconds)
        {
            DriverInstance.Manage().Timeouts().ImplicitlyWait(seconds);
        }

        public static IWebDriver NavigateTo(Uri uri)
        {
            DriverInstance.Navigate().GoToUrl(uri);
            Thread.Sleep(2000);
            return DriverInstance;
        }
    }
}
