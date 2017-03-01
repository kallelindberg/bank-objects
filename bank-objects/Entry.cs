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
        
        public Entry(decimal sum, DateTime ts, Account a)
            {
            _sum = sum;
            _timestamp = ts;
            a.Balance = a.Balance + sum;
            a.entry.Add(this);
            }
        public decimal sum
        {
            get { return _sum ; }
            //set { _sum = value; }
        }
        public DateTime timestamp
        {
            get { return _timestamp; }
            //set { _timestamp = value; }
        }
    }
}
