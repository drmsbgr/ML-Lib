namespace ML_Lib.Algorithms.Clustering;

using ML_Lib.Common;
using ML_Lib.Interfaces;

public class KMeans(KMeansOptions options) : IClusterAlgorithm
{
    private readonly Random random = new();

    public int[] Cluster(Matrix<double> data)
    {
        int numOfClusters = options.K;
        var dataDict = new Dictionary<Vector<double>, int>(data.Rows);

        var clusters = new Dictionary<Vector<double>, int>(numOfClusters);

        var copy = (Matrix<double>)data.Clone();

        Console.WriteLine("initials");
        for (int i = 0; i < numOfClusters; i++)
        {
            int randomRowIndex = random.Next(0, copy.Rows);
            var randomRow = copy[randomRowIndex].Label($"C{i}");
            copy.RemoveRow(randomRowIndex);
            clusters.Add(randomRow, clusters.Count);
            Console.WriteLine(randomRow);
        }

        for (int i = 0; i < options.MaxIterations; i++)
        {
            foreach (var row in data)
            {
                var nearestCluster = clusters.OrderBy(x => Distance.Euclidean(x.Key, row)).First();
                if (dataDict.ContainsKey(row))
                    dataDict[row] = nearestCluster.Value;
                else
                    dataDict.Add(row, nearestCluster.Value);
            }

            foreach (var cluster in clusters)
            {
                var rowsInCluster = data.Where(x => dataDict[x] == cluster.Value).ToList();
                if (rowsInCluster.Count == 0)
                    continue;

                var sum = new Vector<double>(rowsInCluster[0].Length);

                for (int r = 0; r < rowsInCluster.Count; r++)
                {
                    sum += rowsInCluster[r];
                }
                sum /= rowsInCluster.Count;

                for (int r = 0; r < cluster.Key.Length; r++)
                    cluster.Key[r] = sum[r];
            }

        }

        return [.. dataDict.Values];
    }
}