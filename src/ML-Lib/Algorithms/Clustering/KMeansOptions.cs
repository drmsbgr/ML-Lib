namespace ML_Lib.Algorithms.Clustering;

public class KMeansOptions(int k = 2, int maxIterations = 10)
{
    public static KMeansOptions Default => new();
    public int K { get; set; } = k;
    public int MaxIterations { get; set; } = maxIterations;
}
