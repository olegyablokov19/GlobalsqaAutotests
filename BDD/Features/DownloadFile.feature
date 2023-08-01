Feature: DownloadFile

Scenario: Download file
	Given I've opened "Progress Bar" page
	When I start downloading file
	Then the downloading is completed