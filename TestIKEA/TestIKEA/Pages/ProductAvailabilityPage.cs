using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace TestIKEA.Pages
{
    class ProductAvailabilityPage:AbstractPage
    {

        private const string BASE_URL = "http://www.ikea.com/ru/ru/catalog/stockcheck/?icid=itl|ru|top_links|201507201030208972_3";

        [FindsBy(How = How.XPath, Using = "//*[@id='stocksearch']/div[1]/div[2]/input")]
        private IWebElement inputSearchText;

        [FindsBy(How = How.XPath, Using = "//*[@id='ikeaStoreNumber1']/option[5]")]
        private IWebElement inputStore;

        [FindsBy(How = How.XPath, Using = "//*[@id='jsButton_StockSearch_01']/div[2]/input")]
        private IWebElement buttonOk;

        

        public ProductAvailabilityPage(IWebDriver driver):base(driver)
        {
            PageFactory.InitElements(this.driver, this);
        }

        public override void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public void PrdctAvailability(string firm, string product)
        {
            inputSearchText.SendKeys(firm + product);
            inputStore.Click();
            buttonOk.Click();
        }

        public string GetHeader()
        {
            IWebElement header = driver.FindElement(By.Id("graph_main_comment"));
            return header.Text;
        }

    }
}
