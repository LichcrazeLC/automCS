Feature: When search keyword doesn't make any sense google proposes several Did You Mean options
As a developer
I want to ensure google suggests options when search is irrevelant
@mytag
Scenario: Did You Mean options appear when searching for mispelled or random keywords in Google
Given I accessed https://www.google.com/ncr
And I typed as;ddd in the search bar
When I press search
Then google proposes at least one Did You Mean option