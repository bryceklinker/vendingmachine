Feature: Sold Out
	As a customer
	I want to be told when the item I have selected is not available
	So that I can select another item

Background: 
	Given a vending machine

Scenario Outline: Select sold out product
	Given <ProductType> is sold out
	And I have inserted <Coins>
	When I select <ProductType>
	Then the display should say SOLD OUT
	And the display should say <DisplayText>
Examples: 
| ProductType | Coins                              | DisplayText |
| Cola        | Quarter, Quarter, Quarter, Quarter | $1.00       |
| Candy       | Quarter, Quarter, Dime, Nickel     | $0.65       |
| Chips       | Quarter, Quarter                   | $0.50       |
| Cola        |                                    | INSERT COIN |
