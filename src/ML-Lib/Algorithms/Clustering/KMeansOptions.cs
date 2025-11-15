namespace ML_Lib.Algorithms.Clustering;

public class KMeansOptions(int k, int maxIterations)
{
    public int K { get; set; } = k;
    public int MaxIterations { get; set; } = maxIterations;
}
