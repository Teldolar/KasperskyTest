using Aquality.Selenium.Browsers;
using NUnit.Framework;

namespace TestProject1.Utils
{
    
    [TestFixture()]
    public class BaseTest
    {
        protected Browser Driver;
        
        [SetUp]
        public void Setup()
        { 
            Driver = AqualityServices.Browser;
            Driver.Maximize();
        }
                
        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}