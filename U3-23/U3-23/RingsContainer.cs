using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U3_23
{
    class RingsContainer
    {
        private int Capacity;
        private Ring[] rings;
        public int Count { get; private set; }
        public RingsContainer()
        {
            this.rings = new Ring[16];
            Capacity = 16;
        }
        public void Add(Ring ring)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.rings[this.Count++] = ring;
        }
        public Ring Get(int index)
        {
            return this.rings[index];
        }
        public bool Contains(Ring ring)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.rings[i].Equals(ring))
                {
                    return true;
                }
            }
            return false;
        }
        public RingsContainer(int capacity = 16)
        {
            this.Capacity = capacity;
            this.rings = new Ring[capacity];
        }
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Ring[] temp = new Ring[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.rings[i];
                }
                this.Capacity = minimumCapacity;
                this.rings = temp;
            }
        }
        public void Put(int index, Ring ring)
        {
            rings[index] = ring;
        }
        public void Insert(int index, Ring ring)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(this.Capacity * 2);
            }
            Count++;
            for (int i = Count; i > index; i--)
            {
                rings[i] = rings[i - 1];
            }
            rings[index] = ring;
        }
        public void Remove(Ring ring)
        {
            for (int i = 0; i < Count; i++)
            {
                if (ring == rings[i])
                {
                    RemoveAt(i);
                    break;
                }
            }
        }
        public void RemoveAt(int index)
        {
            for (int i = index; i < Count; i++)
            {
                rings[i] = rings[i + 1];
            }
            Count--;
        }
        public void Sort()
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Ring a = this.rings[i];
                    Ring b = this.rings[i + 1];
                    if (a.CompareTo(b) > 0)
                    {
                        this.rings[i] = b;
                        this.rings[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }
        public RingsContainer(RingsContainer container) : this()
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }
    }
}
