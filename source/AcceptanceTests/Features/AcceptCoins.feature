Feature: Accept Coins
	As a vendor
	I want a vending machine that accepts coins
	So that I can collect money from the customer

Background: 
	Given a vending machine

Scenario: No Coins Inserted
	Then the display should say INSERT COIN

Scenario Outline: Valid coins are inserted
	When I insert <Coins>
	Then the display should say <Display>
Examples: 
| Coins                 | Display |
| Quarter               | $0.25   |
| Dime                  | $0.10   |
| Nickel                | $0.05   |
| Quarter, Dime, Nickel | $0.40   |

Scenario Outline: Pennies are returned
	When I insert <Coins>
	Then <ReturnedCoins> are returned
	And the display should say <Display>
Examples: 
| Coins          | ReturnedCoins | Display     |
| Penny          | Penny         | INSERT COIN |
| Quarter, Penny | Penny         | $0.25       |
| Dime, Penny    | Penny         | $0.10       |
| Nickel, Penny  | Penny         | $0.05       |