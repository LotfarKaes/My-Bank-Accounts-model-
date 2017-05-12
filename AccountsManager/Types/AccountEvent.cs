using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsManager.Types
{
    public abstract class AccountEvent
    {
        public enum IntervalType { NONE, MONTHLY, BIWEEKLY, OTHER };

        private static int currentId = 0;
        public readonly int id;
        public DateTime date { get; set; }
        public String text { get; set; }
        public Double amount { get; set; }

        public AccountEvent(DateTime _date, String _text, Double _amount)
        {
            date = _date;
            text = _text;
            amount = _amount;
            id = ++currentId;
        }

        public virtual void print() {
            Console.WriteLine("id: " + id);
            Console.WriteLine("date: " + date.ToString());
            Console.WriteLine("text: " + text);
            Console.WriteLine("amount: " + amount);
        }
    }
}
