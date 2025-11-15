using ML_Lib.Algorithms.Classification;
using ML_Lib.Common;

namespace ML_Lib.Tests;

public class KNNTest
{
    [Fact]
    public void KNNTest1()
    {
        // Given
        var data = MatrixFactory.Create(rows: 3, cols: 2);
        data.AddRow(1, 2);
        data.AddRow(2, 3);
        data.AddRow(3, 4);

        var classes = Vector<int>.Create(0, 0, 1);

        // When
        var options = new KNNOptions(k: 2);
        var knn = new KNN(data, classes, options);
        var result = knn.Predict(Vector<double>.Create(2, 2));

        // Then
        Assert.Equal(0, result);
    }
}