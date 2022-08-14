Feature: TC_01
	As an automation tester
	I want use simple function of Specflow

@simple_specflow
Scenario: Login with information invalid
	Given I am on LiveGuru site
	And I input username daominhdam123123@gmail.com and password 123123
	When I click Login button
	Then The error message should be display
	And I quit browser