using AccountsManager.Types;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsManager.Models
{
    public abstract class Account
    {
        private static int currentId = 0;
        public readonly int id;
        public readonly string accountNumber;
        public IEnumerable<AccountEvent> events { get; set; }
        public String owner { get; set; }
        public double startingBalance;

        public Account(String _ownerName, string _accountNumber, double _startingBalance, IEnumerable<AccountEvent> _eventList = null)
        {
            owner = _ownerName;
            accountNumber = _accountNumber;
            startingBalance = _startingBalance;
            events = _eventList;
            id = ++currentId;
        }

        public virtual void print(bool printEvents = false)
        {
            Console.WriteLine("Number: " + accountNumber);
            Console.WriteLine("Owner: " + owner);
            if (printEvents)
            {
                foreach(AccountEvent e in events)
                {
                    e.print();
                }
            }
        }

        public static List<Account> filterOutPositiveEventsAndPrint(Account[] accounts)
        {
            var returnAccounts = new List<Account>();
            
            foreach(Account acc in accounts)
            {
                acc.events = acc.events.Where(e => e.amount < 0);
                returnAccounts.Add(acc);
            }

            returnAccounts = returnAccounts.Where(a => a.events.Count() > 0).ToList();
            
            foreach(Account acc in returnAccounts)
            {
                acc.print(true);
                Console.WriteLine("*********");
            }

            return returnAccounts;
        }

        public double getAccountBalance()
        {
            var returnBalance = startingBalance;

            foreach (AccountEvent e in events) {
                returnBalance += e.amount;
            }

            return returnBalance;
        }

        public AccountEvent.IntervalType getTimeIntervalByEventType(String _text)
        {
            var filteredEvents = events.Where(e => e.text == _text);

            //there are one or no events in this category, there is no interval
            if (filteredEvents.Count() < 2)
            {
                return AccountEvent.IntervalType.NONE;
            }

            //filter out "noise" events
            var paymentDistributions = filteredEvents.GroupBy(e => e.amount);
            paymentDistributions = paymentDistributions.Where(d => d.Count() > 2);
            List<double> nonNoiseAmounts = paymentDistributions.Select(d => d.Key).ToList();
            //there are more than 1 non noise amounts to consider, so interval can't be determined
            if (nonNoiseAmounts.Count() > 1)
            {
                return AccountEvent.IntervalType.OTHER;
            }

            //remove events that contain "noise" amounts
            filteredEvents = filteredEvents.Where(e => nonNoiseAmounts.Contains(e.amount));

            List<int> visitedDates = new List<int>();

            foreach (AccountEvent e in filteredEvents)
            {
                string year = e.date.ToString("yyyy");
                string month = e.date.ToString("MM");
                var dayOfMonth = e.date.Day;
                string halfOfMonth = "0";
                if (dayOfMonth > 15)
                {
                    halfOfMonth = "1";
                }

                int yearMonthHalfKey = Convert.ToInt32(year + month + halfOfMonth); //convert year+month+halfofmonth to int (2016050) for easy comparison
                
                //if we've already seen this date, then this payment occurs more than biweekly or at random
                if (visitedDates.Contains(yearMonthHalfKey))
                {
                    return AccountEvent.IntervalType.OTHER;
                }

                visitedDates.Add(yearMonthHalfKey);
            }

            if (visitedDates.Count() == 0)
            {
                return AccountEvent.IntervalType.OTHER;
            }
            //check to make sure there are no skips for a month between the first event and the last event
            var minKey = visitedDates.Min();
            var maxKey = visitedDates.Max();
            var monthSkipFound = false;
            var halfOfMonthSkipFound = false;
            while (minKey < maxKey)
            {
                string stringKey = minKey.ToString();
                if (Convert.ToInt16(stringKey.Substring(stringKey.Length-1)) == 2)
                {
                    minKey += 8; //jump to next next month
                    halfOfMonthSkipFound = false;
                }

                if (halfOfMonthSkipFound && Convert.ToInt16(stringKey.Substring(stringKey.Length-3,2)) == 13)
                {
                    minKey += 880; //jump to next year
                }

                if (!visitedDates.Contains(minKey))
                {
                    if (halfOfMonthSkipFound) //we've skipped a week and a month this is not monthly or biweekly
                    {
                        return AccountEvent.IntervalType.OTHER;
                    }

                    if (!halfOfMonthSkipFound)
                    {
                        halfOfMonthSkipFound = true; //we've skipped a week this is not biweekly
                    }
                }

                minKey++;
            }

            //if no half months were skipped and no months, this is biweekly
            if (!halfOfMonthSkipFound && !halfOfMonthSkipFound)
            {
                return AccountEvent.IntervalType.BIWEEKLY;
            }


            //if no months were skipped and we haven't yet determined a type, this is monthly
            if (!monthSkipFound)
            {
                return AccountEvent.IntervalType.MONTHLY;
            }
            
            return AccountEvent.IntervalType.OTHER;

        }
    }
}
