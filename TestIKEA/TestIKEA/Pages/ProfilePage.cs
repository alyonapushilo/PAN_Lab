using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace TestIKEA.Pages
{
    public class ProfilePage:AbstractPage
    {
        private const string BASE_URL = "https://secure.ikea.com/webapp/wcs/stores/servlet/LogonForm";

        [FindsBy(How = How.Id, Using = "link_header_logout")]
        private IWebElement buttonExit;

        [FindsBy(How = How.LinkText, Using = "Редактировать личные данные")]
        private IWebElement linkUpdatePrivatePersonal;

        [FindsBy(How = How.LinkText, Using = "Редактировать ближайший магазин")]
        private IWebElement linkChoosePreferredStore;
       
        public ProfilePage(IWebDriver driver):base(driver)
        {            
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public void ClickOnButtonExit()
        {
            buttonExit.Click();
            System.Threading.Thread.Sleep(2000);
        }

        public string CheckLogout()
        {

            IWebElement linkLoggedOff = driver.FindElement(By.CssSelector("#txtMainHdr1 > h1"));
            return linkLoggedOff.Text;
        }

        public string CheckChangeUsername()
        {
            IWebElement messageBox = driver.FindElement(By.XPath("//*[@id='ppMessageBox']/div[2]/p"));
            return messageBox.Text;
        }

        public string CheckUpdateStore()
        {
            IWebElement message = driver.FindElement(By.XPath("//*[@id='ppContentContainer']/div[3]/div[2]/div/ul[2]/li[2]"));
            return message.Text;
        }
    }
}