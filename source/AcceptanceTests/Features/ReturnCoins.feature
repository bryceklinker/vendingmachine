Feature: Return Coins
	As a customer
	I want to have my money returned
	So that I can change my mind about buying stuff from the vending machine

Background: 
	Given a vending machine

Scenario Outline: Return inserted coins
	Given I have inserted <Coins>
	When I press return coins
	Then <Coins> are returned
	And the display should say INSERT COIN
Examples: 
| Coins           |
| Quarter         |
| Nickel          |
| Quarter, Dime   |
| Quarter, Nickel |
