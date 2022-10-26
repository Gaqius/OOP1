using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U5_23
{
    internal class JuwleryComparator
    {
        public virtual int Compare(Juwelry a, Juwelry b)
        {
            return a.CompareTo(b);
        }
    }
}
