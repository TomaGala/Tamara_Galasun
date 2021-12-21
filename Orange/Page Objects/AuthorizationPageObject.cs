using OpenQA.Selenium;

namespace OrangeTESTS.Page_Objects
{
    class AuthorizationPageObject
    {
        private IWebDriver _webDriver;
        private readonly By UsernameTextbox = By.XPath(".//*[@id='txtUsername']");
        private readonly By PasswordTextbox = By.XPath(".//*[@id='txtPassword']");
        private readonly By LoginButton = By.XPath(".//*[@id='btnLogin']");

        public AuthorizationPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        // Filling in the Login text box
        public void Login(string username)
        {
            _webDriver.FindElement(UsernameTextbox).SendKeys(username);
        }

        // Filling the Password text box
        public void Password(string password)
        {
            _webDriver.FindElement(PasswordTextbox).SendKeys(password);
        }

        // Click the Login button to log in to the site
        public void LoginClick()
        {
            _webDriver.FindElement(LoginButton).Click();
        }
    }
}