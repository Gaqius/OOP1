using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U3_23
{
    class Program
    {
        const string CFd1 = "RingData.txt";
        const string CFd2 = "RingData2.txt";
        const string csv1 = "Žiedai.csv";
        const string csv2 = "Visur.csv";
        static void Main(string[] args)
        {
            RingsContainer container1 = InOutUtils.Read(CFd1);
            RingsContainer container2 = InOutUtils.Read(CFd2);

            RingRegister merged = new RingRegister(container1, container2);
            Console.WriteLine("Brangiausi(as) auksinis/iai žiedas/ai");
            InOutUtils.PrintData(merged.FindMostExpensiveGold());
            
            Console.WriteLine("Iš viso aukščiausios prabos žiedų kiekis:");
            Console.WriteLine(merged.FindHighestCaratCount());

            RingsContainer filteredSame = merged.FilteredBySame();
            InOutUtils.PrintToFile(csv2, filteredSame);

            RingsContainer filtered = merged.FilteredBySize();
            InOutUtils.PrintToFile(csv1, filtered);
        }
    }
}
