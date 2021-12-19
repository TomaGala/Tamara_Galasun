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
            // ���������� �� ���������� �� ���� OrangeHRM ��� �����������
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
            driver.Manage().Window.Maximize();

            // ��������� ����������� (�������� ���� �� ������)
            var authorization = new AuthorizationPageObject(driver);
            authorization.Login("Admin");
            authorization.Password("admin123");
            authorization.LoginClick();

            // ���������� �� ���������� �� ������� ������ ���� (Admin -> Job -> Work Shifts) 
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/index.php/admin/workShift");
        }

        [Test(Description = "Create and Delete New Record")]
        [AllureTag("SeleniumHomeTask")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureIssue("8911")]
        [AllureTms("532")]

        public void Test()
        {
            // ��������� ����� �����:
            var new_record = new NewRecordPageObject(driver);
            new_record.AddNewRecord(); // ������ ��������� ������ ������
            new_record.ShiftName("Random_name_of_student_shift"); // ����� ����� ����
            new_record.WorkHours_from("06:00"); // ������������ ������� �������� ���
            new_record.WorkHours_to("18:00"); // ������������ ��������� �������� ���
            new_record.AddEmployees(); // ��������� ������� ��������
            new_record.SaveRecord(); // ������ ���������� ������ ������

            // �������� ��������� ������:
            IWebElement check_name = driver.FindElement(By.XPath("//*[text()='Random_name_of_student_shift']"));
            Assert.IsTrue(check_name.Displayed);

            IWebElement check_hours_from = driver.FindElement(By.XPath("//*[text()='06:00']"));
            bool status_from = check_hours_from.Displayed;

            IWebElement check_hours_to = driver.FindElement(By.XPath("//*[text()='18:00']"));
            bool status_to = check_hours_to.Displayed;

            IWebElement check_HoursPerDay = driver.FindElement(By.XPath("//*[text()='12.00']"));
            bool status_duration = check_HoursPerDay.Displayed;

            // ��������� ������:
            IWebElement element_to_delete = driver.FindElement(By.XPath("//td[@class='left']/a[text()='Random_name_of_student_shift']"));
            IWebElement row = element_to_delete.FindElement(By.XPath("./../.."));
            row.FindElement(By.XPath("td[1]/input")).Click();
            var delete = new NewRecordPageObject(driver);
            delete.DeleteRecord();

            // �������� ���������:
            Boolean exist = driver.FindElements(By.XPath("//*[text()='Random_name_of_student_shift']")).Count == 0;
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}


