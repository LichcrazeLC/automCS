Feature: Search Feature In order to test if search bar actually works, returns search results
As a developer
I want to ensure search functionality is working properly
@mytag
Scenario: Search button should redirect to the page with search results based on what was entered in the search bar
Given I have navigated to home page
And I have entered Leather as a keyword I want to search for
When I press the search button next to the search bar
Then I should be redirected to a page with my search results