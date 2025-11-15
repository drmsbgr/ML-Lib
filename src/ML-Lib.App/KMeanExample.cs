using ML_Lib.Algorithms.Clustering;
using ML_Lib.Common;

namespace ML_Lib.App;

public static class KMeanExample
{
    public static void KMeanExec()
    {
        var data = MatrixFactory
        .Create(10, 2)
        .AddRow(2, 1)
        .AddRow(3, 3)
        .AddRow(4, 4)
        .AddRow(5, 5)
        .AddRow(6, 6)
        .AddRow(1, 7)
        .AddRow(2, 2)
        .AddRow(3, 2)
        .AddRow(4, 1)
        .AddRow(3, 1);

        var kmeans = new KMeans(new(2));

        var clusterIds = VectorFactory.Create(kmeans.Cluster(data)).Label("ClusterIds");
        Console.WriteLine(clusterIds);
    }
}