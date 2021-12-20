Feature: Get file metadata

Scenario: Get uploaded picture metadata
   Given An image is uploaded 
   When I am sending request to Dropbox
   Then Getting file metadata should be successful

