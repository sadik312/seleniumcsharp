using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
