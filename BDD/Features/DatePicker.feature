Feature: DatePicker

Scenario Outline: Pick a date
	Given I've opened "Date Picker" page in "<browser>" browser
	When I open the calendar
	And choose a date
	Then the date is displayed

Examples: 
| browser |
| Chrome  |
| Edge    |
| Firefox |