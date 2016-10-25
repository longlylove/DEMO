@runThis
Feature: CreateSalesTest
	As a checkout person, I can validate the system price is correct

Background: 
	Given I am on the Create Sales page

Scenario: Create a Blue Pants sale
	Given I have chosen Blue Pants to make sales
	When I press to create blue-pants sales
	Then I can see the blue-pants sales records on the sales page

Scenario: Create a Green Pants sale
	Given I have chosen Green Pants to make sales
	When I press to create green-pants sales
	Then I can see the green-pants sales records on the sales page

Scenario: Create a Red Pants sale
	Given I have chosen Red Pants to make sales
	When I press to create red-pants sales
	Then I can see the red-pants sales records on the sales page

Scenario: Create a Grey Pants sale
	Given I have chosen Grey Pants to make sales
	When I press to create grey-pants sales
	Then I can see the grey-pants sales records on the sales page
