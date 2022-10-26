using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U5_23
{
    internal class JuwlertyComparatorByManufacturer :JuwleryComparator
    {
        public override int Compare(Juwelry a, Juwelry b)
        {
            //if (a.Manufacturer.CompareTo(b.Manufacturer) == 0)
            //{
            //    if (a.Name.CompareTo(b.Name) == 0)
            //    {
            //        return a.Price.CompareTo(b.Price);
            //    }
            //    return a.Name.CompareTo(b.Name);
            //}
            return a.Manufacturer.CompareTo(b.Manufacturer);
        }
    }
}
