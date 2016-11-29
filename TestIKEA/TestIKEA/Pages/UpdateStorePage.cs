using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestIKEA.Pages
{
    class UpdateStorePage:AbstractPage
    {
        private const string BASE_URL = "https://secure.ikea.com/webapp/wcs/stores/servlet/UpdateUser?layout=user/choosePreferredStore&actionType=view&formName=preferredStore&storeId=23";

        [FindsBy(How = How.Id, Using = "preferredStore_storeNumber")]
        private IWebElement inputStore;

        [FindsBy(How = How.XPath, Using = "//*[@id='preferredStore']/div[4]/input[2]")]
        private IWebElement buttonSave;
        
        [FindsBy(How = How.XPath, Using = "//*[@id='preferredStore_storeNumber']")]
        private IWebElement selectUpdateStore;
        
        public UpdateStorePage(IWebDriver driver):base(driver)
        {
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public void SelectStore(string newStore)
        {
            var selectElement = new SelectElement(selectUpdateStore);
            selectElement.SelectByText(newStore);          
        }

        public void Save()
        {
            buttonSave.Click();
        }

    }
}
