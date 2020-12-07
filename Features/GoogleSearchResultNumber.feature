Feature: Make sure the search result number is correct
As a developer
I want to ensure google returns the correct number of search results per page
@mytag
Scenario: Google returns the correct number of search results per page when searching for a random keyword
Given I accessed the google home page https://www.google.com/ncr
And I searched for anything in the search bar
When I search
Then google returns the right result number