using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeenricsDemo1
{
    public class Node<K, T> where K : IComparable<K>
    {
        K key;
        T data;
        private Node<K, T> nextNode;

        public K Key
        {
            get
            {
                return key;
            }

            set
            {
                key = value;
            }
        }

        public T Data
        {
            get
            {
                return data;
            }

            set
            {
                data = value;
            }
        }

        public Node<K, T> NextNode
        {
            get
            {
                return nextNode;
            }

            set
            {
                nextNode = value;
            }
        }

        public Node() : this(default(K), default(T), null)
        {

        }

        public Node(K _key, T _data, Node<K, T> _nextNode)
        {
            key = _key;
            data = _data;
            nextNode = _nextNode;
        }
    }
    public class LinkedList<K, T> where K: IComparable<K>
    {
        Node<K, T> head;
       
        Node<K, T> current;
        
        public Node<K, T> Head
        {
            get
            {
                return head;
            }

            set
            {
                head = value;
            }
        }

        public Node<K, T> Current
        {
            get
            {
                return current;
            }

            set
            {
                current = value;
            }
        }

        public LinkedList()
        {
            Head = new Node<K, T>();
            Current = Head;
        }
        public void Add(K key, T data)
        {
            Node<K, T> newNode = new Node<K, T>(key, data, null);
            Current.NextNode = newNode;
            Current = newNode;
        }

        T Find(K key)
        {
            Node<K, T> current = Head;
            while (current.NextNode != null)
            {
                if (current.Key.CompareTo(key) == 0) //Will not compile
                    break;
                else

                    current = current.NextNode;
            }
            return current.Data;
        }
    }
}
