using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Finish.Page_objects
{
       
    public class HomePage
    {
        [FindsBy(How = How.CssSelector,Using ="#content > div > a")]
        public IWebElement LogoutButton { get; private set; }

        public HomePage(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
        }
    }
}