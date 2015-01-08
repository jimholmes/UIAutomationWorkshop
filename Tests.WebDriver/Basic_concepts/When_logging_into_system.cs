using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Finish.Basic_concepts
{
    [TestFixture]
    public class When_logging_into_system
    {

        [Test]
        public void proper_creds_logs_user_on()
        {
            IWebDriver browser = new FirefoxDriver();
            browser.Navigate().GoToUrl("http://the-internet.herokuapp.com/login");

            browser.FindElement(By.Id("username")).SendKeys("tomsmith");
            browser.FindElement(By.Id("password")).SendKeys("SuperSecretPassword!");
            browser.FindElement(By.ClassName("radius")).Click();

            Assert.AreEqual(
                "Secure Area",
                browser.FindElement(By.TagName("h2")).Text);

            Assert.IsTrue(
                browser.FindElement(By.CssSelector("a.button.secondary.radius"))
                .Displayed
                );

            browser.Quit();
        }



    }
}
