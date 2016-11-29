using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace TestIKEA.Pages
{
    class ShoppingListPage:AbstractPage
    {
        private const string BASE_URL = "http://www.ikea.com/webapp/wcs/stores/servlet/InterestItemDisplay";

        [FindsBy(How = How.XPath, Using = "//*[@id='jsButton_ShoppingList_11']/div[2]/input")]
        private IWebElement buttonCreateList;
               
        private IWebElement inputListName;
       
        private IWebElement buttonCreate;
       
        private IWebElement buttonDeleteList;
                
        private IWebElement buttonDelete;

        private IWebElement buttonRenameList;

        private IWebElement inputListNewName;

        private IWebElement buttonRename;
        
        private IWebElement buttonDeleteProduct;

        [FindsBy(How = How.Id, Using = "partNumber")]
        private IWebElement inputPartNumber;

        [FindsBy(How = How.XPath, Using = "//*[@id='jsButton_ShoppingList_01']/div[2]/input")]
        private IWebElement buttonAddProduct;


        public ShoppingListPage(IWebDriver driver):base(driver)
        {            
            PageFactory.InitElements(this.driver, this);
            buttonCreateList = driver.FindElement(By.Id("jsButton_ShoppingList_11")).FindElement(By.TagName("input"));
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public void CreateListWithoutAuthorization()
        {
            buttonCreateList.Click();
        }

        public string CheckCreateListWithoutAuthorization()
        {
            IWebElement message = driver.FindElement(By.Id("slPopupH1"));
            return message.Text;
        }

        public void CreateList(string listName)
        {
            buttonCreateList.Click();
            System.Threading.Thread.Sleep(2000);
            inputListName = driver.FindElement(By.Id("listName"));
            inputListName.SendKeys(listName);
            System.Threading.Thread.Sleep(2000);
            buttonCreate = driver.FindElement(By.XPath("//*[@id='jsButton_shopListPopup']/div[2]/input"));
            buttonCreate.Click();
            System.Threading.Thread.Sleep(2000);
        }

        public string CheckCreateList()
        {
            IWebElement message = driver.FindElement(By.ClassName("navItem")).FindElement(By.ClassName("active"));//новый список как тебя найти
            return message.Text;
        }

        public void DeleteList()
        {
            buttonDeleteList = driver.FindElement(By.Id("btnDeleteList"));
            buttonDeleteList.Click();
            System.Threading.Thread.Sleep(2000);
            buttonDelete = driver.FindElement(By.XPath("//*[@id='jsButton_shopListPopup']/div[2]/input"));
            buttonDelete.Click();
            System.Threading.Thread.Sleep(2000);
        }

        public string CheckDeleteList()
        {
            IWebElement message = driver.FindElement(By.Id("errMsg.confirm"));
            return message.Text;   
        }

        public void RenameList(string listName)
        {
            buttonRenameList = driver.FindElement(By.Id("btnRenameList"));
            buttonRenameList.Click();
            System.Threading.Thread.Sleep(1000);
            inputListNewName = driver.FindElement(By.Id("listName"));
            inputListNewName.SendKeys(listName);            
            buttonRename = driver.FindElement(By.Id("jsButton_shopListPopup_4")).FindElement(By.TagName("input"));
            buttonRename.Click();
            System.Threading.Thread.Sleep(2000);
        }

        public string CheckRenameList()
        {
            IWebElement message = driver.FindElement(By.Id("errMsg.confirm"));
            return message.Text;
        }


        public void DeleteProduct(string number)
        {
            driver.FindElement(By.Id("tr_"+number)).FindElement(By.LinkText("Удалить")).Click();
            System.Threading.Thread.Sleep(2000);
        }

        public bool CheckDeleteProduct()
        {                       
            string message = driver.FindElement(By.Id("emptyListMsg")).Text;            
            string msg = "Ваш список покупок пуст";
            if (string.Compare(message.Trim().ToLower(), 0, msg.ToLower(), 0, msg.Length) == 0)
                return true;
            return false;            
        }

        public void AddProduct(string productNumber)
        {
            inputPartNumber.Click();
            inputPartNumber.SendKeys(productNumber);
            buttonAddProduct.Click();
        }

        public string CheckAddProduct()
        {
            IWebElement name = driver.FindElement(By.XPath("//*[@id='tr_10289246']/td[1]/div/a/span[1]"));
            return name.Text;
        }


    }
}
