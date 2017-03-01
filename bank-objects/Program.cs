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

            var bank = new Bank("OP"); //Create Bank object
            var cst1 = new Customer("Asiakas", "Yksi"); //Create customers
            var cst2 = new Customer("Asiakas", "Kaksi");
            var cst3 = new Customer("Asiakas", "Kolme");
            
            var acc1 = new Account(cst1, bank); //Create bank account
            var acc2 = new Account(cst2, bank);
            var acc3 = new Account(cst3, bank);
            

            var entry1 = new Entry(acc1, 1000, DateTime.Now);//set initial balance via entries
            var entry2 = new Entry(acc2, 2000, DateTime.Now);
            var entry3 = new Entry(acc3, 3000, DateTime.Now);
            
            for (int c = 0; c < 200; c++) //generate random bank entries
            {
                var entry = new Entry(bank.accounts[rnd.Next(0, 3)], rnd.Next(-9000, 9000), date);
                date = date.AddHours(rnd.Next(0, 9));
            }
            Console.WriteLine(cst1.ToString(bank)); //print balance for every account
            Console.WriteLine(cst2.ToString(bank));
            Console.WriteLine(cst3.ToString(bank));
            
            Console.WriteLine("\n" + bank.GetEntriesLINQ(acc2,DateTime.Now.AddDays(2), DateTime.Now.AddDays(8))); //query transactions from Account1

            Console.ReadKey();
        }
    }
}
