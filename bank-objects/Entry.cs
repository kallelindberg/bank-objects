using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_objects
{
    class Entry
    {
        private decimal _sum; 
        private DateTime _timestamp;

        //Create an Entry, with target Account, sum and a timestamp
        public Entry(Account a, decimal sum, DateTime ts)
            {
            _sum = sum;
            _timestamp = ts;
            a.Balance = a.Balance + sum;
            a.entry.Add(this);
            }
        public decimal sum
        {
            get { return _sum ; }
            
        }
        public DateTime timestamp
        {
            get { return _timestamp; }
           
        }
    }
}
