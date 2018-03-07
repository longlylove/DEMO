@doNotRunThis
Feature: BuyBooksFromBookDepository
	As a bookworm
	I need to get book from book depo

Background:
	Given I am on the bookdepository homepage

Scenario: Search book by title
	Given the search bar is available
	When I enter the book title and search
		Then the book is displayed as search result

Scenario: Add book to basket
	Given I added a book to my basket
		Then I can see the item-added notfication
	When I choose to go to checkout
		Then I can see my basket 
		And I can see the added item, its price and the total 




