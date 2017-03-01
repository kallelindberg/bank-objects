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
            var bank = new Bank("OP");
            var cst1 = new Customer("Asiakas", "Yksi");
            var cst2 = new Customer("Asiakas", "Kaksi");
            var cst3 = new Customer("Asiakas", "Kolme");
            
            var acc1 = new Account();
            cst1.AccNumb = bank.CreateAN(acc1);
            
            var acc2 = new Account();
            cst2.AccNumb = bank.CreateAN(acc2);
            
            var acc3 = new Account();
            cst3.AccNumb = bank.CreateAN(acc3);

            var entry1 = new Entry(1000, DateTime.Now, acc1);
            var entry2 = new Entry(2000, DateTime.Now, acc2);
            var entry3 = new Entry(3000, DateTime.Now, acc3);
            
            Console.WriteLine(cst1.ToString(bank));
            Console.WriteLine(cst2.ToString(bank));
            Console.WriteLine(cst3.ToString(bank));

            var date = DateTime.Now;
            for (int c = 0; c < 200; c++)
            {
                var entry = new Entry(rnd.Next(-9000, 9000), date, bank.accounts[rnd.Next(0, 3)]);
                date = date.AddHours(rnd.Next(0, 9));
            }
            Console.WriteLine(cst1.ToString(bank));
            Console.WriteLine(cst2.ToString(bank));
            Console.WriteLine(cst3.ToString(bank));

            Console.WriteLine(bank.GetAllEntries(acc1));

            Console.ReadKey();
        }
    }
}
