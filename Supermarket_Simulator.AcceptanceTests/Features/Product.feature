Feature: Product API

A short summary of the feature

@tag1
Scenario: Add a new product with details
	Given I have a new product with the following details:
	  | Name     | Price |
	  | ProductX | 30.0  |
	When I send a POST request to "/api/products" with the product details
	Then the response status code should be 201
	And the response should contain the created product details
