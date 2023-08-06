Feature: Country Dropdown

Scenario: The number of options is correct in Country dropdown
	Given I've opened "Select Drop Down Menu" page
	When I open the Country dropdown
	Then the number of options is correct