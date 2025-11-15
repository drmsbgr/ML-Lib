using System.Collections;
using System.Numerics;
using System.Text;
using ML_Lib.Exceptions.Matrix;

namespace ML_Lib.Common;

public class Vector<T>(int size) : IEnumerable<T> where T :
    IAdditionOperators<T, T, T>,
    ISubtractionOperators<T, T, T>,
    IMultiplyOperators<T, T, T>
{
    private readonly T[] _elements = new T[size];
    private string _name = string.Empty;
    public string Name => _name;

    public Vector<T> Label(string name)
    {
        _name = name;
        return this;
    }

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

    public static Vector<T> operator +(Vector<T> a, Vector<T> b)
    {
        if (a.Length != b.Length)
            throw new DimensionsUnmatchedException();

        var result = new Vector<T>(a.Length);
        for (int i = 0; i < a.Length; i++)
            result[i] = a[i] + b[i];
        return result;
    }

    public static Vector<T> operator -(Vector<T> a, Vector<T> b)
    {
        if (a.Length != b.Length)
            throw new DimensionsUnmatchedException();

        var result = new Vector<T>(a.Length);
        for (int i = 0; i < a.Length; i++)
            result[i] = a[i] - b[i];
        return result;
    }

    public static Vector<T> operator *(Vector<T> a, double scalar)
    {
        var result = new Vector<T>(a.Length);
        for (int i = 0; i < a.Length; i++)
            result[i] = (T)Convert.ChangeType((double)Convert.ChangeType(a[i], typeof(double)) * scalar, typeof(T));
        return result;
    }

    public static Vector<T> operator *(double scalar, Vector<T> a)
    {
        return a * scalar;
    }

    public static Vector<T> operator /(Vector<T> a, double scalar)
    {
        var result = new Vector<T>(a.Length);
        for (int i = 0; i < a.Length; i++)
            result[i] = (T)Convert.ChangeType((double)Convert.ChangeType(a[i], typeof(double)) / scalar, typeof(T));
        return result;
    }

    public override string ToString()
    {
        var s = new StringBuilder();

        if (!string.IsNullOrEmpty(_name))
            s.Append($"{_name} = ");

        s.Append('[');
        s.Append(string.Join(", ", _elements.Select(x => x is null ? "NaN" : x.ToString())));
        s.Append(']');

        return s.ToString();
    }
}