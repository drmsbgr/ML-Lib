namespace ML_Lib.Algorithms.Clustering;

using ML_Lib.Common;
using ML_Lib.Interfaces;

public class KMeans(KMeansOptions options) : IClusterAlgorithm
{
    public int[] Cluster(Matrix<double> data)
    {
        int numberOfClusters = options.K;
        int[] clusters = new int[data.Rows];



        return clusters;

    }
}