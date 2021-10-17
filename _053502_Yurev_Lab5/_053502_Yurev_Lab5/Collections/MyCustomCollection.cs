using System;
using _053502_Yurev_Lab5.Interfaces;

namespace _053502_Yurev_Lab5.Collections
{
    class Node<T>
    {
        public T _Data;
        public Node<T> _Next;
        public Node<T> _Prev;
        
        public Node()
        {
            _Data = default(T);
            _Next = null;
            _Prev = null;
        }
        
        public Node(T data)
        {
            _Data = data;
            _Next = null;
            _Prev = null;
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
                Node<T> temp = _head;

                for (int i = 0; i < index; i++)
                {
                    temp = temp._Next;
                }
                
                return temp._Data;
            }
            
            set
            {
                if (index <= count - 1)
                {
                    Node<T> temp = _head;
                    
                    for(int i = 0; i < index; i++)
                    {
                        temp = temp._Next;
                    }
                    
                    temp._Data = value;
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
            
            if (_cursor._Next != null)
            {
                _cursor = _cursor._Next;
            }
        }

        public T Current()
        {
            if (count == 0)
            {
                return default;
            }
            
            return _cursor._Data;
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
                _head._Data = item;
                _cursor = _head;
                count++;
            }
            
            else
            {
                Node<T> temp = new Node<T>(item);
                Node<T> reserve = _head;
                
                while (reserve._Next != null)
                {
                    reserve = reserve._Next;
                }
                
                temp._Prev = reserve;
                reserve._Next = temp;
                count++;
            }
        }

        public void Remove(T item)
        {
            if (count == 0)
            {
                return;
            }

            Node<T> temp = _head;
            
            while (!(temp._Data.Equals(item)) && temp._Next != null)
            {
                temp = temp._Next;
            }

            if (temp.Equals(_head))
            {
                if (count == 1)
                {
                    _head._Data = default;
                    _cursor._Data = default;
                    count--;
                    return;
                }
                
                else
                {
                    (_head._Next)._Prev = null;
                    _head = _head._Next;
                    _cursor = _head;
                    count--;
                    return;
                }
            }
            
            else
            {
                if (temp._Prev != null)
                {
                    (temp._Prev)._Next = temp._Next;
                }
                
                if (temp._Next != null)
                {
                    (temp._Next)._Prev = temp._Prev;
                }
                
                _cursor = _head;
                count--;
                return;
            }
        }

        public T RemoveCurrent()
        {
            if (count == 0)
            {
                return default;
            }

            if (_cursor.Equals(_head))
            {
                if (count == 1)
                {
                    _head._Data = default;
                    _cursor._Data = default;
                    count--;
                    return default;
                }
                
                else
                {
                    _head = _head._Next;
                    _cursor = _head;
                    count--;
                    return default;
                }
            }
            else
            {
                if (_cursor._Prev != null)
                {
                    (_cursor._Prev)._Next = _cursor._Next;
                }
                
                if (_cursor._Next != null)
                {
                    (_cursor._Next)._Prev = _cursor._Prev;
                }
                
                _cursor = _head;
                count--;
                return default;
            }
        }
    }
}