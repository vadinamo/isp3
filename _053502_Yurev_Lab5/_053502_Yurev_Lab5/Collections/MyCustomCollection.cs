using System;
using _053502_Yurev_Lab5.Interfaces;

namespace _053502_Yurev_Lab5.Collections
{
    class Node<T>
    {
        public T _item;
        public Node<T> _next;
        public Node<T> _prev;

        public Node(T item)
        {
            _item = item;
            _next = null;
            _prev = null;
        }
        public Node()
        {
            _item = default(T);
            _next = null;
            _prev = null;
        }
    }

     class MyCustomCollection<T>: Node<T>, ICustomCollection<T>
    {
        Node<T> _head = new Node<T>();
        Node<T> _current = new Node<T>();
        int _count = 0;

        public T this[int index] 
        {
            get
            {
                /*
                if(index > amount - 1)
                {
                    Console.WriteLine("No such element exists.");
                    return default;
                }
                else
                {
                    Node<T> help = new Node<T>();
                    help = first;
                    int counter = 0;
                    while(counter != index)
                    {
                        help = help.next;
                        counter++;
                    }
                    return help.val;
                }
                */
                try
                {
                    Node<T> help = new Node<T>();
                    help = _head;
                    int counter = 0;
                    while (counter != index)
                    {
                        help = help._next;
                        counter++;
                    }
                    return help._item;
                }
                catch(IndexOutOfRangeException)
                {
                    Console.WriteLine("No such element exists.");
                    return default;
                }


            }
            set
            {
                if (index > _count - 1)
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
                        help = help._next;
                        counter++;
                    }
                    help._item = value;
                }           
            }
        }

        public void Reset()
        {
            if(_count == 0)
            {
                Console.WriteLine("Collection is empty.");
                return;
            }
            _current = _head;
        }

        public void Next()
        {
            if (_count == 0)
            {
                Console.WriteLine("Collection is empty.");
                return;
            }
            if (_current._next != null)
            {
                _current = _current._next;
            }
            else
            {
                Console.WriteLine("This is the last element.");
            }
        }

        public T Current()
        {
            if (_count == 0)
            {
                Console.WriteLine("Collection is empty.");
                return default;
            }
            return _current._item;
        }
        public int Count 
        { 
            get
            {
                return _count;
            }
        }

        public void Add(T item)
        {       
            if (_count == 0)
            {
                _head._item = item;
                _current = _head;
                _count++;
                return;
            }
            else
            {
                Node<T> help = new Node<T>(item);
                Node<T> helpcurr = _head;
                while (helpcurr._next != null)
                {
                    helpcurr = helpcurr._next;
                }
                help._prev = helpcurr;
                helpcurr._next = help;
                _count++;
            }
        }

        public void Remove(T item)
        {

            try
            {
                if (_count == 0)
                {
                    Console.WriteLine("Collection is empty.");
                    return;
                }

                Node<T> help = _head;
                while (!(help._item.Equals(item)) && help._next != null)
                {
                    help = help._next;
                }
                if (!(help._item.Equals(item)) && help._next == null)
                {
                    throw new Exception("No such element exists.");
                    //Console.WriteLine("No such element exists.");
                    //return;
                }

                if (help.Equals(_head))
                {
                    if (_count == 1)
                    {
                        _head._item = default;
                        _current._item = default;
                        _count--;
                        return;
                    }
                    else
                    {
                        (_head._next)._prev = null;
                        _head = _head._next;
                        _current = _head;
                        _count--;
                        return;
                    }
                }
                else
                {
                    if (help._prev != null)
                    {
                        (help._prev)._next = help._next;
                    }
                    if (help._next != null)
                    {
                        (help._next)._prev = help._prev;
                    }
                    _current = _head;
                    _count--;
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
            if (_count == 0)
            {
                Console.WriteLine("Collection is empty.");
                return default;
            }

            if (_current.Equals(_head))
            {
                if (_count == 1)
                {
                    _head._item = default;
                    _current._item = default;
                    _count--;
                    return default;
                }
                else
                {
                    _head = _head._next;
                    _current = _head;
                    _count--;
                    return default;
                }
            }
            else
            {
                if (_current._prev != null)
                {
                    (_current._prev)._next = _current._next;
                }
                if (_current._next != null)
                {
                    (_current._next)._prev = _current._prev;
                }
                _current = _head;
                _count--;
                return default;
            }

        }
    }
}