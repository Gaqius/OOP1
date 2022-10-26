using System;
using System.Collections.Generic;

namespace U2_23
{
    class Program
    {
        const string CFd1 = "RingData.txt";
        const string CFd2 = "RingData2.txt";
        const string csv = "Žiedai.csv";
        static void Main(string[] args)
        {
            RingRegister register1 = InOutUtils.Read(CFd1);
            RingRegister register2 = InOutUtils.Read(CFd2);            

            RingRegister merged = new RingRegister(register1, register2);
            Console.WriteLine("Iš viso aukščiausios prabos žiedų kiekis:");
            Console.WriteLine(merged.FindHighestCarat());

            Console.WriteLine("Brangiausi(as) platinos žiedas/ai");
            InOutUtils.PrintData(merged.FindMostExpensivePlatinum());

            List<Ring> filtered = merged.FilteredBySize();
            InOutUtils.PrintToFile(csv, filtered);
        }
    }
}
