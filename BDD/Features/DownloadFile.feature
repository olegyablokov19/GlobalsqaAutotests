Feature: DownloadFile
	Downloading a file and waiting for progress bar to finish

@mytag
Scenario: Download file
	Given I've opened "Progress Bar" page
	When I start downloading file
	Then the downloading is completed