# My-Bank-Accounts-model-

## Introduction
The project build up with object oriented language C#. Using 
library to write unit tests. We work with a lot of bank information. To give you a sense of how that is we want you to create models for that kind of data. On the next page you will find some example data of a
bank account and a credit card. A bank account contains events of types transactions and
payments. Payments have a recipient number while transactions don’t. Credit cards only
consist of credit card transactions. When you create the models have in mind that they should
be extendable with other types of accounts and transactions.

## Features: 
#### 1. Implement a model to represent the bank data.
##### a. Model a credit card and its credit card transactions.
##### b. Model a bank account and its bank events.
#### 2. Create a function that given several bank accounts with their bank events as input,
removes all bank account transactions with a positive amount and outputs only the
bank accounts that still have at least one event, also return the remaining events in the
output.
##### a. Create at least one-unit test for this.
#### 3. Create a function that calculates the balance of a bank account or credit card.
##### a. Create at least one-unit test for this.
#### 4. Build a function to detect the time interval between subsequent bank events for a
specific group (by text). You should be able to detect monthly and biweekly (every
other week) intervals and represent that with appropriate data types.
##### a. Create a unit test with the example bank account and detect that
“Video streaming” occurs monthly.
##### b. Create a unit test with the example bank account and detect that “Gym” occurs
biweekly. The transaction at 2016-06-28 should be considered as noise.

## Example data
### Bank accounts Model 
#### Number: 10201
##### Owner: Kaes
| Date  | Text | Bank eventn type | Recipient number | Amount |
| --- | --- | --- | --- | --- |
| 2016-08-01 | Gym | Payment | 123-456 | -200| 
| 2016-07-23 | Video streaming | Transaction | -99 |  |
| 2016-07-18 | Gym | Payment | 123-456 | -200 | 
| 2016-07-04 | Gym | Payment | 123-456 | -200 | 
| 2016-06-28 | Gym | Payment | 123-456 | -50 | 
| 2015-06-25 | Salary | Transaction | 1337 |  | 
| 2016-06-22 | Video streaming | Transaction | -99 | | 
| 2016-06-20 | Gym | Payment | 123-456 | -200 |
| 2016-05-23 | Video streaming | Transaction | -99 | | 

### Credit card
#### Number: ****-****-****-1234
##### Name on card: Kaes
| Date  | Text | Bank eventn type | Amount |
| --- | --- | --- | --- |
| 2016-08-01 | Pizza | Credit card transaction | 123-456 | 70 | 
| 2016-07-25 | Bar | Credit card transaction | 120 |
| 2016-07-20 | Grocery store | Credit card transaction | 99 |


### My Bank Accounts Model Project Implementation –  Step by step
1)	First I set up a visual studio solution (Accounts.sln) and added projects for unit testing (Accounts_UnitTests) and the Accounts Implementation functions (AccountsManager)

2)	For unit tests, I used the RED-GREEN-REFACTOR strategy.

3)	In my unit tests class, I have an overarching parent test class for the whole project. Inside of that class are sub test classes for each function to be tested.

4)	I started by writing unit tests to meet requirements for the filterOutPositiveEventsAndPrint function.

5)	The first test for this function is Should_Return_List_Of_Accounts, a check to make sure the function returns a list of Accounts. Given the test data that I created, this function should always return a list with at least one account. This test was in a failing state on creation (RED) because I had no implementation for Accounts yet.

6)	Next I created the Accounts model class. This is a base class that the BankAccount and CreditClass models inherit from.

7)	I implement the properties and functions here that will be used in every account type. This includes the owner,accountNumber,startingBalance, id, and a list of events.

8)	I also created a virtual print function in the Account class that prints out all of the details of the account to the console. This function can be overriden in derived classes.

9)	Next I created the AccountEvent base class. This is the class that represents each of the transactions that take place on an account. The AccountEvent class has date,text,amount, and id properties and a print function.

10)	I then created the BankAccountEvent class, which derives from AccountEvent. The only difference here is that BankAccountEvent has type and optional recipientNumber properties. I implemented code in the setter for type to ensure that it was included in the BankAccountValidTypes list (“Transaction” and “Payment” are valid).

11)	The print function for BankAccountEvent just adds type and recipientNumber to the output.

12)	Then I created the CreditCardAccountEvent class, which also derives from AccountEvent. This class has a type (also with a custom setter to ensure that type is valid), and overrides the print function to include the type.

13)	Next I created the BankAccount class, which is derived from Account. No difference here except that it prints “BANK ACCOUNT” before calling the generic print function from Account.

14)	Then I created the CreditCardAccount class, deriving from Account. The print function for this class masks the account number with * and puts dashes after every four chars.

15)	Once all the models and associated types were created, I started working to move the Should_Return_List_Of_Accounts into a passing (GREEN) state.

16)	I created the filterOutPositiveEventsAndPrint function in the Account class which got rid of a few errors, but still failing.

17)	I then created some test data to run all the test on. I stored this in the Accounts_TestData project and a const list of accounts.

18)	Initially I had the function return all of the test accounts, which satisified the condition of return a list of accounts, so the test moved into GREEN state. So now, I needed to make sure that any changes did not cause the test to fail in the future.

19)	I then created a unit test to assert that the function actually removes all positive events, so I wrote the Should_Filter_Out_Positive_Events function which makes sure all returned events have an amount > 0. This test was now failing because my test data has positive values and the filter function isn’t actually removing anything.

20)	I also created a test to make sure that any accounts who had all events filtered were removed. This is the Should_Remove_Accounts_With_No_Events test method. 

21)	So then I needed to move Should_Filter_Out_Positive_Events test to the GREEN state, so I fleshed out the details of the filterOutPositiveEventsAndPrints function. This function uses C#’s LINQ functions to first remove any events that have an amount >= 0 and then remove accounts that have less than zero transactions (after filtering). This moved the Should_Filter_Out_Positive_Events test and the Should_Remove_Accounts_With_No_Events tests to the passing state.

22)	Next I moved on to the implementation of the account balance function, getAccountBalance

23)	First, I created a unit test, Should_Return_The_Account_Balance which makes sure that this function behaves as expected. This test was now in RED state because the getAccountBalance function had not been implemented.

24)	Then I worked to get the Should_Return_The_Account_Balance test into the passing state.

25)	I implemented getAccountBalance in the base Account class which simply adds all transaction amounts to the startingBalance.

26)	The Should_Return_The_Account_Balance test was now in the GREEN state.

27)	Next, I created unit tests to ensure that the getTimeIntervalByEventType function was working properly. These tests are called Should_Detect_BiWeekly_Events and Should_Detect_Monthly Events. Both tests started in the RED phase of the unit testing process.

28)	I also added a class that stores an enum of the possible time interval values.

29)	The values I created were MONTHLY, BIWEEKLY, OTHER (meaning there is only one item or there is no pattern of time intervals), or NONE  

30)	I then implemented getTimeIntervalByEventType function details.

31)	getTimeIntervalByEventType first gets a list of only the events that have text that matches the passed in text value string.

32)	Then this function filters “noise” events by removing any transactions with amounts that only occur once.

33)	The function then loops through the events and checks for skips in months and halves of months.

34)	If no skips in month are found, but skips in halves of months are found – it returns MONTHLY

35)	If no skips are found in months or halves of months, then it returns BIWEEKLY

36)	If it can’t determine a pattern it returns OTHER

37)	If 1 or 0 events occurred it returns NONE, because there aren’t enough events to find a pattern

38)	Should_Detect_BiWeekly_Events and Should_Detect_Monthly_Events both are now passing.

39)	Finally, I created an example executable program to demonstrate the use of some of the functions in the app.


#### Creating out first unite test 
	Add a unite test project to your solution 

	Decorate the class that contains test methods with testclass attribute.

	Decorate the test method with testMethod attribute.
The AAA (arrange, act, assert) pattern is a common way of writing unit tests.

	Arrange: initializes objects and sets the value of the data that is passed to the method being tested.

	Act: Invokes the method being tested

	Asset: verifies that the method being tested behaves as expected 

## Version
#### 	My Bank Accounts Model: 2.0.1
## Current Version
#### My Bank Accounts Model: 2.0.1 ###Release date Version 2.0.1 -- 12th May, 2017
## License
### MIT
## Author
### Lotfar kaes
