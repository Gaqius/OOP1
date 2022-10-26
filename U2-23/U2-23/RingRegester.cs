using System.Collections.Generic;

namespace U2_23
{
    /// <summary>
    /// Stores informations about rings
    /// </summary>
    class RingRegister
    {
        private string name;
        private string adress;
        private string phone;

        private List<Ring> rings = new List<Ring>();
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
        public List<Ring> FindMostExpensivePlatinum()
        {
            List<Ring> expensiveRings = new List<Ring>();
            Ring mostexpensive = null;
            for (int i = 0; i < this.rings.Count; i++)
            {
                if (rings[i].Metal == "platina")
                {
                    if (mostexpensive == null || this.rings[i].Price > mostexpensive.Price)
                    {
                        mostexpensive = this.rings[i];
                    }
                }
            }
            for (int i = 0; i < this.rings.Count; i++)
            {
                if (rings[i].Metal == "platina" && rings[i].Price == mostexpensive.Price)
                {
                    expensiveRings.Add(rings[i]);
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
            return rings[i];
        }
        /// <summary>
        /// Merges 2 lists
        /// </summary>
        /// <param name="register1">First list</param>
        /// <param name="register2">Second List</param>
        public RingRegister(RingRegister register1, RingRegister register2)
        {
            for (int i = 0; i < register1.Count(); i++)
            {
                this.Add(register1.Get(i));
            }
            for (int i = 0; i < register2.Count(); i++)
            {
                this.Add(register2.Get(i));
            }
        }
        /// <summary>
        /// Finds highest carat ring
        /// </summary>
        /// <returns>Value of highest carat ring</returns>
        public int FindHighestCarat()
        {
            int count = 0;
            for (int i = 0; i < rings.Count; i++)
            {
                if (rings[i].Metal == "auksas")
                {
                    if (rings[i].Carat == 750)
                    {
                        count++;
                    }
                }
                else if (rings[i].Metal == "platina")
                {
                    if (rings[i].Carat == 950)
                    {
                        count++;
                    }
                }
                else if (rings[i].Metal == "sidabras")
                {
                    if (rings[i].Carat == 925)
                    {
                        count++;
                    }
                }
                else if (rings[i].Metal == "paladis")
                {
                    if (rings[i].Carat == 850)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        /// <summary>
        /// Filters rings by size
        /// </summary>
        /// <returns>Returns size </returns>
        public List<Ring> FilteredBySize()
        {
            List<Ring> filtered = new List<Ring>();
            for (int i = 0; i < rings.Count; i++)
            {
                if (rings[i].Size >= 12 && rings[i].Size <= 13)
                {
                    filtered.Add(rings[i]);
                }
            }
            return filtered;
        }
    }
}
