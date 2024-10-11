using System.Text;

namespace ListTask;

class SinglyLinkedList<T>
{
    private ListItem<T> _head;

    public int Count { get; private set; }

    public SinglyLinkedList()
    {

    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.Append('(');

        for (ListItem<T> currentItem = _head; currentItem != null; currentItem = currentItem.Next)
        {
            stringBuilder.Append(currentItem.Data + ", ");
        }

        stringBuilder.Append(')');

        return stringBuilder.ToString();
    }

    public T GetFirstElement()
    {
        if (_head == null)
        {
            throw new NullReferenceException();
        }

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
            throw new ArgumentOutOfRangeException(nameof(index), $"Index {index} should be between 0 and {Count - 1}");
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

        T removedData = _head.Data;

        if (index == 0)
        {
            _head = _head.Next;

            return removedData;
        }

        ListItem<T> previousItem = GetItem(index - 1);
        removedData = previousItem.Next.Data;
        previousItem.Next = previousItem.Next.Next;

        return removedData;
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
            throw new ArgumentOutOfRangeException(nameof(index), $"Index {index} should be between 0 and {Count}");
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

        for (ListItem<T>? currentItem = _head, previousItem = null; currentItem != null; previousItem = currentItem, currentItem = currentItem.Next)
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
            throw new Exception("Can't remove element from empty list");
        }

        ListItem<T> removedItem = _head;

        _head = _head.Next;

        Count--;

        return removedItem.Data;
    }

    public void Reverse()
    {
        ListItem<T>? currentItem = _head;
        ListItem<T> previousItem = null;

        while (currentItem != null)
        {
            ListItem<T>? nextItem = currentItem.Next;
            currentItem.Next = previousItem;
            previousItem = currentItem;
            currentItem = nextItem;
        }

        _head = previousItem;
    }

    public SinglyLinkedList<T> GetCopy()
    {
        SinglyLinkedList<T> newList = new SinglyLinkedList<T>();

        if (_head == null)
        {
            return newList;
        }

        ListItem<T>? item = _head;

        ListItem<T> copyItem = new ListItem<T>(item.Data);
        newList._head = copyItem;

        ListItem<T> newPreviousItem = copyItem;

        item = item.Next;

        while (item != null)
        {
            copyItem = new ListItem<T>(item.Data);
            newPreviousItem.Next = copyItem;

            newPreviousItem = copyItem;

            item = item.Next;

            newList.Count++;
        }

        return newList;
    }
}