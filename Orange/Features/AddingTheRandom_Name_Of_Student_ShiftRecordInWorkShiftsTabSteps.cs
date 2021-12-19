using OpenQA.Selenium;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OrangeTESTS.Page_Objects;
namespace OrangeTESTS.Features
{
    [Binding]
    public class AddingTheRandom_Name_Of_Student_ShiftRecordInWorkShiftsTabSteps
    {
        private IWebDriver Driver;

        [Given(@"authorization on the website is complete")]
        public void GivenAuthorizationOnTheWebsiteIsComplete()
        {
            Driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            Driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
            Driver.Manage().Window.Maximize();

            var authorization = new AuthorizationPageObject(Driver);
            authorization.Login("Admin");
            authorization.Password("admin123");
            authorization.LoginClick();
        }

        [Given(@"I am on the OrangeHRM's site page where the Work Shifts tab is")]
        public void GivenIAmOnTheOrangeHRMSSitePageWhereTheWorkShiftsTabIs()
        {
            Driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/index.php/admin/workShift");
        }
        
        [Given(@"I click Add button")]
        public void GivenIClickAddButton()
        {
            var new_record = new NewRecordPageObject(Driver);
            new_record.AddNewRecord(); 
        }
        
        [Given(@"I enter ""(.*)"" in the field Shift Name \*")]
        public void GivenIEnterInTheFieldShiftName(string shiftname)
        {
            var new_record = new NewRecordPageObject(Driver);
            new_record.ShiftName(shiftname); 
        }
        
        [Given(@"I select ""(.*)"" in a FROM field that is in line with the Work Hours \* field")]
        public void GivenISelectInAFromFieldThatIsInLineWithTheWorkHoursField(string hours_from)
        {
            var new_record = new NewRecordPageObject(Driver);
            new_record.WorkHours_from(hours_from);

        }
        
        [Given(@"I select ""(.*)"" in a TO field that is in line with the Work Hours \* field")]
        public void GivenISelectInAToFieldThatIsInLineWithTheWorkHoursField(string hours_to)
        {
            var new_record = new NewRecordPageObject(Driver);
            new_record.WorkHours_from(hours_to);
        }
        
        [Given(@"I add all Available Employees to Assigned Employees list")]
        public void GivenIAddAllAvailableEmployeesToAssignedEmployeesList()
        {
            var new_record = new NewRecordPageObject(Driver);
            new_record.AddEmployees();
        }
        
        [When(@"I click Save button")]
        public void WhenIClickSaveButton()
        {
            var new_record = new NewRecordPageObject(Driver);
            new_record.SaveRecord(); 
        }

        [Then(@"the error message \(Required\) under Shift Name \* field should appear")]
        public void ThenTheErrorMessageRequiredUnderShiftNameFieldShouldAppear()
        {
            IWebElement check_name = Driver.FindElement(By.XPath("//*[text()='Required']"));
            Assert.IsTrue(check_name.Displayed);
            Driver.Quit();
        }
        
        [Then(@"the record with the Random_name_of_student_shift shift name should be visible in the list of work shifts")]
        public void ThenTheRecordWithTheRandom_Name_Of_Student_ShiftShiftNameShouldBeVisibleInTheListOfWorkShifts()
        {
            IWebElement check_name = Driver.FindElement(By.XPath("//*[text()='Random_name_of_student_shift']"));
            Assert.IsTrue(check_name.Displayed);
            Driver.Quit();
        }
    }
}
