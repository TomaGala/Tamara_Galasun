Feature: Delete file 

Scenario: Delete picture
   Given A picture is uploaded 
   When I send request to Dropbox
   Then File deleting should be successful

