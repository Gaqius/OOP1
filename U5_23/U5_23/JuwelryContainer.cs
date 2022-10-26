using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U5_23
{
    class JuwelryContainer
    {
        private int Capacity;
        private Juwelry[] juwelries;
        public int Count { get; private set; }
        /// <summary>
        /// Container
        /// </summary>
        public JuwelryContainer()
        {
            this.juwelries = new Juwelry[16];
            Capacity = 16;
        }
        /// <summary>
        /// Adds to container
        /// </summary>
        /// <param name="juwelry"></param>
        public void Add(Juwelry juwelry)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.juwelries[this.Count++] = juwelry;
        }
        public void Add(JuwelryContainer juwelryContainer)
        {
            for (int i = 0; i < juwelryContainer.Count; i++)
            {
                Add(juwelryContainer.Get(i));
            }
        }
        /// <summary>
        /// Gets index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Juwelry Get(int index)
        {
            return this.juwelries[index];
        }
        /// <summary>
        /// Checks if container contains element
        /// </summary>
        /// <param name="juwelry"></param>
        /// <returns></returns>
        public bool Contains(Juwelry juwelry)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.juwelries[i].Equals(juwelry))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Sets default capacity
        /// </summary>
        /// <param name="capacity"></param>
        public JuwelryContainer(int capacity = 16)
        {
            this.Capacity = capacity;
            this.juwelries = new Juwelry[capacity];
        }
        /// <summary>
        /// Ensures if container has enough capacity
        /// </summary>
        /// <param name="minimumCapacity"></param>
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Juwelry[] temp = new Juwelry[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.juwelries[i];
                }
                this.Capacity = minimumCapacity;
                this.juwelries = temp;
            }
        }
        /// <summary>
        /// Puts an object at index
        /// </summary>
        /// <param name="index"></param>
        /// <param name="juwelry"></param>
        public void Put(int index, Juwelry juwelry)
        {
            juwelries[index] = juwelry;
        }
        /// <summary>
        /// Inserts an object at index
        /// </summary>
        /// <param name="index"></param>
        /// <param name="juwelry"></param>
        public void Insert(int index, Juwelry juwelry)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(this.Capacity * 2);
            }
            Count++;
            for (int i = Count; i > index; i--)
            {
                juwelries[i] = juwelries[i - 1];
            }
            juwelries[index] = juwelry;
        }
        /// <summary>
        /// Removes an object
        /// </summary>
        /// <param name="juwelry"></param>
        public void Remove(Juwelry juwelry)
        {
            for (int i = 0; i < Count; i++)
            {
                if (juwelry == juwelries[i])
                {
                    RemoveAt(i);
                    break;
                }
            }
        }
        /// <summary>
        /// Removes an object at index
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            for (int i = index; i < Count; i++)
            {
                juwelries[i] = juwelries[i + 1];
            }
            Count--;
        }
        /// <summary>
        /// Sort method
        /// </summary>
        /// <param name="comparator"></param>
        public void Sort(JuwleryComparator comparator)
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Juwelry a = this.juwelries[i];
                    Juwelry b = this.juwelries[i + 1];
                    if (comparator.Compare(a,b) > 0)
                    {
                        this.juwelries[i] = b;
                        this.juwelries[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }
        /// <summary>
        /// Default sort
        /// </summary>
        public void Sort()
        {
            Sort(new JuwleryComparator());
        }
        /// <summary>
        /// Override
        /// </summary>
        /// <param name="container"></param>
        public JuwelryContainer(JuwelryContainer container) : this()
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }
    }
}
