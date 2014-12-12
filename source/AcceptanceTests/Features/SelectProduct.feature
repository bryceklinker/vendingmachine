Feature: Select Product
	As a vendor
	I want customers to select products
	So that I can give them an incentive to put money in the machine

Background: 
	Given a vending machine
	And vending machine has 5 Cola
	And vending machine has 5 Chips
	And vending machine has 5 Candy

Scenario Outline: Select product with exact change
	Given I have inserted <Coins>
	When I select <ProductType>
	Then the <ProductType> is dispensed
	And the display should say THANK YOU
Examples: 
| Coins                              | ProductType |
| Quarter, Quarter, Quarter, Quarter | Cola        |
| Quarter, Quarter                   | Chips       |
| Quarter, Quarter, Dime, Nickel     | Candy       |

Scenario Outline: Select product that costs more than balance
	Given I have inserted <Coins>
	When I select <ProductType>
	Then the display should say <Cost>
	And the product is not dispensed
	And the display should say <Balance>
Examples: 
| Coins           | ProductType | Cost  | Balance |
| Quarter         | Cola        | $1.00 | $0.25   |
| Quarter, Nickel | Candy       | $0.65 | $0.30   |
| Dime, Nickel    | Chips       | $0.50 | $0.15   |