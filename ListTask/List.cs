using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ListTask
{
    class ListItem<T>
    {
        public T Data { get; set; }

        public ListItem<T> Next { get; set; }

        public ListItem(T data)
        {
            Data = data;
        }

        public ListItem(T data, ListItem<T> next)
        {
            Data = data;
            Next = next;
        }
    }

    class SinglyLinkedList<T>
    {
        private ListItem<T> _head;

        public int Count { get; private set; }

        public SinglyLinkedList()
        {
            Count = 0;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            string s = null;

            for (ListItem<T> currentItem = _head; currentItem != null; currentItem = currentItem.Next)
            {
                stringBuilder.Append(currentItem.Data + " ");

            }

            return stringBuilder.ToString();
        }

        public T GetFirstElement()
        {
            return _head.Data;
        }

        private ListItem<T> GetItem(int index)
        {
            ListItem<T> currentItem = _head;

            for (int i = 1; i <= index; i++)
            {
                currentItem = currentItem.Next;
            }

            return currentItem;
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Index should be between 0 and {Count - 1}");
            }
        }

        public T this[int index]
        {
            get
            {
                CheckIndex(index);

                return GetItem(index).Data;
            }

            set
            {
                CheckIndex(index);

                GetItem(index).Data = value;
            }
        }

        public T RemoveElement(int index)
        {
            CheckIndex(index);

            Count--;

            T removedValue = _head.Data;

            if (index == 0)
            {
                _head = _head.Next;

                return removedValue;
            }

            ListItem<T> previousItem = GetItem(index - 1);
            removedValue = previousItem.Next.Data;
            previousItem.Next = previousItem.Next.Next;
           
            return removedValue;
        }

        public void AddFirst(T data)
        {
            _head = new ListItem<T>(data, _head);

            Count++;
        }

        public void AddByIndex(int index, T data)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Index should be between 0 and {Count}");
            }

            Count++;

            ListItem<T> newItem = new ListItem<T>(data);

            if (index == 0)
            {
                newItem.Next = _head;
                _head = newItem;
            }
            else
            {
                ListItem<T> previousItem = GetItem(index - 1);
                newItem.Next = previousItem.Next;
                previousItem.Next = newItem;
            }
        }

        public bool RemoveData(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data), "Data should not be null");
            }

            for (ListItem<T> currentItem = _head, previousItem = null; currentItem != null; previousItem = currentItem, currentItem = currentItem.Next)
            {
                if (currentItem.Data.Equals(data))
                {
                    if (previousItem == null)
                    {
                        _head = currentItem.Next;
                    }
                    else
                    {
                        previousItem.Next = currentItem.Next;
                    }

                    Count--;

                    return true;
                }
            }

            return false;
        }

        public T RemoveFirstElement()
        {
            if (_head == null)
            {
                throw new Exception("Cant remove element from empty list");
            }

            ListItem<T> removedElement = _head;

            _head = _head.Next;

            Count--;

            return removedElement.Data;
        }

        public void Reverse()
        {
            ListItem<T> currentItem = _head;


        }

        public SinglyLinkedList<T> GetCopy()
        {
            SinglyLinkedList<T> newList = new SinglyLinkedList<T>();

            if (_head != null)
            {
                ListItem<T> item = _head;

                ListItem<T> newItem = new ListItem<T>(item.Data);
                newList._head = newItem;

                ListItem<T> newPrevItem = newItem;

                item = item.Next;

                while (item != null)
                {
                    newItem = new ListItem<T>(item.Data);
                    newPrevItem.Next = newItem;

                    newPrevItem = newItem;

                    item = item.Next;

                    newList.Count++;
                }
            }

            return newList;
        }
    }
}