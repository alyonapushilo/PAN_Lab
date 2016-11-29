using NUnit.Framework;

namespace TestIKEA.Tests
{
    [TestFixture]
    public class Tests
    {
        private Steps.Steps steps = new Steps.Steps();

        private const string USEREMAIL = "test-user_bstu@mail.ru";
        private const string USERNAME = "test_user";
        private const string USERNAME_2 = "test_user";
        private const string PASSWORD = "test123";
        private const string FIRM = "ВЁРДА ";
        private const string PRODUCT = "Нож универсальный";
        private const string PRODUCTNUMBER = "00149831";
        private const string PAGENAME = "Чай и кофе";       
        private const string STORE_1 = "ИКЕА Казань";
        private const string STORE_2 = "ИКЕА Омск";        
        private const string LISTNAME = "Номер 1";
        private const string LISTNAME_2 = "Номер 2";

        [SetUp]
        public void Init()
        {
            steps.InitBrowser();
        }

        [TearDown]
        public void Cleanup()
        {
            steps.CloseBrowser();
        }

        [Test]
        public void OneCanLoginIKEA()
        {
            steps.LoginIKEA(USEREMAIL, PASSWORD);
            Assert.True(steps.IsLoggedIn(USERNAME));
            steps.LogoutIKEA();
        }


        [Test]
        public void OneCanLogoutIKEA()
        {
            steps.LoginIKEA(USEREMAIL, PASSWORD);
            steps.LogoutIKEA();
            Assert.True(steps.IsLoggedOutIKEA());
        }

        [Test]
        public void SearchProduct()
        {
            steps.SearchProduct(FIRM, PRODUCT);
            Assert.True(steps.IsFound(FIRM, PRODUCT));
        }

        [Test]
        public void AddProductToList()
        {            
            steps.AddProduct(PRODUCTNUMBER);
            Assert.True(steps.IsAddedProduct());
            steps.OpenShoppingList();
            steps.DeleteProduct(PRODUCTNUMBER);
        }

        [Test]
        public void DeleteProductFromList()
        {
            steps.AddProduct(PRODUCTNUMBER);
            steps.OpenShoppingList();
            steps.DeleteProduct(PRODUCTNUMBER);
            Assert.True(steps.IsDeletedProduct());
        }

        [Test]
        public void CreateShoppingListWithoutAuthorization()
        {
            steps.OpenShoppingList();
            steps.CreateShoppingListWithoutAuthorization();
            Assert.True(steps.IsCreatedShoppingListWithoutAuthorization());
        }

        [Test]
        public void CreateShoppingList()
        {
            steps.LoginIKEA(USEREMAIL, PASSWORD);
            steps.OpenShoppingList();
            steps.CreateShoppingList(LISTNAME);
            Assert.True(steps.IsCreatedShoppingList(LISTNAME)); 
            steps.DeleteShoppingList();
            steps.LogoutIKEA();
        }

        [Test]
        public void DeleteShoppingList()
        {
            steps.LoginIKEA(USEREMAIL, PASSWORD);
            steps.OpenShoppingList();
            steps.CreateShoppingList(LISTNAME);           
            steps.DeleteShoppingList();
            Assert.True(steps.IsDeletedShoppingList()); 
            steps.LogoutIKEA();
        }

        [Test]
        public void RenameShoppingList()
        {
            steps.LoginIKEA(USEREMAIL, PASSWORD);
            steps.OpenShoppingList();
            steps.CreateShoppingList(LISTNAME);
            steps.RenameShoppingList(LISTNAME_2);
            Assert.True(steps.IsRenamedShoppingList());
            steps.LogoutIKEA();
        }

        [Test]
        public void ProductAvailabilityInStore()
        {
            steps.ProductAvailability(FIRM, PRODUCT, STORE_1);
            Assert.True(steps.IsProductAvailable(FIRM, PRODUCT));
        }

        [Test]
        public void NavigationSite()
        { 
            steps.GoToPage(PAGENAME);
            Assert.True(steps.ItPassedToPage(PAGENAME));            
        }

        [Test]
        public void ChangeUsername()
        {
            steps.LoginIKEA(USEREMAIL, PASSWORD);
            steps.ChangeUsername(USERNAME_2);
            Assert.True(steps.IsUpdatedUsername());
            steps.LogoutIKEA();
        }

        [Test]
        public void UpdateNearestStore()
        {
            steps.LoginIKEA(USEREMAIL, PASSWORD);
            steps.UpdateStore(STORE_1);
            Assert.True(steps.IsUpdatedStore(STORE_1));
            steps.UpdateStore(STORE_2);
            steps.LogoutIKEA();
        }

        [Test]
        public void CompareTheFirstTwoProduct()
        {
            steps.SearchProduct(FIRM, "");
            steps.CompareProduct();
            Assert.True(steps.IsComparedProducts());
        }

        [Test]
        public void AddProductByNumber()
        {
            steps.OpenShoppingList();
            steps.AddProductByNumber(PRODUCTNUMBER);
            Assert.True(steps.IsAddedProductByNumber());
        }
    }
}
