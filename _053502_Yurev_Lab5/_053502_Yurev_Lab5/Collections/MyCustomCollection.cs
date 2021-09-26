using System;
using _053502_Yurev_Lab5.Interfaces;

namespace _053502_Yurev_Lab5.Collections
{
    class Node<T>
    {
        public T _item;
        public Node<T> Next;
        public Node<T> Prev;

        public Node(T item)
        {
            _item = item;
            Next = null;
            Prev = null;
        } 
        
        public Node()
        {
            _item = default(T);
            Next = null;
            Prev = null;
        }
    }

     class MyCustomCollection<T>: Node<T>, ICustomCollection<T>
    {
        Node<T> _head = new Node<T>();
        Node<T> _cursor = new Node<T>();
        int count = 0;

        public T this[int index] 
        {
            get
            {
                try
                {
                    Node<T> temp = new Node<T>();
                    temp = _head;
                    int counter = 0;
                    while (counter != index)
                    {
                        temp = temp.Next;
                        counter++;
                    }
                    return temp._item;
                }
                catch(IndexOutOfRangeException)
                {
                    Console.WriteLine("No such element exists.");
                    return default;
                }
            }
            
            set
            {
                if (index > count - 1)
                {
                    Console.WriteLine("No such element exists.");
                }
                else
                {
                    int counter = 0;
                    Node<T> help = new Node<T>();
                    help = _head;
                    while (counter != index)
                    {
                        help = help.Next;
                        counter++;
                    }
                    help._item = value;
                }           
            }
        }

        public void Reset()
        {
            if(count == 0)
            {
                return;
            }
            
            _cursor = _head;
        }

        public void Next()
        {
            if (count == 0)
            {
                return;
            }
            
            if (_cursor.Next != null)
            {
                _cursor = _cursor.Next;
            }
        }

        public T Current()
        {
            if (count == 0)
            {
                return default;
            }
            return _cursor._item;
        }
        
        public int Count 
        { 
            get
            {
                return count;
            }
        }

        public void Add(T item)
        {       
            if (count == 0)
            {
                _head._item = item;
                _cursor = _head;
                count++;
                return;
            }
            else
            {
                Node<T> temp = new Node<T>(item);
                Node<T> reserve = _head;
                while (reserve.Next != null)
                {
                    reserve = reserve.Next;
                }
                temp.Prev = reserve;
                reserve.Next = temp;
                count++;
            }
        }

        public void Remove(T item)
        {
            try
            {
                if (count == 0)
                {
                    Console.WriteLine("Collection is empty.");
                    return;
                }

                Node<T> help = _head;
                while (!(help._item.Equals(item)) && help.Next != null)
                {
                    help = help.Next;
                }
                if (!(help._item.Equals(item)) && help.Next == null)
                {
                    throw new Exception("No such element exists.");
                }

                if (help.Equals(_head))
                {
                    if (count == 1)
                    {
                        _head._item = default;
                        _cursor._item = default;
                        count--;
                        return;
                    }
                    else
                    {
                        (_head.Next).Prev = null;
                        _head = _head.Next;
                        _cursor = _head;
                        count--;
                        return;
                    }
                }
                else
                {
                    if (help.Prev != null)
                    {
                        (help.Prev).Next = help.Next;
                    }
                    if (help.Next != null)
                    {
                        (help.Next).Prev = help.Prev;
                    }
                    _cursor = _head;
                    count--;
                    return;
                }
            }
            catch(Exception)
            {
                Console.WriteLine("You tried to remove the next item - {0}", item);
            }
        }

        public T RemoveCurrent()
        {
            if (count == 0)
            {
                Console.WriteLine("Collection is empty.");
                return default;
            }

            if (_cursor.Equals(_head))
            {
                if (count == 1)
                {
                    _head._item = default;
                    _cursor._item = default;
                    count--;
                    return default;
                }
                else
                {
                    _head = _head.Next;
                    _cursor = _head;
                    count--;
                    return default;
                }
            }
            else
            {
                if (_cursor.Prev != null)
                {
                    (_cursor.Prev).Next = _cursor.Next;
                }
                if (_cursor.Next != null)
                {
                    (_cursor.Next).Prev = _cursor.Prev;
                }
                _cursor = _head;
                count--;
                return default;
            }
        }
    }
}