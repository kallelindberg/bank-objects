using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_objects
{
    class Customer
    {
        private string _firstname, _surname;
        private string _accnumb;
        private decimal _balance;
        private List<Account> _account = new List<Account>();
        public Customer(string f, string s)
        {
            _firstname = f;
            _surname = s;

        }
        public string Firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }
        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }
        public string AccNumb
        {
            get { return _accnumb; }
            set { _accnumb = value; }
        }

        //Get account balance of the customer
        public string ToString(Bank b)
        {
            
            _balance = b.accounts.Find(x => x.AccNumb ==_accnumb).Balance;
            return "Customer: " + Firstname + " " + Surname + "\n Account: " + _accnumb + " Balance: " + _balance ;
        }
    }
}
