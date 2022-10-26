using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace U123
{
    class TaskUtils
    {
        /// <summary>
        /// Finds the heaviest ring
        /// </summary>
        /// <param name="rings">list of rings</param>
        /// <returns>heviest ring's weight</returns>
        public static double FindHeaviest(List<Ring> rings)
        {
            double heaviest = -1;
            for (int i = 0; i < rings.Count; i++)
            {
                if (rings[i].Weight > heaviest)
                {
                    heaviest = rings[i].Weight;
                }
            }
            return heaviest;
        }
        /// <summary>
        /// If there are multiple heaviest rings, puts them in a list
        /// </summary>
        /// <param name="rings">List of the rings</param>
        /// <param name="heaviest">Heaviest rings</param>
        /// <returns>List of heaviest rings</returns>
        public static List<Ring> FindMultipleHeviest(List<Ring> rings, double heaviest)
        {
            List<Ring> MultipleHeaviest = new List<Ring>();


            for (int i = 0; i < rings.Count; i++)
            {
                if (rings[i].Weight == heaviest)
                {
                    MultipleHeaviest.Add(rings[i]);
                }
            }
            return MultipleHeaviest;
        }
        /// <summary>
        /// Finds highest carat ring
        /// </summary>
        /// <param name="rings">List of rings</param>
        /// <returns>List highest carat ring</returns>
        public static List<Ring> FindHighestCarat(List<Ring> rings)
        {
            List<Ring> HighestCarat = new List<Ring>();
            for (int i = 0; i < rings.Count; i++)
            {
                if (rings[i].Metal == "auksas")
                {
                    if (rings[i].Carat == 750)
                    {
                        HighestCarat.Add(rings[i]);
                    }
                }
                else if (rings[i].Metal == "platina")
                {
                    if (rings[i].Carat == 950)
                    {
                        HighestCarat.Add(rings[i]);
                    }
                }
                else if (rings[i].Metal == "sidabras")
                {
                    if (rings[i].Carat == 925)
                    {
                        HighestCarat.Add(rings[i]);
                    }
                }
                else if (rings[i].Metal == "paladis")
                {
                    if (rings[i].Carat == 850)
                    {
                        HighestCarat.Add(rings[i]);
                    }
                }
            }
            return HighestCarat;
        }
        /// <summary>
        /// Finds all of the metals
        /// </summary>
        /// <param name="rings">List of rings</param>
        /// <returns>List of the metals</returns>
        public static List<string> AllMetals(List<Ring> rings)
        {
            List<string> allmetals = new List<string>();
            for (int i = 0; i < rings.Count; i++)
            {
                if (!allmetals.Contains(rings[i].Metal))
                {
                    allmetals.Add(rings[i].Metal);
                }
            }
            return allmetals;
        }
        /// <summary>
        /// Counts total weight of each metal
        /// </summary>
        /// <param name="rings">List of rings</param>
        /// <param name="AllMetals">List of all metals</param>
        /// <returns></returns>
        public static double[] AllWeight(List<Ring> rings, List<string> AllMetals)
        {
            double[] allweight = new double[AllMetals.Count];
            for (int i = 0; i < rings.Count; i++)
            {
                for (int j = 0; j < AllMetals.Count; j++)
                {
                    if (rings[i].Metal == AllMetals[j])
                    {                        
                        allweight[j] += rings[i].Weight;
                    }
                }
               
            }
            return allweight;
        }

    }
}