using AccountsManager.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsManager.Models
{
    public class BankAccount : Account
    {
        public BankAccount(String ownerName, string accountNumber, double startingBalance, List<BankAccountEvent> eventList = null) : base(ownerName, accountNumber, startingBalance, eventList) { }
        public override void print(bool printEvents = false)
        {
            Console.WriteLine("BANK ACCOUNT");
            base.print(printEvents);
        }
    }
}
