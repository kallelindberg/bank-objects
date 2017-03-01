using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_objects
{
    class Bank
    {
        private string _name;
        public List<Account> accounts = new List<Account>();
        private string _entries;
        private Random rnd = new Random();
        private string _accnumb;
        private int[] numarray = new int[16];

        public Bank(string name)
        {
            _name = name;
        }
        public Bank()
        {

        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string CreateAN(Account a)
        {
            for (int c = 0; c < 13; c++)
            {
                numarray[c] = rnd.Next(0, 9);
            }
            _accnumb = "FI" + string.Join("", numarray);
            a.AccNumb = _accnumb;
            accounts.Add(a);
            return _accnumb;
        }
        public string GetAllEntries(Account a)
        {
            _entries = "Account: " + a.AccNumb.ToString() + "\n";
            foreach (Entry aEntry in a.entry)
            {
                _entries +=  "Time:" + aEntry.timestamp.ToString()+ " Sum:" + aEntry.sum.ToString() +"\n";
            }
            _entries += "Balance: " + a.Balance.ToString();
            return _entries;
           
        }
        public string GetEntries(Account a, DateTime s, DateTime e)
        {
            _entries = "Account: " + a.AccNumb.ToString() + "\n";
            foreach (Entry aEntry in a.entry)
            {
                if (aEntry.timestamp > s && aEntry.timestamp < e )
                _entries += "Time:" + aEntry.timestamp.ToString() + " Sum:" + aEntry.sum.ToString() + "\n";
            }
            _entries += "Balance: " + a.Balance.ToString();
            return _entries;

        }
        public string GetBalance(Account a)
        {
            _entries = "Balance: " + a.Balance.ToString();
            return _entries;
        }
        public void AddEntry(decimal sum, DateTime ts, Account a)
        {
            var entry = new Entry(sum, ts,a);
        }
    }
}

