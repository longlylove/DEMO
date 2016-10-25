using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Framework.Helpers
{
    public static class JsExecutor
    {
        public static string Execute(string js, params object[] args)
        {
            object returnValue;
            using (var sw = new StopwatchHelper())
            {
                var driver = Drivers.Driver.DriverInstance;
                var jsExecutor = driver as IJavaScriptExecutor;
                if (jsExecutor == null)
                {
                    throw new Exception("JavaScriptExecutor instance was not initialized");
                }

                returnValue = jsExecutor.ExecuteScript(js, args);

                // Check if WebDriver is still happy
                try
                {
                    var pageTitle = driver.Title;
                }
                catch (InvalidOperationException ex)
                {
                    throw new InvalidOperationException(string.Format("Exception in WebDriver while doing integrity check, " +
                        "just after executing script : {0} with args [{1}]", js, string.Join(",", args)), ex);
                }
            }

            if (returnValue is string)
                return returnValue as string;

            return "";
        }
    }
}
