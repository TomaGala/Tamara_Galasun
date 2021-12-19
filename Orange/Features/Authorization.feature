Feature: Authorization on OrangeHRM site

  Verification on the field "Username".
  Verification on the field "Password".
   
   Scenario: Successful authorization on OrangeHRM site after entering all required data
	Given I am on the OrangeHRM's site page where the LOGIN Panel is
      When I enter "Admin" as a Username
      And I enter "admin123" as a Password
      And I click Login button on the LOGIN Panel
    Then the url should be <https://opensource-demo.orangehrmlive.com/index.php/dashboard>

   Scenario: Unsuccessful authorization on the site while trying to perform it with an invalid username 
   Given I am on the OrangeHRM's site page where the LOGIN Panel is
       When I enter "WrongUsername" as a Username
       And I enter "admin123" as a Password
       And I click Login button on the LOGIN Panel
    Then the url should stay the same <https://opensource-demo.orangehrmlive.com/>

  Scenario: Unsuccessful authorization on the site while trying to perform it with an invalid password 
    Given I am on the OrangeHRM's site page where the LOGIN Panel is
       When I enter "Admin" as a Username
       And I enter "WrongPassword" as a Password
       And I click Login button on the LOGIN Panel
    Then the url should stay the same <https://opensource-demo.orangehrmlive.com/>

   Scenario: Unsuccessful authorization on the site while trying to perform it without username 
   Given I am on the OrangeHRM's site page where the LOGIN Panel is
       When I enter "admin123" as a Password
       And I click Login button on the LOGIN Panel
    Then the url should stay the same <https://opensource-demo.orangehrmlive.com/>

  Scenario: Unsuccessful authorization on the site while trying to perform it without password 
    Given I am on the OrangeHRM's site page where the LOGIN Panel is
       When I enter "Admin" as a Username
       And I click Login button on the LOGIN Panel
    Then the url should stay the same <https://opensource-demo.orangehrmlive.com/>