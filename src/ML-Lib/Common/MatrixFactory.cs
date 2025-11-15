namespace ML_Lib.Common;

public static class MatrixFactory
{
    public static Matrix<double> Create(int rows, int cols) => new(rows, cols);
}
