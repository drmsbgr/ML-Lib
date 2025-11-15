using System.Numerics;

namespace ML_Lib.Common;

public static class Distance
{
    private static bool CheckDimensions<T>(Vector<T> a, Vector<T> b) => a.Length == b.Length;
    public static double Euclidean<T>(Vector<T> a, Vector<T> b) where T : ISubtractionOperators<T, T, double>
    {
        if (!CheckDimensions(a, b))
            throw new ArgumentException("Vektörlerin boyutları eşleşmiyor.");

        double sum = 0.0;

        for (int i = 0; i < a.Length; i++)
        {
            double diff = a[i] - b[i];
            sum += diff * diff;
        }

        return Math.Sqrt(sum);
    }

    public static double Manhattan<T>(Vector<T> a, Vector<T> b) where T : ISubtractionOperators<T, T, double>
    {
        if (!CheckDimensions(a, b))
            throw new ArgumentException("Vektörlerin boyutları eşleşmiyor.");

        double sum = 0.0;

        for (int i = 0; i < a.Length; i++)
            sum += Math.Abs(a[i] - b[i]);

        return sum;
    }
}