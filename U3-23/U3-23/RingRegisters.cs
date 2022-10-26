using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U3_23
{
    class RingRegister
    {
        private string name;
        private string adress;
        private string phone;

        private RingsContainer rings = new RingsContainer();
        /// <summary>
        /// Stores information about the shop and rings
        /// </summary>
        /// <param name="name">Shop's name</param>
        /// <param name="adress">Shop's adress</param>
        /// <param name="phone">Shop's phone number</param>
        public RingRegister(string name, string adress, string phone)
        {
            this.name = name;
            this.adress = adress;
            this.phone = phone;
        }
        /// <summary>
        /// Adds a single ring to the current register
        /// </summary>
        /// <param name="ring">ring</param>
        public void Add(Ring ring)
        {
            rings.Add(ring);
        }
        /// <summary>
        /// Finds the most expensive platinum ring
        /// </summary>
        /// <returns>A value of the most expensive platinum ring</returns>
        public RingsContainer FindMostExpensiveGold()
        {
            RingsContainer expensiveRings = new RingsContainer();
            Ring mostexpensive = null;
            for (int i = 0; i < this.rings.Count; i++)
            {
                if (rings.Get(i).Metal == "auksas")
                {
                    if (mostexpensive == null || this.rings.Get(i).Price > mostexpensive.Price)
                    {
                        mostexpensive = this.rings.Get(i);
                    }
                }
            }
            for (int i = 0; i < this.rings.Count; i++)
            {
                if (rings.Get(i).Metal == "auksas" && rings.Get(i).Price == mostexpensive.Price)
                {
                    expensiveRings.Add(rings.Get(i));
                }
            }
            return expensiveRings;
        }
        /// <summary>
        /// Counts rings
        /// </summary>
        /// <returns>number of rings</returns>
        public int Count()
        {
            return this.rings.Count;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i">index</param>
        /// <returns>Ring's index</returns>
        public Ring Get(int i)
        {
            return rings.Get(i);
        }
        /// <summary>
        /// Merges 2 lists
        /// </summary>
        /// <param name="container1">First list</param>
        /// <param name="container2">Second List</param>
        public RingRegister(RingsContainer container1, RingsContainer container2)
        {
            for (int i = 0; i < container1.Count; i++)
            {
                this.Add(container1.Get(i));
            }
            for (int i = 0; i < container2.Count; i++)
            {
                this.Add(container2.Get(i));
            }
        }
        /// <summary>
        /// Finds highest carat ring
        /// </summary>
        /// <returns>Value of highest carat ring</returns>
        public int FindHighestCaratCount()
        {
            RingsContainer filtered = FindHighestCarat();

            return filtered.Count;
        }
        /// <summary>
        /// Filters rings by size
        /// </summary>
        /// <returns>Returns size </returns>
        public RingsContainer FilteredBySize()
        {
            RingsContainer filtered = new RingsContainer();
            for (int i = 0; i < rings.Count; i++)
            {
                if (rings.Get(i).Size >= 12 && rings.Get(i).Size <= 13 && rings.Get(i).Price < 300)
                {
                    filtered.Add(rings.Get(i));
                }
            }
            return filtered;
        }
        public RingsContainer FilteredBySame()
        {
            RingsContainer filtered = FindHighestCarat();
            RingsContainer filteredSame = new RingsContainer();

            for (int i = 0; i < filtered.Count - 1; i++)
            {
                for (int j = i + 1; j < filtered.Count; j++)
                {
                    if (filtered.Get(i) == filtered.Get(j) && filtered.Get(i).Shopname != filtered.Get(j).Shopname)
                    {
                        filteredSame.Add(filtered.Get(i));
                        filteredSame.Add(filtered.Get(j));
                    }
                }
            }
            return filteredSame;
        }
        public RingsContainer FindHighestCarat()
        {
            RingsContainer filtered = new RingsContainer();
            for (int i = 0; i < rings.Count; i++)
            {
                if (rings.Get(i).Metal == "auksas")
                {
                    if (rings.Get(i).Carat == 750)
                    {
                        filtered.Add(Get(i));
                    }
                }
                else if (rings.Get(i).Metal == "platina")
                {
                    if (rings.Get(i).Carat == 950)
                    {
                        filtered.Add(Get(i));
                    }
                }
                else if (rings.Get(i).Metal == "sidabras")
                {
                    if (rings.Get(i).Carat == 925)
                    {
                        filtered.Add(Get(i));
                    }
                }
                else if (rings.Get(i).Metal == "paladis")
                {
                    if (rings.Get(i).Carat == 850)
                    {
                        filtered.Add(Get(i));
                    }
                }
            }
            return filtered;
        }
    }
}
