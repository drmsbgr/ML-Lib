using ML_Lib.Algorithms.Clustering;
using ML_Lib.Common;

namespace ML_Lib.Tests;

public class KMeansTest
{
    [Fact]
    public void KMeansGroupPointCheck()
    {
        // Given
        var data = MatrixFactory.Create(4, 2)
        .AddRow(1, 1)
        .AddRow(2, 2)
        .AddRow(10, 10)
        .AddRow(11, 11);

        // When
        var kmeans = new KMeans(KMeansOptions.Default);
        var clusters = kmeans.Cluster(data);

        // Then
        Assert.Equal(2, clusters.Distinct().Count()); // sonuç olarak iki farklı küme olmalı
        Assert.True(clusters[0] == clusters[1]); // aynı kümede olmalılar
        Assert.True(clusters[2] == clusters[3]); // aynı kümede olmalılar
    }
}