# TESTS
Use `Visual Studio` 
Download `SpecFlow`

#### Run tests 
1. Via Test Explorer
2. Download project files in one folder. Enter `cmd` in the address bar of the folder where all the necessary files are located. In the terminal window that appears, enter `dotnet test`.

### Folders in project
1. `Builders` folder contains classes, implementation of the Builder pattern 
2. `Features` folder contains feature files with scenarios and their implementation in code.

### Allure
In `PowerShell` terminal enter `allure serve "PATH"`, where PATH is the path to the project folder named `Allure Results`. Then you will see test report in the project folder named `Allure Reports`.

