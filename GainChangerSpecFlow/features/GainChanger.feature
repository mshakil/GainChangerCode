Feature: Scrape all the H1, H2 and H3 Tag from GainChanger First Blog

A short summary of the feature

@tag1

Scenario: Login To Application

	Given Navigate to gainchanger login page

	When User entered user name "username"

	And User entered password "password"

	And Click on Login button

	Then Gainchanger Website should be logged In

	When User navigate to resouces page

	And Click on first blog

	Then Scrape all the required tags

	And Save tags on JSON

	Then Close Browser
