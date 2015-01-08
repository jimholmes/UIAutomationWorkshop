using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Start
{
    [TestFixture]
    class When_loading_dynamic_content
    {
        private IWebDriver browser;

        [TestFixtureSetUp]
        public void run_once_before_anything_else()
        {
            browser = new FirefoxDriver();
            browser.Navigate().GoToUrl("http://the-internet.herokuapp.com/dynamic_loading/2");
        }

        [TestFixtureTearDown]
        public void run_after_everything_else()
        {
            browser.Quit();
        }

        [Test]
        public void clicking_start_displays_message()
        {
            browser.FindElement(By.CssSelector("#start > button")).Click();

            WebDriverWait wait = new WebDriverWait(browser,
                TimeSpan.FromSeconds(30));

            wait.Until(ExpectedConditions.ElementExists(
                By.CssSelector("#finish > h4")));

            Assert.IsTrue(
                browser.FindElement(By.Id("finish")).Text.Contains("Hello World!")
                );
        }
    }
}
