using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U5_23
{
    class JuwelryRegister
    {
        private string name;
        private string adress;
        private string phone;

        private JuwelryContainer juwelries = new JuwelryContainer();
        /// <summary>
        /// Stores information about the shop and rings
        /// </summary>
        /// <param name="name">Shop's name</param>
        /// <param name="adress">Shop's adress</param>
        /// <param name="phone">Shop's phone number</param>
        public JuwelryRegister(string name, string adress, string phone)
        {
            this.name = name;
            this.adress = adress;
            this.phone = phone;
        }
        /// <summary>
        /// Adds a single juwelry to the current register
        /// </summary>
        /// <param name="juwelry">juwelry</param>
        public void Add(Juwelry juwelry)
        {
            juwelries.Add(juwelry);
        }
        /// <summary>
        /// Adds a single juwelry to the current register
        /// </summary>
        /// <param name="juwelryRegister"></param>
        public void Add(JuwelryRegister juwelryRegister)
        {
            for (int i = 0; i < juwelryRegister.Count(); i++)
            {
                this.Add(juwelryRegister.Get(i));
            }
        }
        /// <summary>
        /// Finds the most expensive gold juwelry
        /// </summary>
        /// <returns>A value of the most expensive platinum juwelry</returns>
        public JuwelryContainer FindMostExpensiveGold()
        {
            JuwelryContainer expensiveRings = new JuwelryContainer();
            Juwelry mostexpensive = null;
            for (int i = 0; i < this.juwelries.Count; i++)
            {
                if (juwelries.Get(i).Metal == "auksas" && (mostexpensive == null || this.juwelries.Get(i).Price > mostexpensive.Price))
                {
                    mostexpensive = this.juwelries.Get(i);
                }
            }
            for (int i = 0; i < this.juwelries.Count; i++)
            {
                if (juwelries.Get(i).Metal == "auksas" && juwelries.Get(i).Price == mostexpensive.Price)
                {
                    expensiveRings.Add(juwelries.Get(i));
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
            return this.juwelries.Count;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i">index</param>
        /// <returns>Juwelry's index</returns>
        public Juwelry Get(int i)
        {
            return juwelries.Get(i);
        }
        /// <summary>
        /// Merges 2 lists
        /// </summary>
        /// <param name="container1">First list</param>
        /// <param name="container2">Second List</param>
        public JuwelryRegister(JuwelryContainer container1, JuwelryContainer container2, JuwelryContainer container3)
        {
            for (int i = 0; i < container1.Count; i++)
            {
                this.Add(container1.Get(i));
            }
            for (int i = 0; i < container2.Count; i++)
            {
                this.Add(container2.Get(i));
            }
            for (int i = 0; i < container3.Count; i++)
            {
                this.Add(container3.Get(i));
            }
        }
        /// <summary>
        /// Finds highest carat juwelry
        /// </summary>
        /// <returns>Value of highest carat juwelry</returns>
        public int FindHighestCaratCount()
        {
            JuwelryContainer filtered = FindHighestCarat();

            return filtered.Count;
        }
        /// <summary>
        /// Filters rings by size
        /// </summary>
        /// <returns>Returns size </returns>
        public JuwelryContainer FilteredBySize()
        {
            JuwelryContainer filtered = new JuwelryContainer();
            for (int i = 0; i < juwelries.Count; i++)
            {
                Ring ring = juwelries.Get(i) as Ring;
                if (ring != null)
                {
                    if (ring.Size >= 12 && ring.Size <= 13 && ring.Price < 300)
                    {
                        filtered.Add(ring);
                    }                    
                }                
            }
            return filtered;
        } 
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public JuwelryContainer FilteredBySame()
        {            
            JuwelryContainer Filtered = new JuwelryContainer();
            var stores = GroupJuwelsByStore();
            foreach (var store1 in stores)
            {
                for (int i = 0; i < store1.Value.Count; i++)
                {
                    bool good = true;
                    foreach (var store2 in stores)
                    {
                        if (!store2.Value.Contains(store1.Value.Get(i)))
                        {
                            good = false;
                            break;
                        }
                    }
                    if (good && !Filtered.Contains(store1.Value.Get(i)))
                    {
                        Filtered.Add(store1.Value.Get(i));
                    }
                }
            }
            return Filtered;
        }
        /// <summary>
        /// Groups Juwels by store
        /// </summary>
        /// <returns>A dictionary</returns>
        private Dictionary<string,JuwelryContainer> GroupJuwelsByStore()
        {
            Dictionary<string, JuwelryContainer> result = new Dictionary<string, JuwelryContainer>();
            for (int i = 0; i < juwelries.Count; i++)
            {
                Juwelry juwelry = juwelries.Get(i);
                if (result.ContainsKey(juwelry.Shopname))
                {
                    result[juwelry.Shopname].Add(juwelry);
                }
                else
                {
                    result[juwelry.Shopname] = new JuwelryContainer();
                    result[juwelry.Shopname].Add(juwelry);
                }
            }
            return result;
        }
        /// <summary>
        /// Finds highest carat Juwlery
        /// </summary>
        /// <returns></returns>
        public JuwelryContainer FindHighestCarat()
        {
            JuwelryContainer filtered = new JuwelryContainer();
            for (int i = 0; i < juwelries.Count; i++)
            {
                Juwelry juwelry = juwelries.Get(i);
                if (juwelry.Metal == "auksas" && juwelry.Carat == 750)
                {
                    filtered.Add(juwelry);
                }
                else if (juwelry.Metal == "platina" && juwelry.Carat == 950)
                {
                    filtered.Add(juwelry);
                }
                else if (juwelry.Metal == "sidabras" && juwelry.Carat == 925)
                {
                    filtered.Add(juwelry);
                }
                else if (juwelry.Metal == "paladis" && juwelry.Carat == 850)
                {
                    filtered.Add(juwelry);
                }
            }
            return filtered;
        }
        /// <summary>
        /// Finds the highest carat
        /// </summary>
        /// <returns>a container</returns>
        public Dictionary<string, int> FindHighestCaratAtAll()
        {
            Dictionary<string, int> highestByShop = new Dictionary<string, int>();
            JuwelryContainer highestCarat = FindHighestCarat();
            for (int i = 0; i < highestCarat.Count; i++)
            {
                Juwelry juwelry = highestCarat.Get(i);
                if (highestByShop.ContainsKey(juwelry.Shopname))
                {
                    highestByShop[juwelry.Shopname]++;
                }
                else highestByShop.Add(juwelry.Shopname, 1);
            }            
            return highestByShop;
        }
        /// <summary>
        /// Finds Heaviest of each Juwel
        /// </summary>
        /// <returns>a container</returns>
        public JuwelryContainer FindHeaviest()
        {
            JuwelryContainer heaviest = new JuwelryContainer();
            Ring heaviestRing = null;
            Earrings heaviestEarrings = null;
            Collar heaviestCollar = null;

            for (int i = 0; i < juwelries.Count; i++)
            {
                Juwelry juwelry = this.juwelries.Get(i);                
                if (juwelry is Ring)
                {                    
                    Ring ring = juwelry as Ring;
                    if (heaviestRing == null || ring.Weight > heaviestRing.Weight)
                    {
                        heaviestRing = ring;
                    }
                }
                else if (juwelry is Earrings)
                {
                    Earrings earrings = juwelry as Earrings;
                    if (heaviestEarrings == null || earrings.Weight > heaviestEarrings.Weight)
                    {
                        heaviestEarrings = earrings;
                    }
                }
                else if (juwelry is Collar)
                {
                    Collar collar = juwelry as Collar;
                    if (heaviestCollar == null || collar.Weight > heaviestCollar.Weight)
                    {
                        heaviestCollar = collar;
                    }
                }                
            }
            if (heaviestRing != null)
            {
                heaviest.Add(heaviestRing);
            }
            if (heaviestCollar != null)
            {
                heaviest.Add(heaviestCollar);
            }
            if (heaviestEarrings != null)
            {
                heaviest.Add(heaviestEarrings);
            }            
            return heaviest;
        }
        /// <summary>
        /// Filters by price
        /// </summary>
        /// <returns>A container</returns>
        public JuwelryContainer FilterByMaxPrice(double price)
        {
            JuwelryContainer Filtered = new JuwelryContainer();
            for (int i = 0; i < juwelries.Count; i++)
            {
                Juwelry juwelry = juwelries.Get(i);
                if (juwelry.Price < price)
                {
                    Filtered.Add(juwelry);
                }
            }
            return Filtered;
        }
    }
}