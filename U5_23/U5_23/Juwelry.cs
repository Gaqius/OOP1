using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U5_23
{
    abstract class Juwelry
    {
        /// <summary>
        /// Shop's name
        /// </summary>
        public string Shopname { get; set; }
        /// <summary>
        /// Ring manufacturer's adress
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Ring manufacturer phone number
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Ring's manufacturer
        /// </summary>
        public string Manufacturer { get; set; }
        /// <summary>
        /// Ring's name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Metal from which ring is made
        /// </summary>
        public string Metal { get; set; }
        /// <summary>
        /// Ring's weight
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Ring's` carat
        /// </summary>
        public double Carat { get; set; }
        /// <summary>
        /// Ring price
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Ring class
        /// </summary>
        /// <param name="shopname"></param>
        /// <param name="manufacturer"></param>
        /// <param name="name"></param>
        /// <param name="metal"></param>
        /// <param name="weight"></param>
        /// <param name="size"></param>
        /// <param name="carat"></param>
        /// <param name="price"></param>
        public Juwelry(string shopname, string address, string phone, string manufacturer, string name, string metal, double weight, double carat, double price)
        {
            this.Shopname = shopname;
            this.Address = address;
            this.Phone = phone;
            this.Manufacturer = manufacturer;
            this.Name = name;
            this.Metal = metal;
            this.Weight = weight;
            this.Carat = carat;
            this.Price = price;
        }
        public override bool Equals(object obj)
        {
            return obj is Juwelry juwelry &&                   
                   Manufacturer == juwelry.Manufacturer &&
                   Name == juwelry.Name &&
                   Metal == juwelry.Metal &&
                   Weight == juwelry.Weight &&
                   Carat == juwelry.Carat &&
                   Price == juwelry.Price;
        }
        public override int GetHashCode()
        {
            int hashCode = 99611837;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Manufacturer);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Metal);
            hashCode = hashCode * -1521134295 + Weight.GetHashCode();
            hashCode = hashCode * -1521134295 + Carat.GetHashCode();
            hashCode = hashCode * -1521134295 + Price.GetHashCode();
            return hashCode;
        }
        public int CompareTo(Juwelry other)
        {
            if (this.Manufacturer.CompareTo(other.Manufacturer) == 0)
            {
                return this.Price.CompareTo(other.Price);
            }
            return this.Manufacturer.CompareTo(other.Manufacturer);
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
