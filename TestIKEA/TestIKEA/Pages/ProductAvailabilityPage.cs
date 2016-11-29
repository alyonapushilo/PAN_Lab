using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestIKEA.Pages
{
    class ProductAvailabilityPage:AbstractPage
    {

        private const string BASE_URL = "http://www.ikea.com/ru/ru/catalog/stockcheck/";

        [FindsBy(How = How.XPath, Using = "//*[@id='stocksearch']/div[1]/div[2]/input")]
        private IWebElement inputSearchText;

        [FindsBy(How = How.XPath, Using = "//*[@id='ikeaStoreNumber1']")]
        private IWebElement selectStore;

        [FindsBy(How = How.XPath, Using = "//*[@id='jsButton_StockSearch_01']/div[2]/input")]
        private IWebElement buttonOk;

        

        public ProductAvailabilityPage(IWebDriver driver):base(driver)
        {
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public void ProductAvailability(string firm, string product, string store)
        {
            inputSearchText.SendKeys(firm + product);
            var selectElement = new SelectElement(selectStore);
            selectElement.SelectByText(store);
            buttonOk.Click();
        }

        public bool CheckProductAvailability()
        {
            string header = driver.FindElement(By.Id("graph_main_comment")).Text;
            string msg = "Товар будет в наличии";
            if (string.Compare(header.Trim().ToLower(), 0, msg.ToLower(), 0, msg.Length) == 0)
                return true;
            return false;
        }

    }
}
