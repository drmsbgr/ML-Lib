using System.Numerics;

namespace ML_Lib.Common;

public static class Distance
{
    private static bool CheckDimensions<T>(Vector<T> a, Vector<T> b) where T :
        IAdditionOperators<T, T, T>,
        ISubtractionOperators<T, T, T>,
        IMultiplyOperators<T, T, T>,
        IDivisionOperators<T, T, T> => a.Length == b.Length;
    public static double Euclidean<T>(Vector<T> a, Vector<T> b) where T :
        IAdditionOperators<T, T, T>,
        ISubtractionOperators<T, T, T>,
        IMultiplyOperators<T, T, T>,
        IDivisionOperators<T, T, T>
    {
        if (!CheckDimensions(a, b))
            throw new ArgumentException("Vektörlerin boyutları eşleşmiyor.");

        double sum = 0.0;

        for (int i = 0; i < a.Length; i++)
        {
            T diff = a[i] - b[i];
            sum += (double)Convert.ChangeType(diff * diff, typeof(double));
        }

        return Math.Sqrt(sum);
    }

    public static double Manhattan<T>(Vector<T> a, Vector<T> b) where T :
        IAdditionOperators<T, T, T>,
        ISubtractionOperators<T, T, T>,
        IMultiplyOperators<T, T, T>,
        IDivisionOperators<T, T, T>
    {
        if (!CheckDimensions(a, b))
            throw new ArgumentException("Vektörlerin boyutları eşleşmiyor.");

        double sum = 0.0;

        for (int i = 0; i < a.Length; i++)
        {
            T diff = a[i] - b[i];
            sum += Math.Abs((double)Convert.ChangeType(diff, typeof(double)));
        }

        return sum;
    }
}