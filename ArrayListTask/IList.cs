namespace ArrayListTask;

interface IList<T>
{
    T this[int index] { get; set; }

    void Add(T item);

    void RemoveAt(int index);
}