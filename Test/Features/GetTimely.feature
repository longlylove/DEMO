@runThis
Feature: GetTimely
	> sign up
	> login

Background:
	Given I am on GetTimely homepage

Scenario: Signing Up
	Given I fill in an email address
	When I press the 'Try Timely Free' button
	Then the sign up page is displayed showing 'Start your free 14-day trial'
	
Scenario: Log in
	Given I click on the Login link
	And the the login page is displayed
	When I fill in the login credentials
	And I press 'Log In'
	Then my calendar page is displayed
