using System.Numerics;

namespace ML_Lib.Common;

public static class VectorFactory
{
    public static Vector<int> Create(params int[] elements)
    {
        var vector = new Vector<int>(elements.Length);
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
