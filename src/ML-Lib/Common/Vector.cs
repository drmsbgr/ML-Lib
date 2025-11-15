using System.Collections;
using System.Text;

namespace ML_Lib.Common;

public class Vector<T>(int size) : IEnumerable<T>
{
    public static Vector<T> Create(params T[] elements)
    {
        var vector = new Vector<T>(elements.Length);
        for (int i = 0; i < elements.Length; i++)
            vector[i] = elements[i];
        return vector;
    }

    private readonly T[] _elements = new T[size];

    public int Length => _elements.Length;
    private int curIndex;

    public T this[int index]
    {
        get => _elements[index];
        set => _elements[index] = value;
    }

    public void Add(T element)
    {
        if (curIndex == Length)
            throw new IndexOutOfRangeException();

        _elements[curIndex] = element;
        curIndex++;
    }

    public void AddRange(IEnumerable<T> elements)
    {
        foreach (var item in elements)
            Add(item);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _elements.AsEnumerable().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public override string ToString()
    {
        var s = new StringBuilder();

        s.Append("[{");
        s.Append(string.Join(", ", _elements.Select(x => x is null ? "NaN" : x.ToString())));
        s.Append("}]");

        return s.ToString();
    }
}