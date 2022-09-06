Feature: AddProductToBasket
	Find first product in page and add to basket

@mytag
Scenario: Add a Product To Basket
	Given open web page
	When find first product in page
	Then add product to basket