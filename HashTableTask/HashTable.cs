using System.Collections;
using System.Text;

namespace HashTableTask;

internal class HashTable<T> : ICollection<T>
{
    private List<T>[] _items;
    private const int _defaultSize = 101;

    public bool IsReadOnly => throw new NotImplementedException();

    public HashTable()
    {
        _items = new List<T>[_defaultSize];
    }

    public HashTable(int size)
    {
        if (size <= 0)
        {
            throw new ArgumentException($"Size {size} should be > 0", nameof(size));
        }

        _items = new List<T>[size];
    }

    public int Count
    {
        get; private set;
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();

        foreach (List<T> list in _items)
        {
            if (list != null)
            {
                foreach (T item in list)
                {
                    stringBuilder.Append(item + " ");
                }
            }
        }

        return stringBuilder.ToString();
    }

    public void Add(T item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item), "Item should not be null");
        }

        int index = Math.Abs(item.GetHashCode() % _items.Length);

        if (_items[index] == null)
        {
            _items[index] = new List<T> { item };

            Count++;
        }
        else
        {
            if (!_items[index].Contains(item))
            {
                _items[index].Add(item);

                Count++;
            }
        }
    }

    public void Clear()
    {
        for (int i = 0; i < _items.Length; i++)
        {
            if (_items[i] != null)
            {
                _items[i].Clear();
                _items[i] = null;
            }
        }

        Count = 0;
    }

    public bool Contains(T item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item), "Item should not be null");
        }

        foreach (T tableItem in this)
        {
            int comparisonResult = Comparer<T>.Default.Compare(tableItem, item);

            if (comparisonResult == 0)
            {
                return true;
            }
        }

        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (arrayIndex < 0)
        {
            throw new IndexOutOfRangeException("Array index should be > 0");
        }

        foreach (T tableItem in this)
        {
            if (arrayIndex < array.Length)
            {
                array[arrayIndex++] = tableItem;
            }
            else
            {
                throw new IndexOutOfRangeException("Not enough place in array");
            }
        }
    }

    public bool Remove(T item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item), "Item should not be null");
        }

        foreach (List<T> list in _items)
        {
            if (list != null)
            {
                foreach (T listItem in list)
                {
                    int comparisonResult = Comparer<T>.Default.Compare(listItem, item);

                    if (comparisonResult == 0)
                    {
                        list.Remove(listItem);
                        return true;
                    }
                }
            }
        }

        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new Enumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new Enumerator(this);
    }

    internal class Enumerator : IEnumerator<T>
    {
        private HashTable<T> _hashTable;
        private int _index1;
        private int _index2;

        public Enumerator(HashTable<T> hashTable)
        {
            _hashTable = hashTable;

            Reset();
        }

        public T Current
        {
            get
            {
                if (_index1 < 0 || _index2 < 0) throw new InvalidOperationException("Enumerator Ended");

                return _hashTable._items[_index1][_index2];
            }
        }

        object? IEnumerator.Current
        {
            get
            {
                if (_index1 < 0 || _index2 < 0) throw new InvalidOperationException("Enumerator Ended");

                return _hashTable._items[_index1][_index2];
            }
        }

        public void Dispose()
        {
            _index1 = _index2 = -1;
        }

        public bool MoveNext()
        {
            if (_index1 > -1 && _index2 > -1 && _index2 < _hashTable._items[_index1].Count - 1)
            {
                _index2++;
            }
            else
            {
                for (int i = _index1 + 1; i < _hashTable._items.Length; i++)
                {
                    _index2 = -1;
                    if (_hashTable._items[i] != null && _hashTable._items[i].Count > 0)
                    {
                        _index1 = i;
                        _index2 = 0;

                        break;
                    }
                }
            }

            if (_index2 < 0)
            {
                return false;
            }

            return true;
        }

        public void Reset()
        {
            _index1 = _index2 = -1;
        }
    }
}