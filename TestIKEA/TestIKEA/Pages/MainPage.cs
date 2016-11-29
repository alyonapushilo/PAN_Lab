using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace TestIKEA.Pages
{
    public class MainPage:AbstractPage
    {
        private const string BASE_URL = "http://www.ikea.com/ru/ru/";

        [FindsBy(How = How.Id, Using = "search")]
        private IWebElement inputSearch;

        [FindsBy(How = How.XPath, Using = "//*[@id='lnkSearchBtnHeader']/div[2]/input")]
        private IWebElement buttonSearch;

        [FindsBy(How = How.Id, Using = "link_header_shopping_list")]
        private IWebElement buttonShoppingList;
        
        [FindsBy(How = How.XPath, Using = "//*[@id='lnkMainMenu1Header']/span/span/span")]
        private IWebElement buttonAllProduct;

        private IWebElement link;

        

        public MainPage(IWebDriver driver):base (driver)
        {            
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public void Search(string firm, string product)
        {
            inputSearch.SendKeys(firm + product);
            buttonSearch.Click();
            System.Threading.Thread.Sleep(2000);
        }

        public void Search(string productNumber)
        {
            inputSearch.SendKeys(productNumber);
            buttonSearch.Click();
        }

        public void OpenShoppingList()
        {
            buttonShoppingList.Click();
        }

        public void OpenProductPage(string pageName)

        {
            buttonAllProduct.Click();
            System.Threading.Thread.Sleep(2000);
            link.FindElement(By.LinkText(pageName));
            link.Click();
            System.Threading.Thread.Sleep(1000);
        }
 
 

        





    }
}