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
    internal class SimpleGloboTicketsTest
    {
        [Test]
        public void SimpleTest()
        {
            // 1. Start web browser
            var driver = new ChromeDriver();
            // Set window size
            driver.Manage().Window.Size = new Size(1920, 1080);
            // 2. Pass through URL for application to be tested
            driver.Navigate().GoToUrl("http://localhost:4200");
            // 3. Locate Name input and Done button and enter input
            driver.FindElement(By.Id("fullName")).SendKeys("Josh Smith");
            driver.FindElement(By.Id("add-btn")).Click();

            // Relvative Locator
            driver.FindElement(RelativeBy
                .WithLocator(By.TagName("textarea"))
                .Below(By.TagName("full-name")))
                .SendKeys("Something important");

            // 4. Terminate driver
            // driver.Quit();
        }
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

            driver.Quit();
        }
    }
}
