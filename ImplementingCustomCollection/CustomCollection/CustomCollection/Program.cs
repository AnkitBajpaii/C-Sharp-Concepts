using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace CustomCollectionDemo1
{
    public class CustomListEnumerator<T> : IEnumerable<T>
    {
        MyCustomList<T> list = new MyCustomList<T>();

        public CustomListEnumerator(MyCustomList<T> customList)
        {
            this.list = customList;
        }


        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < list.Length; i++)
            {
                yield return list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class MyCustomList<T>
    {
        T[] _items = null;
        int size = 0;
        int pointer = 0;
        public MyCustomList()
            : this(10)
        {

        }

        public T this[int index]
        {
            get
            {
                return _items[index];
            }


            set
            {
                _items[index] = value;
            }
        }

        public MyCustomList(int _size)
        {
            this.size = _size;
            _items = new T[size];
        }

        public void Add(T item)
        {
            if (pointer < size)
            {
                _items[pointer] = item;
                pointer++;
            }
            else
                throw new Exception("Cannot add more items");
        }

        public T Remove(T item)
        {
            pointer--;
            if (pointer >= 0)
            {
                T temp = _items[pointer];
                _items[pointer] = default(T);
                return temp;

            }
            else
                throw new Exception("Cannot remove more items");
        }

        public int Length
        {
            get
            {
                return _items.Length;
            }
        }

        public CustomListEnumerator<T> GetCustomListEnumerator()
        {
            return new CustomListEnumerator<T>(this);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyCustomList<string> customList = new MyCustomList<string>(5);

            customList.Add("ankit");
            customList.Add("anu");
            customList.Add("preetam");
            customList.Add("nandi");
            customList.Add("sumit");

            foreach (var item in customList.GetCustomListEnumerator())
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
