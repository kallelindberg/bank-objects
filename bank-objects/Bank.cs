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

        //create an account number for an account
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

        //query all transactions from an Account
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

        //query transactions from an Account
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

        //query transactions from an Account with LINQ
        public string GetEntriesLINQ(Account a, DateTime s, DateTime e)
        {
            _entries = "Account: " + a.AccNumb.ToString() + "\n";
            IEnumerable<Entry> dataQuery =
                    from Entry in a.entry
                    where Entry.timestamp > s && Entry.timestamp < e
                    select Entry;

            foreach (Entry aEntry in dataQuery)
            {
                _entries += "Time:" + aEntry.timestamp.ToString() + " Sum:" + aEntry.sum.ToString() + "\n";
            }
            _entries += "Balance: " + a.Balance.ToString();
            return _entries;
        }

        //Get balance of given account
        public string GetBalance(Account a)
        {
            _entries = "Balance: " + a.Balance.ToString();
            return _entries;
        }

        //Add Entry to an Account in the bank
        public void AddEntry(Account a, decimal sum, DateTime ts)
        {
            var entry = new Entry(a, sum, ts);
        }
    }
}

