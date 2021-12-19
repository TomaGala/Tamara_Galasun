Feature: Adding the "Random_name_of_student_shift" record in Work Shifts tab

  Filling the "Shift Name *" field. 
  Filling "Work Hours *" fields. 
  Adding "Available Employees" to the list of "Assigned Employees".
  Saving the record.

  Background: 
   Given authorization on the website is complete

 Scenario: Error message should appear while trying to add record without entering shift name 
    Given I am on the OrangeHRM's site page where the Work Shifts tab is
      And I click Add button
      When I click Save button
    Then the error message (Required) under Shift Name * field should appear

  Scenario: Successful record adding on the Work Shifts tab after entering all required data
	Given I am on the OrangeHRM's site page where the Work Shifts tab is
      And I click Add button
      And I enter "Random_name_of_student_shift" in the field Shift Name *
      And I select "06:00" in a FROM field that is in line with the Work Hours * field
      And I select "18:00" in a TO field that is in line with the Work Hours * field
      And I add all Available Employees to Assigned Employees list
      When I click Save button
    Then the record with the Random_name_of_student_shift shift name should be visible in the list of work shifts
 
 
