using NUnit.Framework;
using OpenQA.Selenium;
using OrangeTESTS.Page_Objects;
using System;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Commons;


namespace OrangeTESTS
{
    [AllureNUnit]
    [AllureSuite("OrangeHRMTests")]
    [AllureDisplayIgnored]
    [TestFixture]
    public class TESTS
    {
        private IWebDriver driver;
        
        [SetUp]
        public void Setup()
        {
            // Follow the link to the OrangeHRM site for authorization
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
            driver.Manage().Window.Maximize();

            // Log in: transfer login and password
            var authorization = new AuthorizationPageObject(driver);
            authorization.Login("Admin");
            authorization.Password("admin123");
            authorization.LoginClick();

            // Follow the link to the Work Shifts page (Admin -> Job -> Work Shifts) 
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/index.php/admin/workShift");
        }

        [Test(Description = "Create and Delete New Record")]
        [AllureTag("SeleniumHomeTask")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureIssue("8911")]
        [AllureTms("532")]

        public void Test()
        {
            // Create new record:
            var new_record = new NewRecordPageObject(driver);
            new_record.AddNewRecord(); // button to add a new record
            new_record.ShiftName("Random_name_of_student_shift"); // shift name
            new_record.WorkHours_from("06:00"); // setting the beginning of the working day
            new_record.WorkHours_to("18:00"); // setting the ending of the working day
            new_record.AddEmployees(); // adding available employees
            new_record.SaveRecord(); // button to save new record

            // Verify record creation:
            IWebElement check_name = driver.FindElement(By.XPath("//*[text()='Random_name_of_student_shift']"));
            Assert.IsTrue(check_name.Displayed);

            int exist_hours_from = driver.FindElements(By.XPath("//*[text()='06:00']")).Count;
            Assert.IsFalse(exist_hours_from == 0);

            int exist_hours_to = driver.FindElements(By.XPath("//*[text()='18:00']")).Count;
            Assert.IsFalse(exist_hours_to == 0);

            int exist_duration = driver.FindElements(By.XPath("//*[text()='12.00']")).Count;
            Assert.IsFalse(exist_duration == 0);

            // Delete the record:
            IWebElement element_to_delete = driver.FindElement(By.XPath("//td[@class='left']/a[text()='Random_name_of_student_shift']"));
            IWebElement row = element_to_delete.FindElement(By.XPath("./../.."));
            row.FindElement(By.XPath("td[1]/input")).Click();
            var delete = new NewRecordPageObject(driver);
            delete.DeleteRecord();

            // Verify record deleting:
            Assert.IsTrue((driver.FindElements(By.XPath("//*[text()='Random_name_of_student_shift']")).Count) == 0);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}


