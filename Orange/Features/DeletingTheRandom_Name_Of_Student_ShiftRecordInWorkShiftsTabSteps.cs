using OpenQA.Selenium;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OrangeTESTS.Page_Objects;
using System;

namespace OrangeTESTS.Features
{
    [Binding]
    public class DeletingTheRandom_Name_Of_Student_ShiftRecordInWorkShiftsTabSteps
    {
        private IWebDriver Driver;

        [Given(@"I performed authorization on the OrangeHRM's site page and the Random_name_of_student_shift record is already created")]
        public void GivenIPerformedAuthorizationOnTheOrangeHRMSSitePageAndTheRandom_name_of_student_shiftRecordIsAlreadyCreated()
        {
            Driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            Driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
            Driver.Manage().Window.Maximize();

            var authorization = new AuthorizationPageObject(Driver);
            authorization.Login("Admin");
            authorization.Password("admin123");
            authorization.LoginClick();
        }
        
        [Given(@"I am on the OrangeHRM site page where the Work Shifts tab is")]
        public void GivenIAmOnTheOrangeHRMSitePageWhereTheWorkShiftsTabIs()
        {
            Driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/index.php/admin/workShift");
        }
        
        [When(@"I check the box near the Random_name_of_student_shift record")]
        public void WhenICheckTheBoxNearTheRandom_Name_Of_Student_ShiftRecord()
        {
            IWebElement element_to_delete = Driver.FindElement(By.XPath("//td[@class='left']/a[text()='Random_name_of_student_shift']"));
            IWebElement row = element_to_delete.FindElement(By.XPath("./../.."));
            row.FindElement(By.XPath("td[1]/input")).Click();
        }
        
        [When(@"I click Delete button")]
        public void WhenIClickDeleteButton()
        {
            var delete = new NewRecordPageObject(Driver);
            delete.DeleteRecord();
        }
        
        [Then(@"the Random_name_of_student_shift record should not be visible in the list of work shifts")]
        public void ThenTheRandom_Name_Of_Student_ShiftRecordShouldNotBeVisibleInTheListOfWorkShifts()
        {
            Boolean exist = Driver.FindElements(By.XPath("//*[text()='Random_name_of_student_shift']")).Count == 0;
            Driver.Quit();
        }
    }
}
