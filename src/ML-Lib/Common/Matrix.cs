using ML_Lib.Exceptions.Matrix;

namespace ML_Lib.Common;

public class Matrix(int rows, int cols)
{
    private readonly double[,] _data = new double[rows, cols];

    public double this[int row, int col]
    {
        get => _data[row, col];
        set => _data[row, col] = value;
    }

    private int curRow = 0;

    public int Rows => _data.GetLength(0);
    public int Cols => _data.GetLength(1);

    public void AddRow(params double[] row)
    {
        if (row.Length != Cols)
            throw new DimensionsUnmatchedException();

        if (curRow == rows)
            throw new IndexOutOfRangeException();

        for (int i = 0; i < Cols; i++)
            _data[curRow, i] = row[i];

        curRow++;
    }

    public static Matrix operator +(Matrix a, Matrix b)
    {
        if (a.Rows != b.Rows || a.Cols != b.Cols)
            throw new DimensionsUnmatchedException();

        Matrix result = new(a.Rows, a.Cols);

        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < a.Cols; j++)
                result[i, j] = a[i, j] + b[i, j];

        return result;
    }
    public static Matrix operator -(Matrix a, Matrix b)
    {
        if (a.Rows != b.Rows || a.Cols != b.Cols)
            throw new DimensionsUnmatchedException();

        Matrix result = new(a.Rows, a.Cols);

        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < a.Cols; j++)
                result[i, j] = a[i, j] - b[i, j];

        return result;
    }

    public static Matrix operator *(Matrix a, Matrix b)
    {
        if (a.Cols != b.Rows)
            throw new DimensionsUnmatchedException();

        Matrix result = new(a.Rows, b.Cols);

        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < b.Cols; j++)
                for (int k = 0; k < a.Cols; k++)
                    result[i, j] += a[i, k] * b[k, j];

        return result;
    }
    public static Matrix operator *(Matrix a, double scalar)
    {
        Matrix result = new(a.Rows, a.Cols);

        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < a.Cols; j++)
                result[i, j] = a[i, j] * scalar;

        return result;
    }
    public static Matrix operator *(double scalar, Matrix a)
    {
        return a * scalar;
    }
    public static Matrix operator /(Matrix a, double scalar)
    {
        Matrix result = new(a.Rows, a.Cols);

        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < a.Cols; j++)
                result[i, j] = a[i, j] / scalar;

        return result;
    }
}