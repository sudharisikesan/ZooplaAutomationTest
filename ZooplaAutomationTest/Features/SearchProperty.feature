Feature: SearchProperty
	This feature will verify if the user if able to search of a particular property
	This feature will verify if the user is able to save search of a particular property
	//Save a search for property within 15 minutes drive of SE1 2LH.
	//Check that saved searches can be retrieved
	//Search for a particular property in the house prices search and confirm that it appears as the first result
	//Search houses for sale including the key word “garage” and check that results have garages
	
@ClearAlert
Scenario: SearchPropertyAndSave
	Given User is on Zoopla Dashboard
	And User is successfully signed into Zoopla account
	And User goes to For sale properties page
	And User Enters postcode as "SE1 2LH"
	And User Inputs in the advanved keyword search "15 minutes drive"
	And User submits the data to search for properties
	When User saves the search
	And User navigates to AlertAndSearches from My Zoopla
	Then User should be able to see the recently saved search

Scenario: SearchPropertyInHousePrice
	Given User is on Zoopla Dashboard
	And User is successfully signed into Zoopla account
	When User navigates to House Price page
	And User Enters House postcode "SE1 2LH"
	And User submits data to search for properties within that postcode
	Then User should be able to see the result of search matching the input postcode

Scenario: SearchPropertyForSale
	Given User is on Zoopla Dashboard
	And User goes to For sale properties page
	When User Enters postcode "London"
	And User Inputs in the advanved keyword search "garage"
	And User submits the data to search for properties
	Then User should see search results with garage


	