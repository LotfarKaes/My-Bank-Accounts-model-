using AccountsManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsManager.Types
{
    public class BankAccountEvent : AccountEvent
    {
        private readonly String[] BankAccountValidEventTypes = new String[]{
            "Transaction",
            "Payment"
        };

        private String recipientNumber { get; set; }
        private String valid_type { get; set; }
        private String type
        {
            get { return valid_type; }
            set
            {
                if (!BankAccountValidEventTypes.Contains(value))
                {
                    throw new ArgumentException(value + " is not a valid bank account event");
                }
            }
        }

        public BankAccountEvent(DateTime _date, String _text, Double _amount, String _type, String _recipientNumber = null)
            : base(_date, _text, _amount)
        {
            type = _type;
            recipientNumber = _recipientNumber;
        }

        public override void print()
        {
            base.print();
            Console.WriteLine("type: " + type);
            Console.WriteLine("recipientNumber: " + recipientNumber);
        }
    }
}
