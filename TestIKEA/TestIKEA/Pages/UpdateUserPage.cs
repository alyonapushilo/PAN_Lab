using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace TestIKEA.Pages
{
    public class UpdateUserPage:AbstractPage
    {
        private const string BASE_URL = "https://secure.ikea.com/webapp/wcs/stores/servlet/UpdateUser?layout=user/editProfile&formName=updatePrivatePersonal&actionType=view&langId=-31&storeId=23";

        [FindsBy(How = How.Id, Using = "updatePrivatePersonal_firstName")]
        private IWebElement inputName;
        
        [FindsBy(How = How.XPath, Using = "//*[@id='updatePrivatePersonal']/div[5]/input[2]")]
        private IWebElement buttonSave;
        public UpdateUserPage(IWebDriver driver):base(driver)
        {
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public void Update(string username)
        {
            inputName.Clear();
            inputName.SendKeys(username);
            buttonSave.Click();
        }
    }
}
