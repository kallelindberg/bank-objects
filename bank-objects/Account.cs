using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_objects
{
    class Account 
    {
        private decimal _balance = 0;
        private string _entries;
        //private decimal _sum;
        //private DateTime _timestamp;
        public string AccNumb { get; set; }
        public List<Entry> entry = new List<Entry>();


        public Account()
        {
            
        }

        public decimal Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }
        public decimal GetBalance()
        {
            _balance = this.Balance;
            return _balance;
        }
        public string GetAllEntries()
        {
            _entries = "Account: " + this.AccNumb.ToString() + "\n";
            foreach (Entry aEntry in this.entry)
            {
                _entries += "Time:" + aEntry.timestamp.ToString() + " Sum:" + aEntry.sum.ToString() + "\n";
            }
            return _entries;

        }
        public string GetEntries(DateTime s, DateTime e)
        {
            _entries = "Account: " + this.AccNumb.ToString() + "\n";
            foreach (Entry aEntry in this.entry)
            {
                if (aEntry.timestamp > s && aEntry.timestamp < e)
                    _entries += "Time:" + aEntry.timestamp.ToString() + " Sum:" + aEntry.sum.ToString() + "\n";
            }
            _entries += "Balance: " + this.Balance.ToString();
            return _entries;

        }
        public void AddEntry(decimal sum, DateTime ts)
        {
            var entry = new Entry(sum, ts, this);
        }
    }
}
