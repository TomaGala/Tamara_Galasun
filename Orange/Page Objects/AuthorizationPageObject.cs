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

        // Заповнення текстового вікна Login (введення імені користувача)
        public void Login(string username)
        {
            _webDriver.FindElement(UsernameTextbox).SendKeys(username);
        }

        // Заповнення текстового вікна Password (введення пароля)
        public void Password(string password)
        {
            _webDriver.FindElement(PasswordTextbox).SendKeys(password);
        }

        // Натискання кнопки Login, щоб авторизуватися на сайті
        public void LoginClick()
        {
            _webDriver.FindElement(LoginButton).Click();
        }
    }
}