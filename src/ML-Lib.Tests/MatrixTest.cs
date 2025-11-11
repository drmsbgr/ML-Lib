using ML_Lib.Common;

namespace ML_Lib.Tests;

public class UnitTest1
{
    [Fact]
    public void CreateMatrixTest()
    {
        //matrisi oluştur
        var m = new Matrix(2, 3);
        //değerleri ata
        m[0, 0] = 1;
        m[0, 1] = 2;
        m[0, 2] = 3;

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
        var m = new Matrix(2, 2);
        m[0, 0] = 1;
        m[0, 1] = 2;
        m[1, 0] = 3;
        m[1, 1] = 4;

        // When
        var result = m * 2;

        // Then
        Assert.Equal(2, result[0, 0]);
        Assert.Equal(4, result[0, 1]);
        Assert.Equal(6, result[1, 0]);
        Assert.Equal(8, result[1, 1]);
    }
}
