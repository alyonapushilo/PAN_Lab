using NUnit.Framework;

namespace TestIKEA.Tests
{
    [TestFixture]
    public class Tests
    {
        private Steps.Steps steps = new Steps.Steps();

        private const string USEREMAIL = "test-user_bstu@mail.ru";
        private const string USERNAME = "test_user";
        private const string PASSWORD = "test123";
        private const string FIRM = "ВЁРДА ";
        private const string PRODUCT = "Нож универсальный";
        private const string TITLE = "Чай и кофе - Кружки и чашки & Термосы - IKEA";
        private const string STORE_1 = "ИКЕА Казань";
        private const string STORE_2 = "ИКЕА Омск";

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

        [Test]//+
        public void OneCanLoginIKEA()
        {
            steps.LoginIKEA(USEREMAIL, PASSWORD);
            Assert.True(steps.IsLoggedIn(USERNAME));
            steps.LogoutIKEA();
        }


        [Test]//+
        public void OneCanLogoutIKEA()
        {
            steps.LoginIKEA(USEREMAIL, PASSWORD);
            steps.LogoutIKEA();
            Assert.True(steps.IsLoggedOutIKEA());
        }

        [Test]//+
        public void SearchProduct()
        {
            steps.SearchProduct(FIRM, PRODUCT);
            Assert.AreEqual(0, steps.IsSearch(FIRM, PRODUCT));
        }

        [Test]//+
        public void AddProductToList()
        {
            steps.AddProduct();
            Assert.True(steps.IsAddedProduct());
            steps.OpenShoppingList();
            steps.DeleteProduct();
        }

        [Test]
        public void DeleteProductToList()
        {
            steps.AddProduct();
            steps.OpenShoppingList();
            steps.DeleteProduct();
            Assert.AreEqual(0, steps.IsDeletedProduct());
        }

        [Test]//+
        public void CreateShoppingListLogout()
        {
            steps.OpenShoppingList();
            steps.CreateShoppingListLogout();
            Assert.True(steps.IsCreatedShoppingListLogout());
        }

        [Test]
        public void CreateShoppingList()
        {
            steps.LoginIKEA(USEREMAIL, PASSWORD);
            steps.OpenShoppingList();
            steps.CreateShoppingList();
            Assert.True(steps.IsCreatedShoppingList()); 
            steps.DeleteShoppingList();
            steps.LogoutIKEA();
        }

        [Test]
        public void DeleteShoppingList()
        {
            steps.LoginIKEA(USEREMAIL, PASSWORD);
            steps.OpenShoppingList();
            steps.CreateShoppingList();           
            steps.DeleteShoppingList();
            Assert.True(steps.IsDeletedShoppingList()); 
            steps.LogoutIKEA();
        }

        [Test]
        public void RenameShoppingList()
        {
            steps.LoginIKEA(USEREMAIL, PASSWORD);
            steps.OpenShoppingList();
            steps.CreateShoppingList();
            steps.RenameShoppingList();
            Assert.True(steps.IsRenamedShoppingList());
            steps.LogoutIKEA();
        }

        [Test]//+
        public void ProductAvailabilityInStore()
        {
            steps.ProductAvailability(FIRM, PRODUCT);
            Assert.AreEqual(0, steps.IsProductAvailable(FIRM, PRODUCT));
        }

        [Test]
        public void NavigationSite()
        { 
            steps.Navigation();
            Assert.True(steps.IsNavigation(TITLE));            
        }

        [Test]
        public void UpdatePrivatePersonal()
        {
            steps.LoginIKEA(USEREMAIL, PASSWORD);
            steps.UpdatePrivatePersonal();
            Assert.True(steps.IsUpdatedPrivatePersonal());
            steps.LogoutIKEA();
        }

        [Test]
        public void Updatestore()
        {
            steps.LoginIKEA(USEREMAIL, PASSWORD);
            steps.UpdateStore(STORE_1);
            Assert.True(steps.IsUpdatedStore(STORE_1));
            steps.UpdateStore(STORE_2);
            steps.LogoutIKEA();
        }

        [Test]
        public void CompareProduct()
        {
            steps.SearchProduct(FIRM, "");
            steps.CompareProduct();
            Assert.True(steps.IsCompareProduct());
        }

        [Test]
        public void AddProductByNumber()
        {
            steps.OpenShoppingList();
            steps.AddProductByNumber();
            Assert.True(steps.IsaddedProductByNumber());
        }
    }
}
