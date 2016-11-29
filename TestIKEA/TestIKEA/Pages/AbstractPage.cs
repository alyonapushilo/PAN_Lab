﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace TestIKEA.Pages
{
    public abstract class AbstractPage
    {
        protected IWebDriver driver;
        

        public AbstractPage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
