using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsManager.Types
{
    public class CreditCardEvent : AccountEvent
    {
        private readonly String[] CreditCardValidEventTypes = new String[]
        {
            "Credit Card Transaction"
        };

        private string valid_type;
        private String type {
            get { return valid_type; }
            set {
                if (!CreditCardValidEventTypes.Contains(value)){
                    throw new ArgumentException(value + " is not a valid credit card event");
                }

                valid_type = value;

            }
        }

        public CreditCardEvent(DateTime _date, String _text, Double _amount, String _type)
            : base(_date, _text, _amount)
        {
            type = _type;
        }

        public override void print()
        {
            base.print();
            Console.WriteLine("type: " + type);
        }

    }
}
