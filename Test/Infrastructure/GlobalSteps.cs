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

namespace Test.Infrastructure
{
    [Binding]
    public class GlobalSteps : Steps
    {
        private static readonly Uri BookDepoHomeUrl = new Uri(ConfigurationManager.AppSettings["BookDepoHomeUrl"]);
        private static readonly Uri GetTimelyHomeUrl = new Uri(ConfigurationManager.AppSettings["GetTimely"]);

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

        public static void GoToBookDepoHome()
        {
            Driver.NavigateTo(BookDepoHomeUrl);
            //2d - Driver.NavigateTo(TwoDegreesMobileUrl);
        }

        public static void GoToGetTimelyHome()
        {
            Driver.NavigateTo(GetTimelyHomeUrl);
            WaitForPageToLoad("Timely Salon & Spa Software | Everything you need to run your business");
            Thread.Sleep(2500);
        }

        public static void WaitForPageToLoad(string titleOfExpectedPage = "default")
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
