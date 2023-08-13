Feature: DownloadFile

Scenario Outline: Download file
	Given I've opened "Progress Bar" page in "<browser>" browser
	When I start downloading file
	Then the downloading is completed

Examples: 
| browser |
| Chrome  |
| Edge    |
| Firefox |