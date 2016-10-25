using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Framework.Drivers;
using Framework.Helpers;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Cin7Test.Infrastructure
{
    [Binding]
    public class GlobalSteps : Steps
    {
        private static readonly Uri Cin7CreateSales = new Uri(ConfigurationManager.AppSettings["Cin7CreateSales"]);
        private static readonly Uri Cin7Products = new Uri(ConfigurationManager.AppSettings["Cin7Products"]);
        private static readonly Uri Cin7Sales = new Uri(ConfigurationManager.AppSettings["Cin7Sales"]);

        [AfterTestRun]
        public static void CompleteTest()
        {
            Driver.WaitFor(TimeSpan.FromSeconds(5));
            Driver.CloseAndDispose();
        }

        [BeforeFeature]
        public static IWebDriver StartupTest()
        {
            return Driver.StartAndInitializeBrowser();
        }

        public static void GoToCin7CreateSales()
        {
            Driver.NavigateTo(Cin7CreateSales);
        }

        public static void GoToCin7Sales()
        {
            Driver.NavigateTo(Cin7Sales);
        }

        public static void WaitForPageToLoad(string titleOfExpectedPage = "MyPage")
        {
            using (var s = new StopwatchHelper())
            {
                while (s.ElapsedMilliseconds <= (TimeSpan.FromMinutes(6).TotalMilliseconds))
                {
                    var title = JsExecutor.Execute("return document.title");
                    var readyState = JsExecutor.Execute("return document.readyState");
                    if (!(title.Contains(titleOfExpectedPage)))
                    {
                        Thread.Sleep(5000);
                    }
                    if (readyState != "complete")
                    {
                        Thread.Sleep(5000);
                    }
                    else if (readyState == "complete")
                    {
                        Thread.Sleep(3000);
                        break;
                    }
                }
            }
        }
    }
}
