using System.Text;

namespace ListTask;

class SinglyLinkedList<T>
{
    private ListItem<T>? _head;

    public int Count { get; private set; }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder("(");

        if (_head is null)
        {
            stringBuilder.Append(')');

            return stringBuilder.ToString();
        }

        for (ListItem<T>? currentItem = _head; currentItem is not null; currentItem = currentItem.Next)
        {
            stringBuilder.Append(currentItem.Data);

            if (currentItem.Next is not null)
            {
                stringBuilder.Append(", ");
            }
        }

        stringBuilder.Append(')');

        return stringBuilder.ToString();
    }

    public T GetFirst()
    {
        if (_head is null)
        {
            throw new InvalidOperationException("Can't get first element from empty list");
        }

        return _head.Data;
    }

    private ListItem<T> GetItem(int index)
    {
        ListItem<T>? currentItem = _head;

        for (int i = 1; i <= index; i++)
        {
            currentItem = currentItem!.Next;
        }

        return currentItem!;
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

            ListItem<T> item = GetItem(index);

            return item.Data;
        }

        set
        {
            CheckIndex(index);

            ListItem<T> item = GetItem(index);

            item.Data = value;
        }
    }

    public T Remove(int index)
    {
        if (_head is null)
        {
            throw new InvalidOperationException("Can't remove element from empty list");
        }

        CheckIndex(index);

        Count--;

        if (index == 0)
        {
            return RemoveFirst();
        }

        ListItem<T> previousItem = GetItem(index - 1);

        T removedData = previousItem.Next!.Data;
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

        if (index == 0)
        {
            AddFirst(data);
        }
        else
        {
            ListItem<T> newItem = new ListItem<T>(data);
            ListItem<T>? previousItem = GetItem(index - 1);

            newItem.Next = previousItem.Next;
            previousItem.Next = newItem;

            Count++;
        }
    }

    public bool RemoveData(T data)
    {
        for (ListItem<T>? currentItem = _head, previousItem = null; currentItem is not null; previousItem = currentItem, currentItem = currentItem.Next)
        {
            if ((currentItem.Data is null && data is null) || Equals(data, currentItem.Data))
            {
                if (previousItem is null)
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

    public T RemoveFirst()
    {
        if (_head is null)
        {
            throw new InvalidOperationException("Can't remove element from empty list");
        }

        ListItem<T> removedItem = _head;

        _head = _head.Next;

        Count--;

        return removedItem.Data;
    }

    public void Reverse()
    {
        ListItem<T>? currentItem = _head;
        ListItem<T>? previousItem = null;

        while (currentItem is not null)
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

        if (_head is null)
        {
            return newList;
        }

        ListItem<T> newItem = new ListItem<T>(_head.Data);
        newList._head = newItem;

        ListItem<T>? item = _head.Next;

        while (item is not null)
        {
            newItem.Next = new ListItem<T>(item.Data);
            newItem = newItem.Next;

            item = item.Next;
        }

        newList.Count = Count;

        return newList;
    }
}