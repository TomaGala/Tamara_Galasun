using OpenQA.Selenium;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OrangeTESTS.Page_Objects;

namespace OrangeTESTS.Features
{
    [Binding]
    public class AuthorizationOnOrangeHRMSiteSteps 
    {
        private IWebDriver Driver;

        [Given(@"I am on the OrangeHRM's site page where the LOGIN Panel is")]
        public void GivenIAmOnTheOrangeHRMSSitePageWhereTheLOGINPanelIs()
        {
            Driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            Driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
        }

        [When(@"I enter (.*) as a Username")]
        public void WhenIEnterAsAUsername(string username)
        {
            var authorization = new AuthorizationPageObject(Driver);
            authorization.Login(username);
        }
        
        [When(@"I enter (.*) as a Password")]
        public void WhenIEnterAsAPassword(string password)
        {
            var authorization = new AuthorizationPageObject(Driver);
            authorization.Password(password);
        }
        
        [When(@"I click Login button on the LOGIN Panel")]
        public void WhenIClickLoginButtonOnTheLOGINPanel()
        {
            var authorization = new AuthorizationPageObject(Driver);
            authorization.LoginClick();
        }
        
        [Then(@"the url should be (.*)")]
        public void ThenTheUrlShouldBe(string url)
        {
             Assert.AreEqual(url, "<https://opensource-demo.orangehrmlive.com/index.php/dashboard>");
             Driver.Quit();
        }
        
        [Then(@"the url should stay the same (.*)")]
        public void ThenTheUrlShouldStayTheSame(string URL)
        {
            Assert.AreEqual(URL, "<https://opensource-demo.orangehrmlive.com/>");
            Driver.Quit();
        }
    }
}
