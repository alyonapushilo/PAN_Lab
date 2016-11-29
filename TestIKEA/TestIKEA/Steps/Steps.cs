using OpenQA.Selenium;

namespace TestIKEA.Steps
{
    public class Steps
    {
        IWebDriver driver;

        public void InitBrowser()
        {
            driver = Driver.DriverInstance.GetInstance();
        }

        public void CloseBrowser()
        {
            Driver.DriverInstance.CloseBrowser();
        }

        public void LoginIKEA(string username, string password)
        {
            Pages.LoginPage loginPage = new Pages.LoginPage(driver);
            loginPage.OpenPage();
            loginPage.Login(username, password);
            System.Threading.Thread.Sleep(2000);
        }

        public bool IsLoggedIn(string username)
        {
            Pages.LoginPage loginPage = new Pages.LoginPage(driver);
            return (loginPage.GetLoggedInUserName().Trim().ToLower().Equals("здравствуйте, " + username));
        }

        public void LogoutIKEA()
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            profilePage.OpenPage();
            profilePage.ClickOnButtonExit();
            
        }
        public bool IsLoggedOutIKEA()
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            return (profilePage.CheckLogout().Trim().ToLower().Equals("вы вышли из системы"));
        }

        public void SearchProduct(string product, string type)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.Search(product, type);
            
        }

        public bool IsFound(string firm, string product)
        {
            Pages.ProductPage productPage = new Pages.ProductPage(driver);
            return productPage.CheckSearch(firm, product);
        }

        public void AddProduct(string productNumber)
        {
            Pages.ProductPage productPage = new Pages.ProductPage(driver);
            productPage.OpenPage(productNumber);
            productPage.Add();
            
        }

        public bool IsAddedProduct()
        {
            Pages.ProductPage productPage = new Pages.ProductPage(driver);
            return (productPage.CheckAdd().Trim().Equals("Добавленные товары"));
        }

        public void DeleteProduct(string number)
        {
            Pages.ShoppingListPage listPage = new Pages.ShoppingListPage(driver);
            listPage.DeleteProduct(number);
            
        }

        public bool IsDeletedProduct()
        {
            Pages.ShoppingListPage listPage = new Pages.ShoppingListPage(driver);
            return listPage.CheckDeleteProduct();
        }

        public void OpenShoppingList()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.OpenShoppingList();
        }

        public void CreateShoppingListWithoutAuthorization()
        {
            Pages.ShoppingListPage listPage = new Pages.ShoppingListPage(driver);
            listPage.CreateListWithoutAuthorization();
        }

        public bool IsCreatedShoppingListWithoutAuthorization()
        {
            Pages.ShoppingListPage listPage = new Pages.ShoppingListPage(driver);
            return (listPage.CheckCreateListWithoutAuthorization().Trim().ToLower().Equals("войти в систему"));
        }

        public void CreateShoppingList(string listName)
        {
            Pages.ShoppingListPage listPage = new Pages.ShoppingListPage(driver);
            listPage.CreateList(listName);
           
        }

        public bool IsCreatedShoppingList(string listName)
        {
            Pages.ShoppingListPage listPage = new Pages.ShoppingListPage(driver);
            return (listPage.CheckCreateList().Trim().Equals(listName));
        }

        public void DeleteShoppingList()
        {
            Pages.ShoppingListPage listPage = new Pages.ShoppingListPage(driver);
            listPage.DeleteList();
            
        }

        public bool IsDeletedShoppingList()
        {
            Pages.ShoppingListPage listPage = new Pages.ShoppingListPage(driver);
            return (listPage.CheckDeleteList().Equals("Список «{listname}» был удален"));
        }

        public void RenameShoppingList(string listName)
        {
            Pages.ShoppingListPage listPage = new Pages.ShoppingListPage(driver);
            listPage.RenameList(listName);
    
        }

        public bool IsRenamedShoppingList()
        {
            Pages.ShoppingListPage listPage = new Pages.ShoppingListPage(driver);
            return (listPage.CheckRenameList().Equals("Список был переименован"));
        }

        public void ProductAvailability(string firm, string product,string store)
        {
            Pages.ProductAvailabilityPage page = new Pages.ProductAvailabilityPage(driver);
            page.OpenPage();
            page.ProductAvailability(firm, product, store);

        }

        public bool IsProductAvailable(string firm, string product)
        {
            Pages.ProductAvailabilityPage page = new Pages.ProductAvailabilityPage(driver);            
            return page.CheckProductAvailability();
        }

        public void GoToPage(string pageName)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.OpenProductPage(pageName);
        }

       public bool ItPassedToPage(string pageName)
        {
            string title = driver.Title;
            if (string.Compare(title.Trim().ToLower(), 0, pageName.ToLower(), 0, pageName.Length) == 0)
                return true;
            return false;
        }

       public void ChangeUsername(string username)
       {
           Pages.UpdateUserPage updatePage = new Pages.UpdateUserPage(driver);
           updatePage.OpenPage();
           updatePage.Update(username);
       }

       public bool IsUpdatedUsername()
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            return (profilePage.CheckChangeUsername().Trim().Equals("Ваша личная информация изменена"));
        }

        public void UpdateStore(string store)
        {
            Pages.UpdateStorePage updatePage = new Pages.UpdateStorePage(driver);
            updatePage.OpenPage();
            updatePage.SelectStore(store);
            updatePage.Save();
        }

        public bool IsUpdatedStore(string store)
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            return (profilePage.CheckUpdateStore().Trim().Equals("Ближайший магазин: "+ store));
        }

        public void CompareProduct()
        {
            Pages.SearchPage searchPage = new Pages.SearchPage(driver);
            searchPage.ClickCheckbox1();
            searchPage.ClickCheckbox2();
            searchPage.ClickButtonCompare();
        }

        public bool IsComparedProducts()
        {
            Pages.SearchPage searchPage = new Pages.SearchPage(driver);
            return (searchPage.CheckCompareProduct().Equals("Сравнение"));
        }

        public void AddProductByNumber(string productNumber)
        {
            Pages.ShoppingListPage listPage= new Pages.ShoppingListPage(driver);
            listPage.AddProduct(productNumber);
        }

        public bool IsAddedProductByNumber()
        {
            Pages.ShoppingListPage listPage = new Pages.ShoppingListPage(driver);
            return (listPage.CheckAddProduct().Equals("ВЁРДА"));
        }















    }
}


