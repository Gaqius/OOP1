using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U5_23
{
    class Program
    {
        const string CFd1 = "RingData1.txt";
        const string CFd2 = "RingData2.txt";
        const string CFd3 = "RingData3.txt";
        const string csv1 = "Visur.csv";
        const string csv2 = "300.csv";
        static void Main(string[] args)
        {
            JuwelryContainer container = InOutUtils.Read(CFd1);
            JuwelryContainer container1 = InOutUtils.Read(CFd2);
            JuwelryContainer container2 = InOutUtils.Read(CFd3);
            JuwelryRegister register = new JuwelryRegister(container,container1,container2);

            Console.WriteLine("Sunkiausi papuošalai iš kiekvienos parduotuvės: ");
            InOutUtils.PrintData(register.FindHeaviest());

            Console.WriteLine("Aukščiausios prabos žiedų kiekis kiekvienoje parduotuvėje:");
            InOutUtils.PrintData(register.FindHighestCarat());

            InOutUtils.PrintToFile(csv1 ,register.FilteredBySame());

            JuwelryContainer filtered = register.FilterByMaxPrice(300);
            filtered.Sort(new JuwlertyComparatorByManufacturer());
            InOutUtils.PrintToFile(csv2, filtered);
        }
    }
}
