Feature: SubmitData

Scenario: Submitting the data
	Given I've opened "Sample Page Test" page
	When I fill all fields
	And click Submit button
	Then the correct information is displayed