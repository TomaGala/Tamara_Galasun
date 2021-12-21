using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace OrangeTESTS.Page_Objects
{
    class NewRecordPageObject
    {
        private IWebDriver _webDriver;
        private readonly By AddNewRecordButton = By.XPath(".//*[@id='btnAdd']");
        private readonly By ShiftNameTextbox = By.XPath(".//*[@id='workShift_name']");
        private readonly By WorkHours_from_Textbox = By.XPath(".//*[@id='workShift_workHours_from']");
        private readonly By WorkHours_to_Textbox = By.XPath(".//*[@id='workShift_workHours_to']");
        private readonly By AvailableEmployeesTextbox = By.XPath(".//*[@id='workShift_availableEmp']");
        private readonly By AddEmployeesButton = By.XPath(".//*[@id='btnAssignEmployee']");
        private readonly By SaveButton = By.XPath(".//*[@id='btnSave']");
        private readonly By DeleteButton = By.XPath(".//*[@id='btnDelete']");
        private readonly By DialogDeleteButton = By.XPath(".//*[@id='dialogDeleteBtn']");

        public NewRecordPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        // Click the Add button to create a new record
        public void AddNewRecord()
        {
            _webDriver.FindElement(AddNewRecordButton).Click();
        }

        // Filling the Shift Name text box
        public void ShiftName(string name)
        {
            _webDriver.FindElement(ShiftNameTextbox).SendKeys(name);
        }

        // Filling the Work Hours (FROM) text box
        public void WorkHours_from(string hours_from)
        {
            _webDriver.FindElement(WorkHours_from_Textbox).SendKeys(hours_from);
        }

        // Filling the Work Hours (TO) text box
        public void WorkHours_to(string hours_to)
        {
            _webDriver.FindElement(WorkHours_to_Textbox).SendKeys(hours_to);
        }

        // Click the Add button to move workers from the Available Employees column to the Assigned Employees column
        public void AddEmployees()
        {
            SelectElement select_employees = new SelectElement(_webDriver.FindElement(AvailableEmployeesTextbox));
            int count = select_employees.Options.Count;
            while (count != 0)
            {
                select_employees.SelectByIndex(0);
                _webDriver.FindElement(AddEmployeesButton).Click();
                count--;
            }
        }

        // Click the Save button
        public void SaveRecord()
        {
            _webDriver.FindElement(SaveButton).Click();
        }

        // Click the Delete button
        public void DeleteRecord()
        {
            _webDriver.FindElement(DeleteButton).Click();
            _webDriver.FindElement(DialogDeleteButton).Click();
        }
    }

}