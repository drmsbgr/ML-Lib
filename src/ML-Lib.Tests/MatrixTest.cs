using ML_Lib.Common;

namespace ML_Lib.Tests;

public class MatrixTest
{
    [Fact]
    public void CreateMatrixTest()
    {
        //matrisi oluştur
        var m = MatrixFactory.Create(2, 3)
        .AddRow(1, 2, 3)
        .AddRow(4, 5, 6);

        //değerleri test et
        Assert.Equal(1, m[0, 0]);
        Assert.Equal(2, m[0, 1]);
        Assert.Equal(3, m[0, 2]);

        //satır ve sütunları test et
        Assert.Equal(2, m.Rows);
        Assert.Equal(3, m.Cols);
    }

    [Fact]
    public void CheckMatrixScalarMultiplying()
    {
        // Given
        var m = MatrixFactory.Create(2, 2)
        .AddRow(1, 2)
        .AddRow(3, 4);

        // When
        var result = m * 2;

        // Then
        Assert.Equal(2, result[0, 0]);
        Assert.Equal(4, result[0, 1]);
        Assert.Equal(6, result[1, 0]);
        Assert.Equal(8, result[1, 1]);
    }
}
