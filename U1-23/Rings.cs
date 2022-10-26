using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace U123
{
    /// <summary>
    /// Information about the ring
    /// </summary>
    class Ring
    {
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
        /// <param name="manufacturer">Manufacturer</param>
        /// <param name="name">Name</param>
        /// <param name="metal">Metal</param>
        /// <param name="weight">Weight</param>
        /// <param name="size">Size</param>
        /// <param name="carat">Carat</param>
        /// <param name="price">Price</param>
        public Ring(string manufacturer, string name, string metal, double weight, double size, double carat, double price)
        {
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
            string temp = string.Format("{0,-14} {1,-16} {2,-13} {3,6} {4,7} {5,7} {6,9}", Manufacturer, Name, Metal, Weight, Size, Carat, Price);
            return temp;
        }
    }
}