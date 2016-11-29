using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace TestIKEA.Pages
{
    public class ProductPage:AbstractPage
    {
        [FindsBy(How = How.Id, Using = "name")]
        private IWebElement productTitle;

        [FindsBy(How = How.CssSelector, Using = "#jsButton_saveToList_lnk > input[type='button']")]
        private IWebElement buttonAddToList;

        public ProductPage(IWebDriver driver):base(driver)
        {
            PageFactory.InitElements(this.driver, this);

        }

        public void OpenPage(string productNumber)
        {
            Pages.MainPage mainPage = new MainPage(driver);
            mainPage.OpenPage();
            mainPage.Search(productNumber);            
        }

        public bool CheckSearch(string firm, string product)
        {
            string title = driver.Title;
            if (string.Compare(title.Trim().ToLower(), 0, (firm + product).ToLower(), 0, (firm + product).Length)==0)
                return true;
            return false;
        }

        public void Add()
        {
            buttonAddToList.Click();
            System.Threading.Thread.Sleep(5000);
        }

        public string CheckAdd()
        {
            IWebElement message = driver.FindElement(By.Id("slPopupH1"));
            return message.Text;
        }


    }
}