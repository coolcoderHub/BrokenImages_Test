Feature: UploadFile
	Simple file upload test

@mytag
Scenario: Upload a file to a webpage
	Given Open given upload link
	When Select your file for upload
	Then Upload file to page