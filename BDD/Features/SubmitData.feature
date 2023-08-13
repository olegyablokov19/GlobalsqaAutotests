Feature: SubmitData

Scenario Outline: Submitting the data
	Given I've opened "Sample Page Test" page in "<browser>" browser
	When I fill all fields
	And click Submit button
	Then the correct information is displayed

Examples: 
| browser |
| Chrome  |
| Edge    |
| Firefox |