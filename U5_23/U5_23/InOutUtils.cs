using System;
using System.IO;
using System.Linq;

namespace U5_23
{
    class InOutUtils
    {
        /// <summary>
        /// Reads informations about the juwelry
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static JuwelryContainer Read(string f)
        {
            string[] Lines = File.ReadAllLines(f);
            string shopname = Lines[0];
            string address = Lines[1];
            string phone = Lines[2];

            JuwelryContainer A = new JuwelryContainer();
            for (int i = 3; i < Lines.Length; i++)
            {
                string[] Values = Lines[i].Split(';');
                string type = Values[0];
                string manufacturer = Values[1];
                string name = Values[2];
                string metal = Values[3];
                double weight = Convert.ToDouble(Values[4]);                
                double carat = Convert.ToDouble(Values[5]);
                double price = Convert.ToDouble(Values[6]);
                if (type == "Ring")
                {
                    double size = Convert.ToDouble(Values[7]);
                    Ring ring = new Ring(shopname, address, phone, manufacturer, name, metal, weight, carat, price, size);
                    A.Add(ring);
                }
                else if (type == "Earrings")
                {
                    string claspType = Values[7];
                    Earrings earrings = new Earrings(shopname, address, phone, manufacturer, name, metal, weight, carat, price, claspType);
                    A.Add(earrings);
                }
                else if (type == "Collar")
                {
                    double lenght = Convert.ToDouble(Values[7]);
                    Collar collar = new Collar(shopname, address, phone, manufacturer, name, metal, weight, carat, price, lenght);
                    A.Add(collar);
                }
            }
            return A;
        }
        /// <summary>
        /// Prints data of a register
        /// </summary>
        /// <param name="register"></param>
        public static void PrintData(JuwelryRegister register)
        {
            Console.WriteLine(new string('-', 157));
            Console.WriteLine("| {0,0} | {1,0} | {2,0} | {3,0} | {4,0} | {5,0}| {6,0} | {7,0} |", "Parduotuvės pavadinimas", "Gamintojas", "Pavadinimas", "Metalas", "Svoris", "Dydis", "Praba", "Kaina");
            Console.WriteLine(new string('-', 157));
            for (int i = 0; i < register.Count(); i++)
            {
                Console.WriteLine(register.Get(i).ToString());
            }
            Console.WriteLine(new string('-', 157));
            Console.WriteLine();
        }
        /// <summary>
        /// Prints data of a list
        /// </summary>
        /// <param name="rings"></param>
        public static void PrintData(JuwelryContainer juwelry)
        {
            Console.WriteLine(new string('-', 157));
            Console.WriteLine("| {0,0} | {1,-8} | {2,0} | {3,-12} | {4,-13} | {5,-12} | {6,0} | {7,0} | {8,0} | {9,0} | {10,0} | {11,0} |", "Parduotuvės pavadinimas", "Adresas", "Telefono Nr.", "Gamintojas", "Pavadinimas", "Metalas", "Svoris", "Praba", "Kaina", "Dydis", "Ilgis", "Užsegimo tipas");
            Console.WriteLine(new string('-', 157));
            for (int i = 0; i < juwelry.Count; i++)
            {
                Console.WriteLine(juwelry.Get(i).ToString());
            }
            Console.WriteLine(new string('-', 157));
            Console.WriteLine();
        }
        /// <summary>
        /// Deletes existing file and creates new one
        /// </summary>
        /// <param name="file"></param>
        /// <param name="container"></param>
        public static void PrintToFile(string file, JuwelryContainer container)
        {
            using (StreamWriter writer = new StreamWriter(file))
            {
                for (int i = 0; i < container.Count; i++)
                {
                    Juwelry juwelry = container.Get(i);
                    if (juwelry is Ring)
                    {
                        Ring ring = juwelry as Ring;
                        writer.WriteLine(String.Join(";", "Ring", ring.Manufacturer, ring.Name, ring.Metal, ring.Weight, ring.Carat, ring.Price, ring.Size));
                    }
                    else if (juwelry is Earrings)
                    {
                        Earrings earrings = juwelry as Earrings;
                        writer.WriteLine(String.Join(";", "Earrings", earrings.Manufacturer, earrings.Name, earrings.Metal, earrings.Weight, earrings.Carat, earrings.Price, earrings.ClaspType));
                    }
                    else if (juwelry is Collar)
                    {
                        Collar collar = juwelry as Collar;
                        writer.WriteLine(String.Join(";", "Collar", collar.Manufacturer, collar.Name, collar.Metal, collar.Weight, collar.Carat, collar.Price, collar.Length));
                    }
                }
            }
        }
    }
}
