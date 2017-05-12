using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AccountsManager.Models;
using System.Collections.Generic;
using AccountsManager.Types;
using Accounts_TestData;

namespace Accounts_UnitTests
{
    /*
    Test Class for the Entire AccountsManager
    */
    [TestClass]
    public class AccountsManager_Tests
    {

        private static Account[] testAccounts = TestData.AccountsList;

        /*
        Test Class for the filterPositiveEventsFunction
        */
        [TestClass]
        public class FilterOutPositiveEventsAndPrintFunction
        {
            [TestMethod]
            public void Should_Return_List_Of_Accounts()
            {
                var filteredAccounts = Account.filterOutPositiveEventsAndPrint(testAccounts);
                Assert.IsNotNull(filteredAccounts);
                Assert.IsTrue(filteredAccounts.Count > 0);
            }

            [TestMethod]
            public void Should_Filter_Out_Positive_Events()
            {
                var filteredAccounts = Account.filterOutPositiveEventsAndPrint(testAccounts);
                
                foreach(Account a in filteredAccounts)
                {
                    foreach(AccountEvent e in a.events)
                    {
                        Assert.IsTrue(e.amount < 0);
                    }
                }
            }

            [TestMethod]
            public void Should_Remove_Accounts_With_No_Events()
            {
                var filteredAccounts = Account.filterOutPositiveEventsAndPrint(testAccounts);
                foreach (Account a in filteredAccounts)
                {
                    var hasCount = false;
                    foreach (AccountEvent e in a.events)
                    {
                        hasCount = true;
                        break;
                    }
                    Assert.IsTrue(hasCount);
                }
            }
        }

        /*
        Test Class for the getAccountBalance function
        */
        [TestClass]
        public class GetAccountBalanceFunction
        {
            [TestMethod]
            public void Should_Return_The_Account_Balance()
            {
                foreach(Account testAccount in testAccounts)
                {
                    double expectedBalance = testAccount.startingBalance;
                    foreach (AccountEvent e in testAccount.events)
                    {
                        expectedBalance += e.amount;
                    }

                    double actualBalance = testAccount.getAccountBalance();
                    Assert.AreEqual(expectedBalance, actualBalance);
                }
            }
        }

        /*
            Test Class for the getTimeIntervalByEventType function
        */
        [TestClass]
        public class GetTimeIntervalByEventTypeFunction
        {
            [TestMethod]
            public void Should_Detect_Monthly_Events()
            {
                var testAccount = testAccounts[0];
                var intervalType = testAccount.getTimeIntervalByEventType("Video Streaming");
                Assert.AreEqual(AccountEvent.IntervalType.MONTHLY, intervalType);
            }

            [TestMethod]
            public void Should_Detect_BiWeekly_Events()
            {
                var testAccount = testAccounts[0];
                var intervalType = testAccount.getTimeIntervalByEventType("Gym");
                Assert.AreEqual(AccountEvent.IntervalType.BIWEEKLY,intervalType);
            }
        }
    }
}
