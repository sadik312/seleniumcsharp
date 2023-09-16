using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OpenQA.Selenium;
using NuGet.Frameworks;
using OpenQA.Selenium.Interactions;

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

            /* can also use:
            driver.Url = "http://localhost:4200";
            however, Navigate func is preferrable for more functions like:
            driver.Navigate().Refresh();
            driver.Navigate().Back();
            driver.Navigate().Forward();
            */
        }
        [Test]
        public void VerifyCurrentURl()
        {
            Assert.That(driver.Url, Contains.Substring("http://localhost:4200"));
            // where driver.Url can be used to verify url of target being tested
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
        [Test]
        public void TestWithAssertion()
        {
            driver.FindElement(By.Id("full-name")).SendKeys("John Smith");
            driver.FindElement(By.Id("add-btn")).Click();

            // are equal / are not equal = used to assert values
            var totalPrice = driver.FindElement(By.CssSelector("tfoot tr th:nth-child(3"));
            Assert.That(totalPrice.Text, Is.EqualTo("$100.00"), "Total price is not valid");
        }
        [Test]
        public void usingClickTest()
        {
            /*
            Click command will only succeed if:
            - Element if visible
            - Not disabled
            - Not placed under another element
            */
            var nameInput = driver.FindElement(By.Id("full-name"));
            nameInput.SendKeys("John Smith");

            var addButton = driver.FindElement(By.Id("add-btn"));
            addButton.Click();
            Assert.That(driver.FindElements(By.CssSelector("tbody tr")), Has.Count.EqualTo(1));
        }
        [Test]
        public void UsingDoubleClickTest()
        {
            // Double click command is not present in WebDriver interface
            // Need to use another interface that exposes the action of double click
            // Called 'Actions'

            var addButton = driver.FindElement(By.Id("add-btn"));
            var actions = new Actions(driver);
            actions.DoubleClick(addButton).Perform();

            Assert.That(driver.FindElement(By.Id("full-name_validation-error")).Displayed, Is.True);
        }
        [TearDown]
        public void TearDown()
        {
            // clean up resources
            driver.Quit();
        }
    }
}
