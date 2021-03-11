Feature: CreateEmailUpdate
	This feature will verify if the user can successfully create an email update in Zoopla
	//Register for daily email updates on rental property in London for 1 bed properties between £800 and £1000 per month
	//Change the frequency of an existing email update

@ClearAlert
Scenario: CreateDailyEmailUpdate
	Given User is on Zoopla Dashboard 
	And User is successfully signed into Zoopla account
	When User fills all required fields for property search
	And User submits the details to search for matching properties
	And User clicks on Create email alert
	Then Email alert should be successfully created for user