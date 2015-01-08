using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Finish.Page_objects
{
    class LogonPage
    {
        private IWebDriver browser;

        [FindsBy(How=How.Id)]
        IWebElement username { get; set; }
        [FindsBy(How=How.Id)]
        IWebElement password { get; set; }
        [FindsBy(How = How.ClassName, Using = "radius")]
        public IWebElement LoginButton { get; private set; }

        public LogonPage(IWebDriver browser)
        {
            this.browser = browser;
            PageFactory.InitElements(browser, this);
        }

        public HomePage LogonAs(string username, string password)
        {
            this.username.SendKeys(username);
            this.password.SendKeys(password);
            LoginButton.Click();
            return new HomePage(browser);
        }
    }
}
