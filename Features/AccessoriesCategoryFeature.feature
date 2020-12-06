Feature: Accessories Category Feature In order to test if products get filtered by accessories category for Men
As a developer
I want to ensure accessory filtering functionality is working properly
@mytag
Scenario: Accessories button should sort and show only the products belonging to the accessories category
Given I have navigated to site index page
And I have clicked on Mens wear 
When I press the accessories button on the pop-up window 
Then I should be now shown only products belonging to the accessories category