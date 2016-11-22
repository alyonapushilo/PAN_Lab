using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace TestIKEA.Pages
{
    public class ProductPage:AbstractPage
    {
        private const string BASE_URL = "http://www.ikea.com/ru/ru/catalog/products/10289246/?query=ВЁРДА+Нож+универсальный";

        [FindsBy(How = How.Id, Using = "name")]
        private IWebElement productTitle;

        [FindsBy(How = How.XPath, Using = "//*[@id='jsButton_saveToList_lnk']/input")]
        private IWebElement buttonAddToList;


        public ProductPage(IWebDriver driver):base(driver)
        {
            PageFactory.InitElements(this.driver, this);
        }

        public override void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public string GetTitle()
        {
            return driver.Title;
        }

        public void Add()
        {
            buttonAddToList.Click();
        }



        public string CheckAdd()
        {
            IWebElement message = driver.FindElement(By.Id("slPopupH1"));
            return message.Text;
        }


    }
}