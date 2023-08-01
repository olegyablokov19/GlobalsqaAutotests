Feature: DatePicker

Scenario: Pick a date
	Given I've opened "Date Picker" page
	When I open the calendar
	And choose a date
	Then the date is displayed