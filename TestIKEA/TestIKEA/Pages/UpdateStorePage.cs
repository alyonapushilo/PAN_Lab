using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace TestIKEA.Pages
{
    class UpdateStorePage:AbstractPage
    {
        private const string BASE_URL = "https://secure.ikea.com/webapp/wcs/stores/servlet/UpdateUser?layout=user/choosePreferredStore&actionType=view&formName=preferredStore&langId=-31&storeId=23";

        [FindsBy(How = How.Id, Using = "preferredStore_storeNumber")]
        private IWebElement inputStore;

        [FindsBy(How = How.XPath, Using = "//*[@id='preferredStore']/div[4]/input[2]")]
        private IWebElement buttonSave;
        
        [FindsBy(How = How.XPath, Using = "//*[@id='preferredStore_storeNumber']/option[6]")]
        private IWebElement storeKazan;

        [FindsBy(How = How.XPath, Using = "//*[@id='preferredStore_storeNumber']/option[9]")]
        private IWebElement storeOmsk;
        
        public UpdateStorePage(IWebDriver driver):base(driver)
        {
            PageFactory.InitElements(this.driver, this);
        }

        public override void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public void ClickKazan()
        {
            storeKazan.Click();            
        }

        public void ClickOmsk()
        {
            storeOmsk.Click();
        }

        public void Save()
        {
            buttonSave.Click();
        }

    }
}
