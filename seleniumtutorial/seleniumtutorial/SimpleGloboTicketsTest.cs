using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OpenQA.Selenium;

namespace seleniumtutorial
{
    [TestFixture]
    internal class SimpleGloboTicketsTest
    {
        private IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            // initialise webdriver and set window size
            driver = new ChromeDriver();
            driver.Manage().Window.Size = new Size(1920, 1080);
            // navigate to url of test app
            driver.Navigate().GoToUrl("http://localhost:4200");
        }
        [Test]
        public void SimpleTest()
        {
            // Locate Name input and Done button and enter input
            driver.FindElement(By.Id("fullName")).SendKeys("Josh Smith");
            driver.FindElement(By.Id("add-btn")).Click();

            // Relative Locator
            driver.FindElement(RelativeBy
                .WithLocator(By.TagName("textarea"))
                .Below(By.TagName("full-name")))
                .SendKeys("Something important");

        }
        // Test using Relative Locators
        [Test]
        public void UsingRelativeLocators()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Size = new Size(1920, 1080);
            driver.Navigate().GoToUrl("http://localhost:4200");
            // use relative locator
            driver.FindElement(RelativeBy
                .WithLocator(By.TagName("textarea"))
                .Below(By.TagName("full-name")))
                .SendKeys("Something important");

            // Select multiple elements using 'FindElements' method
            driver.FindElements(RelativeBy
                .WithLocator(By.CssSelector("input[type='checkbox']"))
                .Above(By.Id("add-btn")))
                .First()
                .Click();

        }
        [TearDown]
        public void TearDown()
        {
            // clean up resources
            driver.Quit();
        }
    }
}
