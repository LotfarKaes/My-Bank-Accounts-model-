using AccountsManager.Models;
using AccountsManager.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts_TestData
{
    public class TestData
    {
        private static List<BankAccountEvent> mixedBankAccountEvents = new List<BankAccountEvent>()
        {
            new BankAccountEvent(new DateTime(2016,8,1), "Gym", -200.00, "Payment", "123-456"),
            new BankAccountEvent(new DateTime(2016,7,23), "Video Streaming", -99.00, "Transaction"),
            new BankAccountEvent(new DateTime(2016,7,18), "Gym", -200.00, "Payment", "123-456"),
            new BankAccountEvent(new DateTime(2016,7,4), "Gym", -200.00, "Payment", "123-456"),
            new BankAccountEvent(new DateTime(2016,6,28), "Gym", -50, "Payment", "123-456"),
            new BankAccountEvent(new DateTime(2016,6,25), "Salary", -200.00, "Transaction"),
            new BankAccountEvent(new DateTime(2016,6,22), "Video Streaming", -99, "Transaction"),
            new BankAccountEvent(new DateTime(2016,6,20), "Gym", -200.00, "Payment", "123-456"),
            new BankAccountEvent(new DateTime(2016,5,23), "Video Streaming", -99, "Payment", "123-456")
        };

        private static List<BankAccountEvent> allPositiveBankAccountEvents = new List<BankAccountEvent>()
        {
            new BankAccountEvent(new DateTime(2016,4,1), "Salary", 200.00, "Transaction"),
            new BankAccountEvent(new DateTime(2016,5,1), "Salary", 99.00, "Transaction"),
            new BankAccountEvent(new DateTime(2016,5,13), "Deposit", 15.00, "Transaction"),
            new BankAccountEvent(new DateTime(2016,6,1), "Salary", 27.00, "Transaction")
        };

        private static List<CreditCardEvent> mixedCreditCardEvents = new List<CreditCardEvent>()
        {
            new CreditCardEvent(new DateTime(2016,2,1),"Clothes",150.00,"Credit Card Transaction"),
            new CreditCardEvent(new DateTime(2016,3,4),"Credit Card Payment", -100.00, "Credit Card Transaction"),
            new CreditCardEvent(new DateTime(2015,12,13), "Gifts", 200.00, "Credit Card Transaction"),
            new CreditCardEvent(new DateTime(2015,11,15), "Gifts", 50.00, "Credit Card Transaction"),
            new CreditCardEvent(new DateTime(2016,1,4), "Credit Card Payment", -150.00, "Credit Card Transaction")
        };

        private static List<CreditCardEvent> allPositiveCreditCardEvents = new List<CreditCardEvent>()
        {
            new CreditCardEvent(new DateTime(2016,3,2),"Credit Card Payment", -180.00,"Credit Card Transaction"),
            new CreditCardEvent(new DateTime(2015,11,23), "Cash Back", -20.00, "Credit Card Transaction"),
            new CreditCardEvent(new DateTime(2015,11,10), "Credit Card Payment", -55.00, "Credit Card Transaction")
        };

        public static readonly Account[] AccountsList = new Account[]
        {
            new BankAccount("kaes","10201",25.00, mixedBankAccountEvents),
            new BankAccount("Larry Johnson","10202", 15.00,allPositiveBankAccountEvents),
            new CreditCardAccount("Sally Jones", "1234567899991234", 195.50, mixedCreditCardEvents),
            new CreditCardAccount("Markus Colston","7777888844441234", 12.15,allPositiveCreditCardEvents)
        };
    }
}
