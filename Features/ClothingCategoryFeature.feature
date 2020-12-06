Feature: Clothing Category Feature In order to test if products get filtered by clothing category
As a developer
I want to ensure clothing filtering functionality is working properly
@mytag
Scenario: Clothing button should sort and show only the products belonging to the clothes category
Given I have navigated to site home page
And I have clicked on Mens wear or Womens wear 
When I press the clothing button on the pop-up window 
Then I should be now shown only products belonging to the clothes category