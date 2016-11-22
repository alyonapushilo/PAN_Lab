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
        private const string BASE_URL = "https://secure.ikea.com/webapp/wcs/stores/servlet/MyProfile?langId=-31&storeId=23&krypto=n3hIM%2BbloffJq1iKb62b0JIFN%2FnoFk6%2FG7gP0AgpjkssMaxIHaVgZXns9AypDOHTjOuBhuHkY%2BxZh0HTumIvQ4jd4llxRHeGfStzuZgpAT1T%2BgVys%2BtFD%2BbWEejFnW0HD%2FCSQKmBrm8oWl2JChVhCg%2Bu5ita%2BfbGeP8wXWrIk0PXnNMxL1Yuz8a1pOSlqtfoV0UpFAkDRsKFUO0e8AiijAQioL%2FmX73p8IFmMex4iu8txl0A%2Fm9vPyHdLo%2Fkwrz1&ddkey=https%3ALogon";

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

        public override void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public void ClickOnButtonExit()
        {
            buttonExit.Click();
        }

        public string CheckLogout()
        {

            IWebElement linkLoggedOff = driver.FindElement(By.CssSelector("#txtMainHdr1 > h1"));
            return linkLoggedOff.Text;
        }

        public string CheckUpdatePrivatePersonal()
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