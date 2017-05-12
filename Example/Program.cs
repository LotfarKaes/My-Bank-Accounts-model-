using Accounts_TestData;
using AccountsManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var bankAccount1 = TestData.AccountsList[0];
            Account[] exampleAccounts = new List<Account>() { bankAccount1 }.ToArray();

            Console.WriteLine("Filtering Out Positive Values");
            Account.filterOutPositiveEventsAndPrint(exampleAccounts);

            Console.WriteLine();

            exampleAccounts = TestData.AccountsList;
            Console.WriteLine("Getting Account Balances");
            for (var i = 0; i < exampleAccounts.Length; i++)
            {
                Console.WriteLine(exampleAccounts[i].owner + ": " + exampleAccounts[i].getAccountBalance());
            }
            Console.WriteLine();

            Console.WriteLine("Getting Transaction Time Intervals for Account1 - Video Streaming");
            Console.WriteLine(bankAccount1.getTimeIntervalByEventType("Video Streaming"));
            Console.WriteLine();

            Console.WriteLine("Getting Transaction Time Intervals for Account1 - Gym");
            Console.WriteLine(bankAccount1.getTimeIntervalByEventType("Gym"));
            Console.WriteLine();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
