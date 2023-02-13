Feature: https://www.globalsqa.com/demo-site/select-dropdown-menu/

@mytag
Scenario: The number of options is correct in Country dropdown
	Given I've opened the page
	When I count the number of options in Country dropdown
	Then the number of options is correct