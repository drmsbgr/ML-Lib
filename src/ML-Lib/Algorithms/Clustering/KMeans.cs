namespace ML_Lib.Algorithms.Clustering;

using ML_Lib.Common;
using ML_Lib.Interfaces;

public class KMeansOptions(int k, int maxIterations)
{
    public int K { get; set; } = k;
    public int MaxIterations { get; set; } = maxIterations;
}

public class KMeans(KMeansOptions options) : IClusterAlgorithm
{
    public int[] Cluster(Matrix data)
    {
        throw new NotImplementedException();
    }
}