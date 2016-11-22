using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace TestIKEA.Pages
{
    public class LoginPage:AbstractPage
    {
        private const string BASE_URL = "https://secure.ikea.com/webapp/wcs/stores/servlet/LogonForm?storeId=23&langId=-31&catalogId=11001";

        [FindsBy(How = How.Id, Using = "login_logonId")]
        private IWebElement inputLogin;

        [FindsBy(How = How.Id, Using = "login_logonPassword")]
        private IWebElement inputPassword;

        [FindsBy(How = How.XPath, Using = "//*[@id='login']/div[7]/input")]
        private IWebElement buttonSubmit;
                     

        public LoginPage(IWebDriver driver):base(driver)
        {            
            PageFactory.InitElements(this.driver, this);
        }

        public override void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            Console.WriteLine("Login Page opened");
        }

        public void Login(string username, string password)
        {
            inputLogin.SendKeys(username);
            inputPassword.SendKeys(password);
            buttonSubmit.Click();
        }

        public string GetLoggedInUserName()
        {

            IWebElement linkLoggedInUser = driver.FindElement(By.CssSelector("#ppContentContainer > div.ppMainHeadline > h1"));
            return linkLoggedInUser.Text;
        }
    }
}

