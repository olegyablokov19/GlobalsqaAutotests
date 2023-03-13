Feature: DatePicker
	Picking a date in the calendar

@mytag
Scenario: Pick a date
	Given I've opened "Date Picker" page
	When I open the calendar
	And choose a date
	Then the date is displayed