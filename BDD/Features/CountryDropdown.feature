Feature: Country Dropdown

Scenario Outline: The number of options is correct in Country dropdown
	Given I've opened "Select Drop Down Menu" page in "<browser>" browser
	When I open the Country dropdown
	Then the number of options is correct

Examples: 
| browser |
| Chrome  |
| Edge    |
| Firefox |
