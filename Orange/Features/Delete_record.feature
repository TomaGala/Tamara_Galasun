Feature: Deleting the "Random_name_of_student_shift" record in Work Shifts tab

 Background: 
    Given I performed authorization on the OrangeHRM's site page and the Random_name_of_student_shift record is already created
 
  Scenario: Successful record deleting
    Given I am on the OrangeHRM site page where the Work Shifts tab is
      When I check the box near the Random_name_of_student_shift record
      And I click Delete button
    Then the Random_name_of_student_shift record should not be visible in the list of work shifts    

 