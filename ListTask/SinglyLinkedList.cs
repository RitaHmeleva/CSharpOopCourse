using System.Text;

namespace ListTask;

class SinglyLinkedList<T>
{
    private ListItem<T>? _head;

    public int Count { get; private set; }

    public SinglyLinkedList()
    {

    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.Append('(');

        if (_head != null)
        {
            for (ListItem<T> currentItem = _head; currentItem.Next != null; currentItem = currentItem.Next)
            {
                stringBuilder.Append(currentItem.Data);
                stringBuilder.Append(", ");

                if (currentItem.Next.Next == null)
                {
                    stringBuilder.Append(currentItem.Next.Data);
                }
            }
        }
        stringBuilder.Append(')');

        return stringBuilder.ToString();
    }

    public T? GetFirst()
    {
        if (_head == null)
        {
            throw new NullReferenceException();
        }

        return _head.Data;
    }

    private ListItem<T>? GetItem(int index)
    {
        ListItem<T>? currentItem = _head;

        int i = 0;

        while (i <= index && currentItem != null)
        {
            currentItem = currentItem.Next;

            i++;
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

    public T? this[int index]
    {
        get
        {
            CheckIndex(index);

            ListItem<T>? item = GetItem(index);

            if (item is null)
            {
                return default;
            }

            return item.Data;
        }

        set
        {
            CheckIndex(index);

            ListItem<T>? item = GetItem(index);

            if (item is not null)
            {
                item.Data = value;
            }
            else
            {
                throw new IndexOutOfRangeException($"Item at index {index} is null");
            }
        }
    }

    public T? Remove(int index)
    {
        if (_head is null)
        {
            throw new IndexOutOfRangeException("Can't remove element from empty list");
        }

        CheckIndex(index);

        Count--;

        T? removedData = _head.Data;

        if (index == 0)
        {
            return RemoveFirst();
        }

        ListItem<T>? previousItem = GetItem(index - 1);
        if (previousItem is not null && previousItem.Next is not null)
        {
            removedData = previousItem.Next.Data;
            previousItem.Next = previousItem.Next.Next;
        }

        return removedData;
    }

    public void AddFirst(T? data)
    {
        _head = new ListItem<T>(data, _head);

        Count++;
    }

    public void AddByIndex(int index, T? data)
    {
        if (index < 0 || index > Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), $"Index {index} should be between 0 and {Count}");
        }

        ListItem<T> newItem = new ListItem<T>(data);

        if (index == 0)
        {
            AddFirst(data);
        }
        else
        {
            ListItem<T>? previousItem = GetItem(index - 1);
            if (previousItem is not null)
            {
                newItem.Next = previousItem.Next;
                previousItem.Next = newItem;
            }

            Count++;
        }
    }

    public bool RemoveData(T? data)
    {
        for (ListItem<T>? currentItem = _head, previousItem = null; currentItem != null; previousItem = currentItem, currentItem = currentItem.Next)
        {
            if (currentItem.Data is null && data is null || currentItem.Data is not null && currentItem.Data.Equals(data))
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

    public T? RemoveFirst()
    {
        if (_head == null)
        {
            throw new IndexOutOfRangeException("Can't remove element from empty list");
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