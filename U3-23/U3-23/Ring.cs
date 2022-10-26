using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U3_23
{
    class Ring
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
        /// Ring size
        /// </summary>
        public double Size { get; set; }
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
        public Ring(string shopname,string address, string phone, string manufacturer, string name, string metal, double weight, double size, double carat, double price)
        {
            this.Shopname = shopname;
            this.Address = address;
            this.Phone = phone;
            this.Manufacturer = manufacturer;
            this.Name = name;
            this.Metal = metal;
            this.Weight = weight;
            this.Size = size;
            this.Carat = carat;
            this.Price = price;
        }
        /// <summary>
        /// Converts class object to string
        /// </summary>
        /// <returns>A string</returns>
        public override string ToString()
        {
            string temp = string.Format("{0, 23} {1,13} {2,15} {3,10} {4,8} {5,6} {6,7} {7,9}", Shopname, Manufacturer, Name, Metal, Weight, Size, Carat, Price);
            return temp;
        }
        public int CompareTo(Ring other)
        {
            if (this.Manufacturer.CompareTo(other.Manufacturer) == 0)
            {
                return this.Price.CompareTo(other.Price);
            }
            return this.Manufacturer.CompareTo(other.Manufacturer);
        }

        public override bool Equals(object obj)
        {
            return obj is Ring ring &&
                   Name == ring.Name;
        }
    }
}
