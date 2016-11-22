using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using OpenQA.Selenium.Interactions;

namespace TestIKEA.Pages
{
    class SearchPage:AbstractPage
    {
        private const string BASE_URL = "http://www.ikea.com/ru/ru/search";

        [FindsBy(How = How.Id, Using = "compare_10289246")]
        private IWebElement checkbox1;
        
        [FindsBy(How = How.Id, Using = "imgThmbProduct1")]
        private IWebElement element1;

        [FindsBy(How = How.Id, Using = "compare_80289243")]
        private IWebElement checkbox2;

        [FindsBy(How = How.Id, Using = "//*[@id='popupContent']/div")]
        private IWebElement element2;

        [FindsBy(How = How.XPath, Using = "//*[@id='jsButton_SortFilterBar_01']/div[2]/input")]
        private IWebElement buttonCompare;

        [FindsBy(How = How.XPath, Using = "//*[@id='txtMainHdr1']/h1")]
        private IWebElement header;

        
        public SearchPage(IWebDriver driver)
            : base(driver)
        {
            PageFactory.InitElements(this.driver, this);            
        }

        public override void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        } 

        public void ClickCheckbox1()
        {
            checkbox1.Click();
        }

        public void ClickCheckbox2()
        {
            checkbox2.Click();
        }

        public void ClickButtonCompare()
        {
            buttonCompare.Click();
        }

        public string CheckCompareProduct()
        {
            return header.Text;
        }
    }
}
