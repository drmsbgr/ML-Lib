namespace ML_Lib.Common;

public static class VectorFactory
{
    public static Vector<T> Create<T>(IEnumerable<T> elements)
    {
        var vector = new Vector<T>(elements.Count());
        for (int i = 0; i < elements.Count(); i++)
            vector[i] = elements.ElementAt(i);
        return vector;
    }
    public static Vector<T> Create<T>(params T[] elements)
    {
        var vector = new Vector<T>(elements.Length);
        for (int i = 0; i < elements.Length; i++)
            vector[i] = elements[i];
        return vector;
    }

    public static Vector<double> Create(params double[] elements)
    {
        var vector = new Vector<double>(elements.Length);
        for (int i = 0; i < elements.Length; i++)
            vector[i] = elements[i];
        return vector;
    }
}
