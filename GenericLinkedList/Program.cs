using System;

namespace LinkedListDemo
{
    public class LinkedList<T>
    {
        internal class Node
        {
            public Node Next { get; set; }
            public T Data { get; set; }
            public Node(T data)
            {
                this.Data = data;
                this.Next = null;
            }
        }

        private Node head = null;

        #region Private Methods
        private Node GetLastNode()
        {
            //if list is empty
            if (this.head == null)
            {
                return null;
            }

            Node ptr = this.head;
            while (ptr.Next != null)
            {
                ptr = ptr.Next;
            }

            return ptr;
        }

        private Node GetNodeAtIndex(int index)
        {
            Node ptr = this.head;
            for (int i = 0; i < index - 1 && ptr != null; i++)
            {
                ptr = ptr.Next;
            }

            return ptr;
        }

        private Node SearchNode(T key)
        {
            Node ptr = this.head;
            while (ptr != null && !ptr.Data.Equals(key))
            {
                ptr = ptr.Next;
            }

            return ptr;
        }
        #endregion

        #region Public Methods

        public void AddToFront(T t)
        {
            Node newNode = new Node(t);
            newNode.Next = this.head;
            this.head = newNode;
        }

        public void AddToEnd(T t)
        {
            Node newNode = new Node(t);
            newNode.Next = null;

            Node lastNode = GetLastNode();

            //if list is empty
            if (lastNode == null)
            {

                this.head = newNode;
            }
            else
            {
                lastNode.Next = newNode;
            }
        }

        public void InsertAfter(int index, T t)
        {
            Node newNode = new Node(t);
            Node prevNode = GetNodeAtIndex(index);

            if (this.head == null)
            {
                this.head = newNode;
                return;
            }

            if (prevNode == null)
            {
                throw new IndexOutOfRangeException("You are trying to insert at an index which does not exists.");
            }

            newNode.Next = prevNode.Next;
            prevNode.Next = newNode;
        }

        public bool Exists(T key)
        {
            if (this.head == null)
            {
                return false;
            }

            Node ptr = SearchNode(key);

            return ptr != null;
        }

        public bool DeleteNodeWithKey(T key)
        {
            if (this.head == null)
            {
                return false;
            }

            Node node = SearchNode(key);

            if (node == null)
            {
                return false;
            }

            if (node == this.head)
            {
                Node next = this.head.Next;
                this.head.Next = null;
                this.head = next;
            }

            else
            {
                Node ptr = this.head;
                while (ptr != null && ptr.Next != node)
                {
                    ptr = ptr.Next;
                }

                ptr.Next = node.Next;
            }

            node.Next = null;
            return true;
        }

        public bool DeleteNodeAt(int position)
        {
            if (this.head == null)
            {
                return false;
            }

            Node node = GetNodeAtIndex(position);

            if (node == null)
            {
                return false;
            }

            if (node == this.head)
            {
                Node next = this.head.Next;
                this.head.Next = null;
                this.head = next;
            }

            else
            {
                Node ptr = this.head;
                while (ptr != null && ptr.Next != node)
                {
                    ptr = ptr.Next;
                }

                ptr.Next = node.Next;
            }

            node.Next = null;
            return true;
        }

        public void PrintIterative()
        {
            Node ptr = this.head;
            while (ptr != null)
            {
                Console.Write(ptr.Data + " " );
                ptr = ptr.Next;
            }
            Console.WriteLine();
        }

        public void PrintRecursive()
        {
            Console.WriteLine();
            PrintRecursive(this.head);
        }

        private void PrintRecursive(Node ptr)
        {
            if (ptr == null)
                return;

            Console.Write(ptr.Data+ " ");
            PrintRecursive(ptr.Next);
        }

        public void ReversePrintRecursive()
        {
            Console.WriteLine();
            ReversePrintRecursive(this.head);
        }

        private void ReversePrintRecursive(Node ptr)
        {
            if (ptr == null)
                return;

            ReversePrintRecursive(ptr.Next);
            Console.Write(ptr.Data + " ");
        }

        public void Reverse()
        {
            Node current = this.head, prev = null, next;

            while(current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            this.head = prev;
        }

        public void ReverseRecursive()
        {
            ReverseRecursive(head);
        }
        private void ReverseRecursive(Node p)
        {
            if(p.Next == null)
            {
                this.head = p;
                return;
            }

            ReverseRecursive(p.Next);

            Node q = p.Next;
            q.Next = p;
            p.Next = null;
        }

        #endregion
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddToFront(5);
            list.AddToFront(7);
            list.AddToEnd(11);
            list.AddToEnd(2);

            list.DeleteNodeWithKey(5);
            list.DeleteNodeAt(1);

            list.PrintIterative();
            list.PrintRecursive();
            list.ReversePrintRecursive();

            list.Reverse();
            list.ReverseRecursive();

            Console.ReadKey();
        }
    }
}