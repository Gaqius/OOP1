using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace U123
{
    class InOutUtils
    {
        /// <summary>
        /// Reads the values of rings' properties
        /// </summary>
        /// <param name="f">Line</param>
        /// <returns>Information about rings</returns>
        public static List<Ring> Read(string f)
        {
            List<Ring> A = new List<Ring>();
            string[] Lines = File.ReadAllLines(f);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                string manufacturer = Values[0];
                string name = Values[1];
                string metal = Values[2];
                double weight = Convert.ToDouble(Values[3]);
                double size = Convert.ToDouble(Values[4]);
                double carat = Convert.ToDouble(Values[5]);
                double price = Convert.ToDouble(Values[6]);
                Ring temp = new Ring(manufacturer, name, metal, weight, size, carat, price);
                A.Add(temp);
            }
            return A;
        }
        /// <summary>
        /// Prints data
        /// </summary>
        /// <param name="rings">List of rings</param>
        /// <param name="Heading">The heading</param>
        public static void PrintData(List<Ring> rings, string Heading)
        {
            Console.WriteLine(Heading);
            Console.WriteLine(new string('-', 80));
            Console.WriteLine("Gamintojas     Pavadinimas      Metalas        Svoris  Dydis   Praba     Kaina ");
            Console.WriteLine(new string('-', 80));
            for (int i = 0; i < rings.Count; i++)
            {
                Console.WriteLine(rings[i].ToString());
            }
            Console.WriteLine(new string('-', 80));
            Console.WriteLine();
        }
        /// <summary>
        /// Prints data to a file
        /// </summary>
        /// <param name="rings">List of rings</param>
        /// <param name="Heading">The heading</param>
        /// <param name="file">File</param>
        public static void PrintDataToFile(List<Ring> rings, string Heading, string file)
        {
            using (StreamWriter cin = new StreamWriter(file))
            {
                cin.WriteLine(Heading);
                cin.WriteLine(new string('-', 80));
                cin.WriteLine("Gamintojas     Pavadinimas      Metalas        Svoris  Dydis   Praba     Kaina ");
                cin.WriteLine(new string('-', 80));
                for (int i = 0; i < rings.Count; i++)
                {
                    cin.WriteLine(rings[i].ToString());
                }
                cin.WriteLine(new string('-', 80));
                cin.WriteLine();
            }
        }
        /// <summary>
        /// Prints the values
        /// </summary>
        /// <param name="values">Rings' properties</param>
        public static void PrintValues(double values)
        {
            Console.WriteLine($"Sunkiausias žiedas: {values,-12}");
            Console.WriteLine();
        }
        /// <summary>
        /// Deletes existing file and creates new one
        /// </summary>
        /// <param name="metals">List of metals</param>
        /// <param name="file">File</param>
        public static void PrintToFile(List<string> metals, string file, double[] metalweight)
        {
            if (File.Exists(file))
            {
                File.Delete(file);                
            }
            using (StreamWriter cin = new StreamWriter(file))
            {
                for (int i = 0; i < metals.Count; i++)
                {
                    cin.WriteLine("{0}, {1}",metals[i], metalweight[i]);

                }
            }
        }
    }
}