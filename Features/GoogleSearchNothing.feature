Feature: Nothing happens when you click search when nothing is typed in on the Google page
As a developer
I want to ensure the search feature works properly
@mytag
Scenario: Nothing should occur when you click search on the Google page with nothing typed in the search box
Given I have accessed https://www.google.co.in
And I didn't enter anything in the search bar
When I press the search button
Then nothing occurs