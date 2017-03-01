using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace bank_objects
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            var date = DateTime.Now;

            //Create Bank object
            var bank = new Bank("OP"); 
            
            //Create customers
            var cst1 = new Customer("Asiakas", "Yksi"); 
            var cst2 = new Customer("Asiakas", "Kaksi");
            var cst3 = new Customer("Asiakas", "Kolme");

            //Create bank account
            var acc1 = new Account(cst1, bank); 
            var acc2 = new Account(cst2, bank);
            var acc3 = new Account(cst3, bank);

            //set initial balance fo the accounts
            for (int c=0; c < 3; c++) 
            {
                var entry = new Entry(bank.accounts[c], 3000, DateTime.Now);
            }

            //generate random bank entries    
            for (int c = 0; c < 200; c++) 
            {
                var entry = new Entry(bank.accounts[rnd.Next(0, 3)], rnd.Next(-9000, 9000), date);
                date = date.AddHours(rnd.Next(0, 9));
            }

            //print balance for every account
            Console.WriteLine(cst1.ToString(bank)); 
            Console.WriteLine(cst2.ToString(bank));
            Console.WriteLine(cst3.ToString(bank));

            //query transactions from Account1
            Console.WriteLine("\n" + bank.GetEntriesLINQ(acc2,DateTime.Now.AddDays(2), DateTime.Now.AddDays(8))); 

            Console.ReadKey();
        }
    }
}
