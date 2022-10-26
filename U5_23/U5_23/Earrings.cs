using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U5_23
{
    class Earrings : Juwelry
    {
        /// <summary>
        /// Ear ring's clasp type
        /// </summary>
        public string ClaspType { get; set; }
        public Earrings(string shopname, string address, string phone, string manufacturer, string name, string metal, double weight, double carat, double price, string ClaspType) : base(shopname, address, phone, manufacturer, name, metal, weight, carat, price)
        {
            this.ClaspType = ClaspType;
        }
        public override string ToString()
        {
            return string.Format("| {0,-23} | {1,-7} | {2,-12} | {3,-12} | {4,-13} | {5,-12} | {6,6} | {7,5} | {8,4} | {9,6} | {10,5} | {11,14} |", Shopname, Address, Phone, Manufacturer, Name, Metal, Weight, Carat, Price, "-", "-", ClaspType);
        }
    }
}
