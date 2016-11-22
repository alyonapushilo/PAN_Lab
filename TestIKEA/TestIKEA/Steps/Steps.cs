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
            System.Threading.Thread.Sleep(2000);
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
            System.Threading.Thread.Sleep(2000);
        }

        public int IsSearch(string firm, string product)
        {
            Pages.ProductPage productPage = new Pages.ProductPage(driver);
            string title = productPage.GetTitle();
            return string.Compare(title.Trim().ToLower(), 0, (firm + product).ToLower(), 0, (firm + product).Length);
        }

        public void AddProduct()
        {
            Pages.ProductPage productPage = new Pages.ProductPage(driver);
            productPage.OpenPage();
            productPage.Add();
            System.Threading.Thread.Sleep(5000);
        }

        public bool IsAddedProduct()
        {
            Pages.ProductPage productPage = new Pages.ProductPage(driver);
            return (productPage.CheckAdd().Trim().Equals("Добавленные товары"));
        }

        public void DeleteProduct()
        {
            Pages.ShoppingListPage listPage = new Pages.ShoppingListPage(driver);
            listPage.DeleteProduct();
            System.Threading.Thread.Sleep(2000);
        }

        public int IsDeletedProduct()
        {
            Pages.ShoppingListPage listPage = new Pages.ShoppingListPage(driver);
            string msg = "Ваш список покупок пуст";
            return string.Compare(listPage.CheckDeleteProduct().Trim().ToLower(), 0, msg.ToLower(), 0, msg.Length);
        }

        public void OpenShoppingList()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.OpenShoppingList();
        }

        public void CreateShoppingListLogout()
        {
            Pages.ShoppingListPage listPage = new Pages.ShoppingListPage(driver);
            listPage.CreateListLogout();
        }

        public bool IsCreatedShoppingListLogout()
        {
            Pages.ShoppingListPage listPage = new Pages.ShoppingListPage(driver);
            return (listPage.CheckCreateListLogout().Trim().ToLower().Equals("войти в систему"));
        }

        public void CreateShoppingList()
        {
            Pages.ShoppingListPage listPage = new Pages.ShoppingListPage(driver);
            listPage.CreateList();
            System.Threading.Thread.Sleep(2000);
        }

        public bool IsCreatedShoppingList()
        {
            Pages.ShoppingListPage listPage = new Pages.ShoppingListPage(driver);
            return (listPage.CheckCreateList().Trim().Equals("Номер 1"));
        }

        public void DeleteShoppingList()
        {
            Pages.ShoppingListPage listPage = new Pages.ShoppingListPage(driver);
            listPage.DeleteList();
            System.Threading.Thread.Sleep(2000);
        }

        public bool IsDeletedShoppingList()
        {
            Pages.ShoppingListPage listPage = new Pages.ShoppingListPage(driver);
            return (listPage.CheckDeleteList().Equals("Список «{listname}» был удален"));
        }

        public void RenameShoppingList()
        {
            Pages.ShoppingListPage listPage = new Pages.ShoppingListPage(driver);
            listPage.RenameList();
            System.Threading.Thread.Sleep(2000);
        }

        public bool IsRenamedShoppingList()
        {
            Pages.ShoppingListPage listPage = new Pages.ShoppingListPage(driver);
            return (listPage.CheckRenameList().Equals("Список был переименован"));
        }

        public void ProductAvailability(string firm, string product)
        {
            Pages.ProductAvailabilityPage page = new Pages.ProductAvailabilityPage(driver);
            page.OpenPage();
            page.PrdctAvailability(firm, product);
            System.Threading.Thread.Sleep(2000);
        }

        public int IsProductAvailable(string firm, string product)
        {
            Pages.ProductAvailabilityPage page = new Pages.ProductAvailabilityPage(driver);
            string msg = "Товар будет в наличии";
            return string.Compare(page.GetHeader().Trim().ToLower(), 0, msg.ToLower(), 0, msg.Length);
        }

        public void Navigation ()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.OpenProductPage();
        }

       public bool IsNavigation(string title)
        {
           return driver.Title.Equals(title);
        }

        public void UpdatePrivatePersonal()
       {
           Pages.UpdateUserPage updatePage = new Pages.UpdateUserPage(driver);
           updatePage.OpenPage();
           updatePage.Update();
       }

        public bool IsUpdatedPrivatePersonal()
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);            
            return (profilePage.CheckUpdatePrivatePersonal().Trim().Equals("Ваша личная информация изменена"));
        }

        public void UpdateStore(string store)
        {
            Pages.UpdateStorePage updatePage = new Pages.UpdateStorePage(driver);
            updatePage.OpenPage();
            if (store.Equals("ИКЕА Казань"))
                updatePage.ClickKazan();
            else
                updatePage.ClickOmsk();
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

        public bool IsCompareProduct()
        {
            Pages.SearchPage searchPage = new Pages.SearchPage(driver);
            return (searchPage.CheckCompareProduct().Equals("Сравнение"));
        }

        public void AddProductByNumber()
        {
            Pages.ShoppingListPage listPage= new Pages.ShoppingListPage(driver);           
            listPage.AddProduct();
        }

        public bool IsaddedProductByNumber()
        {
            Pages.ShoppingListPage listPage = new Pages.ShoppingListPage(driver);
            return (listPage.CheckAddProduct().Equals("ВЁРДА"));
        }















    }
}


