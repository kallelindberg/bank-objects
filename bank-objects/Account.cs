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
        public string AccNumb { get; set; }
        public List<Entry> entry = new List<Entry>();

        //call for the bank to create an account number for the given customer
        public Account(Customer c, Bank b)
        {
            c.AccNumb = b.CreateAN(this);
        }

        public decimal Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }

        //Get balance from this account
        public decimal GetBalance()
        {
            _balance = this.Balance;
            return _balance;
        }

        //Get all entries from this account
        public string GetAllEntries()
        {
            _entries = "Account: " + this.AccNumb.ToString() + "\n";
            foreach (Entry aEntry in this.entry)
            {
                _entries += "Time:" + aEntry.timestamp.ToString() + " Sum:" + aEntry.sum.ToString() + "\n";
            }
            return _entries;

        }

        //Get entries limited with timestapms from this account
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
        //Add an Entry to this account
        public void AddEntry(decimal sum, DateTime ts)
        {
            var entry = new Entry(this, sum, ts);
        }
    }
}
