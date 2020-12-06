Feature: QuickView Button Feature In order to test if quick view redirects to the correct product
As a developer
I want to ensure functionality is working end to end
@mytag
Scenario: Quick View button should redirect to the page of the product it belongs to, where the product details will be shown
Given I have navigated to mens or womens wear page
And I have hovered over one of the products displayed on the page
When I press the quick view button that pops up
Then I should be redirected to that product's page