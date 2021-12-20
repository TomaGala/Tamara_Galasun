Feature: Upload file to Dropbox

Scenario: Upload a picture
   Given I want to upload an image "christmas.jpg" to get the path "/WebAPI/christmas.jpg"
   When I send a request to Dropbox
   Then The uploading should be successful
