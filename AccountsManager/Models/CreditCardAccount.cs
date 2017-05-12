using AccountsManager.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsManager.Models
{
    public class CreditCardAccount : Account
    {
        public CreditCardAccount(String ownerName, string accountNumber, double startingBalance, List<CreditCardEvent>eventList = null) : base(ownerName, accountNumber, startingBalance, eventList) { }
        public override void print(bool printEvents = false)
        {
            var maskedAccountNumber = "";
            for (var i = 0; i < accountNumber.Length; i++)
            {
                if (i < accountNumber.Length - 4)
                {
                    if (i == 3 || i == 7 || i == 11)
                    {
                        maskedAccountNumber += "*-";
                    }
                    else
                    {
                        maskedAccountNumber += "*";
                    }
                }
                else
                {
                    maskedAccountNumber += accountNumber[i];
                }
            }
            Console.WriteLine("CREDIT CARD");
            Console.WriteLine("Number: " + maskedAccountNumber);
            Console.WriteLine("Name On Card: " + owner);

            if (printEvents)
            {
                foreach (AccountEvent e in events)
                {
                    e.print();
                }
            }
        }
    }
}
