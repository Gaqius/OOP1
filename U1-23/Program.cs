using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace U123
{
    class Program
    {   
        const string CFd = "RingData.txt";
        const string csv = "Metals.csv";
        const string Data = "Data.txt";
        static void Main(string[] args)
        {
            List<Ring> rings = InOutUtils.Read(CFd);
            InOutUtils.PrintData(rings, "Visi žiedai");
            InOutUtils.PrintDataToFile(rings, "Visi žiedai", Data);            
            double heaviest = TaskUtils.FindHeaviest(rings);
            List<Ring> FindMultipleHeaviest = TaskUtils.FindMultipleHeviest(rings, heaviest);
            InOutUtils.PrintData(FindMultipleHeaviest, "Sunkiausi(as) žiedas/i");
            List<Ring> HighestCarat = TaskUtils.FindHighestCarat(rings);
            InOutUtils.PrintData(HighestCarat, "Aukščiausios prabos žiedai");
            List<string> metals = TaskUtils.AllMetals(rings);
            double[] AllWeight = TaskUtils.AllWeight(rings, metals);
            InOutUtils.PrintToFile(metals, csv, AllWeight);
        }
    }
}