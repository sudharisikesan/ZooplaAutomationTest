# ZooplaAutomationTest
ZooplaAutomationTest

1) Register for daily email updates on rental property in London for 1 bed properties between £800 and £1000 per month
Here, In this Scenario 
When the user completed registration for email updates on rental properties, the default frequency is set to 'Instant Property Alerts' which I have changed to 'Daily email' which will handle scenario number 2 validation as well.
Considering the time, I am adopting this approacn on the basis of risk factor and hereby verifying both the cases in scenario #1
2) Change the frequency of an existing email update
Linked to Scenario#1 due to time constraints.
3) Search for a particular property in the house prices search and confirm that it appears as the first result
Feature: SearchProperty (this contains scenarios for #3, #4 and #5)
4) Search houses for sale including the key word “garage” and check that results have garages
Feature: SearchProperty
5) Save a search for property within 15 minutes drive of SE1 2LH.
Feature: SearchProperty
6) Check that saved searches can be retrieved
Feature: SearchProperty

Bug Identified:
During Exploratory testing, I spotted the below bug:
Scenario:
The drop down key ('v') on "Advanced search options" is not clickable as the link is applied only to the text.
Steps:
Go to any of the property search eg: For sale
Click on the drop down arrow next to "Advanced search options" 
Actual: Clicking on the drop down is not responsive
User might end up clicking on the drop down arrow  to access the Advanced search options and will be not responsible in this use case.
Expected: The entire link should be clickable (or) it is better to remove the drop down arrow symbol next to the text.
This might not be captured in our automation test if we inspect the location of element of "Advanced search options" and not the drop down arrow.

Things to Do:
1) Will have to adpot reporting within this framework to capture screenshots during assertions in case of failing scenarios
2) Definitely test the result of searches( I have not covered this functionality in this test as it was not mentioned in the tasks)
3) Analyse more on reducing the Thread.Sleep();
