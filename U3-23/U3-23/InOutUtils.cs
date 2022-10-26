using System;
using System.Collections.Generic;
using System.IO;

namespace U3_23
{
    class InOutUtils
    {
        /// <summary>
        /// Reads informations about the rings
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static RingsContainer Read(string f)
        {
            string[] Lines = File.ReadAllLines(f);
            string shopname = Lines[0];
            string address = Lines[1];
            string phone = Lines[2];

            RingsContainer A = new RingsContainer();
            for (int i = 3; i < Lines.Length; i++)
            {
                string[] Values = Lines[i].Split(';');
                string manufacturer = Values[0];
                string ringname = Values[1];
                string metal = Values[2];
                double weight = Convert.ToDouble(Values[3]);
                double size = Convert.ToDouble(Values[4]);
                double carat = Convert.ToDouble(Values[5]);
                double price = Convert.ToDouble(Values[6]);
                Ring temp = new Ring(shopname, address, phone, manufacturer, ringname, metal, weight, size, carat, price);
                A.Add(temp);
            }
            return A;
        }
        /// <summary>
        /// Prints data of a register
        /// </summary>
        /// <param name="register"></param>
        public static void PrintData(RingRegister register)
        {
            Console.WriteLine(new string('-', 110));
            Console.WriteLine("Parduotuvės pavadinimas Gamintojas     Pavadinimas      Metalas        Svoris  Dydis   Praba     Kaina ");
            Console.WriteLine(new string('-', 110));
            for (int i = 0; i < register.Count(); i++)
            {
                Console.WriteLine(register.Get(i).ToString());
            }
            Console.WriteLine(new string('-', 110));
            Console.WriteLine();
        }
        /// <summary>
        /// Prints data of a list
        /// </summary>
        /// <param name="rings"></param>
        public static void PrintData(RingsContainer rings)
        {
            Console.WriteLine(new string('-', 110));
            Console.WriteLine("Parduotuvės pavadinimas    Gamintojas     Pavadinimas    Metalas   Svoris  Dydis   Praba     Kaina ");
            Console.WriteLine(new string('-', 110));
            for (int i = 0; i < rings.Count; i++)
            {
                Console.WriteLine(rings.Get(i).ToString());
            }
            Console.WriteLine(new string('-', 110));
            Console.WriteLine();
        }
        /// <summary>
        /// Deletes existing file and creates new one
        /// </summary>
        /// <param name="file"></param>
        /// <param name="container"></param>
        public static void PrintToFile(string file, RingsContainer container)
        {
            if (File.Exists(file))
            {
                File.Delete(file);
            }
            using (StreamWriter cin = new StreamWriter(file))
            {
                for (int i = 0; i < container.Count; i++)
                {
                    cin.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}", container.Get(i).Size, container.Get(i).Metal, container.Get(i).Carat, container.Get(i).Weight, container.Get(i).Price, container.Get(i).Shopname);

                }
            }
        }
    }
}
