using System;

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

        public override string ToString()
        {
            return Data.ToString();
        }
    }

    class SinglyLinkedList<T>
    {
        private ListItem<T> head;

        private int count;

        public SinglyLinkedList()
        {
            count = 0;
        }

        public override string ToString()
        {
            string s = null;

            for (ListItem<T> currentItem = head; currentItem != null; currentItem = currentItem.Next)
            {
                s += currentItem.Data + " ";
            }

            return s;
        }

        public int GetCount()
        {
            return count;
        }

        public ListItem<T> GetFirstElement()
        {
            return head;
        }

        private ListItem<T> GetItem(int index)
        {
            ListItem<T> currentItem = head;

            for (int i = 0; i < index; i++)
            {
                currentItem = currentItem.Next;
            }

            return currentItem;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0)
                {
                    throw new ArgumentOutOfRangeException("");
                }

                if (index >= count)
                {
                    throw new ArgumentOutOfRangeException("");
                }

                ListItem<T> currentItem = GetItem(index);

                return currentItem.Data;
            }

            set
            {
                if (index < 0)
                {
                    throw new ArgumentOutOfRangeException("");
                }

                if (index >= count)
                {
                    throw new ArgumentOutOfRangeException("");
                }

                ListItem<T> currentItem = GetItem(index);

                currentItem.Data = value;
            }
        }

        public T GetData(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("");
            }

            if (index >= count)
            {
                throw new ArgumentOutOfRangeException("");
            }

            ListItem<T> currentItem = GetItem(index);

            return currentItem.Data;
        }

        public T SetData(int index, T data)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("");
            }

            if (index >= count)
            {
                throw new ArgumentOutOfRangeException("");
            }

            ListItem<T> currentItem = GetItem(index);

            T oldValue = currentItem.Data;
            currentItem.Data = data;

            return oldValue;
        }

        public T DeleteElement(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("");
            }

            if (index >= count)
            {
                throw new ArgumentOutOfRangeException("");
            }

            count--;

            ListItem<T> currentItem = head;
            ListItem<T> previousItem = head;

            T deletedValue = currentItem.Data;

            if (index == 0)
            {
                head = currentItem.Next;

                return deletedValue;
            }

            for (int i = 0; i < index; i++)
            {
                previousItem = currentItem;
                currentItem = currentItem.Next;
            }

            deletedValue = previousItem.Next.Data;
            previousItem.Next = currentItem.Next;

            return deletedValue;
        }

        public void AddFirst(T element)
        {
            head = new ListItem<T>(element, head);

            count++;
        }

        public void AddByIndex(int index, T element)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("");
            }

            if (index >= count)
            {
                throw new ArgumentOutOfRangeException("");
            }

            count++;

            ListItem<T> currentItem = head;
            ListItem<T> previousItem = head;
            ListItem<T> temp = new ListItem<T>(element);

            if (index == 0)
            {
                head = temp;
            }
            else
            {
                for (int i = 0; i < index; i++)
                {
                    previousItem = currentItem;
                    currentItem = currentItem.Next;
                }

                previousItem.Next = temp;
            }

            temp.Next = currentItem;
        }

        public bool DeleteData(T data)
        {
            int changesCount = 0;

            for (ListItem<T> currentItem = head, previousItem = null; currentItem != null; previousItem = currentItem, currentItem = currentItem.Next)
            {
                if (currentItem.Data.Equals(data))
                {
                    previousItem.Next = currentItem.Next;
                    changesCount++;
                    count--;
                }
            }

            if (changesCount > 0)
            {
                return true;
            }

            return false;
        }

        public ListItem<T> GetDeletedFirstElement()
        {
            ListItem<T> deletedElement = head;

            head = head.Next;

            count--;

            return deletedElement;
        }

        public void Reverse()
        {
            ListItem<T> currentItem = head;

            for (int i = 1; i <= count/2; i++)
            {
                ListItem<T> lastItem = GetItem(count - i);
                T item = currentItem.Data;
                currentItem.Data = lastItem.Data;
                lastItem.Data = item;
                currentItem = currentItem.Next;
            }
        }

        public SinglyLinkedList<T> GetCopy()
        {
            SinglyLinkedList<T> newList = new SinglyLinkedList<T>();

            ListItem<T> item = head;
            ListItem<T> newPrevItem = null;

            while (item != null)
            {
                ListItem<T> newItem = new ListItem<T>(item.Data, null);

                if(newPrevItem != null)
                {
                    newPrevItem.Next = newItem;
                }
                else
                {
                    newList.head = newItem;
                }

                newPrevItem = newItem;

                item = item.Next;
            }

            return newList;
        }
    }
}