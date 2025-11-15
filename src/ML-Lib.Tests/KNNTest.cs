using ML_Lib.Algorithms.Classification;
using ML_Lib.Common;

namespace ML_Lib.Tests;

public class KNNTest
{
    [Fact]
    public void KNNTest1()
    {
        // Given
        var data = MatrixFactory.Create(rows: 3, cols: 2)
        .AddRow(1, 2)
        .AddRow(2, 3)
        .AddRow(3, 4);

        var classes = VectorFactory.Create(0, 0, 1);

        // When
        var options = new KNNOptions(k: 2);
        var knn = new KNN(data, classes, options);
        var result = knn.Predict(VectorFactory.Create(2.0, 2.0));

        // Then
        Assert.Equal(0, result);
    }
}