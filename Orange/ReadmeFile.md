# Selenium C# tests

#### Checking the function of adding a new record on the https://opensource-demo.orangehrmlive.com/ website 

The script should perform authorization on the website using specified creditenals:
   Username: `Admin` 
   Password: `admin123`

Implementation of the functions for performing authorization can be found in "AuthorizationPageObject.cs" file

To have the ability to use the script for any browser, we have in code: 
   ``` C#
   private IWebDriver driver;
   ```

##### Add new record:

Implementation of the functions for adding new record can be found in "NewRecordPageObject.cs" file

Steps: 
 1) Go to Admin -> Job -> Work Shifts. We use the `public void Setup()` function for this purpose.
 2) Add Shift Name: Random_name_of_student_shift. 
 3) Add Work Hours: from 06:00 to 18:00. 
 4) Add all available employees. 
 5) Save changes. 

We access elements via XPath by id. For example, with the Save Button :
``` C#
   IWebElement SaveButton = driver.FindElement(By.XPath(".//*[@id='btnSave']"));
   SaveButton.Click();
```

##### Check added record is visible on the grid.
We find our newly added record (shift names are unique).
Implementation of the functions for checking record`s existence can be found in "NewRecordPageObject.cs" file
   ``` C#
   IWebElement check_name = driver.FindElement(By.XPath("//*[text()='Random_name_of_student_shift']"));
   Assert.IsTrue(check_name.Displayed, "Title 'Random_name_of_student_shift' should be visible");
```

##### Delete the record: select your field, click the Delete button.
Implementation of the functions for deleting the record can be found in "NewRecordPageObject.cs" file
```C#
   IWebElement element_to_delete = driver.FindElement(By.XPath("//td[@class='left']/a[text()='Random_name_of_student_shift']"));
   IWebElement row = element_to_delete.FindElement(By.XPath("./../.."));
   row.FindElement(By.XPath("td[1]/input")).Click();
   var delete = new NewRecordPageObject(driver);
   delete.DeleteRecord();
   ```


##### Make sure your field is deleted.
Implementation of the functions for checking record`s removing can be found in "NewRecordPageObject.cs" file

``` C#
   Boolean exist = driver.FindElements(By.XPath("//*[text()='Random_name_of_student_shift']")).Count == 0;
   ```