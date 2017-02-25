using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeenricsDemo1
{
    /*  Under C# 1.1, you have to use an Object-based stack, meaning that the internal data type used in the stack is an amorphous Object, 
     *  and the stack methods interact with Objects:
     */
    public class Stack
    {
        readonly long m_Size;
        int m_StackPointer = 0;
        object[] m_Items;
        public Stack()
            : this(100)
        { }
        public Stack(long size)
        {
            m_Size = size;
            m_Items = new object[m_Size];
        }
        public void Push(object item)
        {
            if (m_StackPointer >= m_Size)
                throw new StackOverflowException();
            m_Items[m_StackPointer] = item;
            m_StackPointer++;
        }
        public object Pop()
        {
            m_StackPointer--;
            if (m_StackPointer >= 0)
            {
                return m_Items[m_StackPointer];
            }
            else
            {
                m_StackPointer = 0;
                throw new InvalidOperationException("Cannot pop an empty stack");
            }
        }
    }

    public class Stack<T>
    {
        readonly long size;
        T[] items;
        int pointer = 0;
        public Stack() : this(100)
        {

        }

        public Stack(long _size)
        {
            this.size = _size;
            items = new T[size];
        }
        public void Push(T item)
        {
            if (pointer >= size)
                throw new StackOverflowException();
            items[pointer] = item;
            pointer++;
        }

        public T Pop()
        {
            --pointer;
            if (pointer >= 0)
            {
                return items[pointer];
            }
            else
            {
                pointer = 0;
                throw new InvalidOperationException("Cannot pop an empty stack");
            }

        }
    }

    class Program
    {
        static void StackDemo()
        {
            const long size = 10000000;
            Stack stack = new Stack(size);
            DateTime startTime = DateTime.Now;
            Console.WriteLine(startTime.ToString("MM/dd/yyyy hh:mm:ss.fff tt"));
            Console.WriteLine("***************************************************************");
            Console.WriteLine("Push started on object Stack at:" + startTime.ToString() + "\n");
            for (long i = 0; i < size; i++)
            {
                stack.Push(i);
            }
            DateTime endTime = DateTime.Now;
            Console.WriteLine("Push completed on object Stack at:" + endTime.ToString() + "\n");
            TimeSpan timeSpan = endTime - startTime;
            Console.WriteLine("Time elapsed for push:" + timeSpan.ToString() + "\n");

            startTime = DateTime.Now;
            Console.WriteLine("Pop started on object Stack at:" + startTime.ToString() + "\n");
            for (long i = 0; i < size; i++)
            {
                long val = (long)stack.Pop();
            }
            endTime = DateTime.Now;
            Console.WriteLine("Pop completed on object Stack at:" + endTime.ToString() + "\n");


            timeSpan = endTime - startTime;
            Console.WriteLine("Time elapsed for pop:" + timeSpan.ToString(@"hh\:mm\:ss\.fffffff") + "\n");
            Console.WriteLine("***************************************************************" + "\n");

            Stack<long> genericStck = new Stack<long>(size);
            startTime = DateTime.Now;
            Console.WriteLine("Push started on generic Stack at:" + startTime.ToString() + "\n");
            for (int i = 0; i < size; i++)
            {
                genericStck.Push(i);
            }

            endTime = DateTime.Now;
            Console.WriteLine("Push completed on generic Stack at:" + endTime.ToString() + "\n");
            timeSpan = endTime - startTime;
            Console.WriteLine("Time elapsed for push:" + timeSpan.ToString() + "\n");

            startTime = DateTime.Now;
            Console.WriteLine("Pop started on generic Stack at:" + startTime.ToString() + "\n");
            for (long i = 0; i < size; i++)
            {
                long val = genericStck.Pop();

            }
            endTime = DateTime.Now;
            Console.WriteLine("Pop completed on generic Stack at:" + endTime.ToString() + "\n");


            timeSpan = endTime - startTime;
            Console.WriteLine("Time elapsed for pop:" + timeSpan.ToString());
        }

        static LinkedList<int, string> LinkedListDemo()
        {
            LinkedList<int, string> list = new LinkedList<int, string>();
            Node<int, string> node1 = list.Head;
            Node<int, string> node2 = list.Current;

            list.Add(1, "Ankit");
            list.Add(2, "Anu");
            list.Add(3, "Maya");
            list.Add(4, "Mayank");
            return list;
        }
        static void Main(string[] args)
        {
            /*
             there are two problems with Object-based solutions. The first issue is performance. When using value types, you have to box them in order to push and store them, and unbox the value types when popping them off the stack. Boxing and unboxing incurs a significant performance penalty in their own right, but it also increases the pressure on the managed heap, resulting in more garbage collections, which is not great for performance either. Even when using reference types instead of value types, there is still a performance penalty because you have to cast from an Object to the actual type you interact with and incur the casting cost
             */
            string str = null;
            do
            {
                Console.WriteLine("Press 1 for StackDemo\nPress 2 for LinkedList Demo");
                string input = Console.ReadLine();
                int res = 0;
                if (Int32.TryParse(input, out res))
                {
                    if (res == 1 || res == 2)
                    {
                        if (res == 1)
                        {
                            StackDemo();
                        }
                        if (res == 2)
                        {
                            LinkedList<int, string> list = LinkedListDemo();

                            Console.WriteLine("Traversing linked list");
                            while (list.Head != null && list.Head.NextNode != null)
                            {
                                string val = "Node("+list.Head.NextNode.Key + " ," + list.Head.NextNode.Data+").Next";
                                list.Head = list.Head.NextNode;
                                Console.Write(list.Head.Equals(list.Current) ? val+"==> Null" +"\n": val + "==> ");
                            }
                        }
                        Console.WriteLine("Do you want to contiue(y/n)?");
                        str = Console.ReadLine();
                    }

                    else
                    { Console.WriteLine("Please enter correct option."); str = "y"; }
                }

                else
                { Console.WriteLine("Input not in correct format. Please re-enter again."); str = "y"; }

            } while (str.Equals("y", StringComparison.OrdinalIgnoreCase));
    

        }
    }
}
