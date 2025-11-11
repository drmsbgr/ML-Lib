using ML_Lib.Algorithms.Clustering;
using ML_Lib.Common;

namespace ML_Lib.Tests;

public class KMeansTest
{
    [Fact]
    public void KMeansGroupPointCheck()
    {
        // Given
        var data = new Matrix(4, 2);

        data.AddRow(1, 1);
        data.AddRow(2, 2);
        data.AddRow(10, 10);
        data.AddRow(11, 11);


        // When
        var options = new KMeansOptions(2, 1);
        var kmeans = new KMeans(options);

        // Then
    }
}