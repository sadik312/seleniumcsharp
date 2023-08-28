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
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
            // 2. Pass through URL for application to be tested
            driver.Navigate().GoToUrl("http://localhost:4200");
            // 3. Locate Name input and Done button and enter input
            driver.FindElement(By.Id("fullName")).SendKeys("Josh Smith");
            driver.FindElement(By.Id("add-btn")).Click();

            // 4. Terminate driver
            driver.Quit();
        }
    }
}
