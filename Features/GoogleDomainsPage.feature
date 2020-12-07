Feature: Google page opens if entering .co.in domain in the URL box
As a developer
I want to ensure the site loads properly
@mytag
Scenario: Google page should open as normal
Given I have accessed google by entering https://www.google.co.in in the URL box
Then the google page should display properly