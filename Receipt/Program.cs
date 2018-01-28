using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receipt
{
    class Program
    {
        static void Main(string[] args)
        {
            var receipt = new Receipt.Classes.Receipts();
            receipt.AddItem(1, "Newspaper", 1.50m);
            receipt.AddItem(1, "Milk", 3m);
            receipt.AddItem(2, "Bread", 2.50m);
            Console.Write(receipt.ToString());
            Console.ReadKey();
        }

        
    }
}
