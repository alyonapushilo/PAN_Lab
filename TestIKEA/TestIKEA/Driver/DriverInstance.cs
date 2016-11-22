using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Firefox;
using System.Diagnostics;

namespace TestIKEA.Driver
{
        public static class DriverInstance
        {
            private static IWebDriver driver;

            static DriverInstance() { }

            public static IWebDriver GetInstance()
            {
                if (driver == null)
                {
                    driver = new FirefoxDriver();                    
                    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
                    driver.Manage().Window.Maximize();
                }
                return driver;
            }

            public static void CloseBrowser()
            {
                driver.Quit();
                driver = null;

               
            }
        }
    }

