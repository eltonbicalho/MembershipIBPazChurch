using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;

namespace Membership
{
    [TestClass()]
    public class StartupFunctionalTests
    {

        private static TestContext testContext;
        private RemoteWebDriver driver;

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            StartupFunctionalTests.testContext = testContext;
        }

        [TestInitialize]
        public void TestInit()
        {
            driver = GetChromeDriver();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(300);
        }

        [TestCleanup]
        public void TestClean()
        {
            driver.Quit();
        }

        private RemoteWebDriver GetChromeDriver()
        {
            var path = Environment.GetEnvironmentVariable("ChromeWebDriver");
            var options = new ChromeOptions();
            options.AddArguments("--no-sandbox");

            if (!string.IsNullOrWhiteSpace(path))
            {
                return new ChromeDriver(path, options, TimeSpan.FromSeconds(300));
            }
            else
            {
                return new ChromeDriver(options);
            }
        }


        [TestMethod()]
        public void ConfigureIndexTest()
        {
            var webAppUrl = testContext.Properties["webAppUrl"].ToString();

            var startTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var endTimestamp = startTimestamp + 60 * 10;

            while (true)
            {
                try
                {
                    driver.Navigate().GoToUrl(webAppUrl);
                    Assert.AreEqual("Home - Membresia", driver.Title, "Expected title to be 'Home - Membresia'");
                    break;
                }
                catch (Exception e)
                {
                    var currentTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                    if (currentTimestamp > endTimestamp)
                    {
                        Console.Write("##vso[task.logissue type=error;]Test MembresiaFunctionalTest1 failed with error: " + e.ToString());
                        throw;
                    }
                    Thread.Sleep(5000);
                }
            }
        }
    }
}