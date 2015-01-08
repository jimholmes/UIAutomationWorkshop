using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;

namespace Finish.Page_objects
{
    class When_logging_into_system_pageobjects
    {
        IWebDriver browser;

        [TestFixtureSetUp]
        public void run_before_any_tests()
        {
            browser = new FirefoxDriver();
            browser.Navigate().GoToUrl("http://the-internet.herokuapp.com/login");
        }

        [TestFixtureTearDown]
        public void run_after_all_tests_are_complete()
        {
            browser.Quit();
        }

        [Test]
        public void proper_creds_logs_user_on()
        {
            LogonPage login = new LogonPage(browser);
            HomePage home = login.LogonAs("tomsmith", "SuperSecretPassword!");
            Assert.AreEqual("Logout", home.LogoutButton.Text);
            string targetUrl = home.LogoutButton.GetAttribute("href");
            Assert.IsTrue(targetUrl.EndsWith("/logout"));
        }
    }
}
