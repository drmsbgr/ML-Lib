using System.Collections;
using System.Numerics;
using System.Text;
using ML_Lib.Exceptions.Matrix;

namespace ML_Lib.Common;

public class Matrix<T> : IEnumerable<Vector<T>> where T :
    IAdditionOperators<T, T, T>,
    ISubtractionOperators<T, T, T>,
    IDivisionOperators<T, double, T>,
    IMultiplyOperators<T, double, T>,
    IMultiplyOperators<T, T, T>
{
    public Matrix(int rows, int cols)
    {
        _rows = new Vector<T>[rows];
        for (int i = 0; i < rows; i++)
            _rows[i] = new Vector<T>(cols);
    }
    private readonly Vector<T>[] _rows;

    public Vector<T> this[int row] => _rows[row];

    public T this[int row, int col]
    {
        get => _rows[row][col];
        set => _rows[row][col] = value;
    }

    private int curRow = 0;

    public int Rows => _rows.Length;
    public int Cols => _rows[0].Length;

    public void AddRow(params T[] row)
    {
        if (row.Length != Cols)
            throw new Exception($"Bu matrise '{row.Length}' sütunlu veri eklenemez.");

        if (curRow == Rows)
            throw new Exception("Bu matrise daha fazla satır eklenemiyor.");

        var vector = new Vector<T>(row.Length);
        for (int i = 0; i < row.Length; i++)
            vector[i] = row[i];

        AddRow(vector);
    }

    public void AddRow(Vector<T> row)
    {
        if (row.Length != Cols)
            throw new DimensionsUnmatchedException();

        if (curRow == Rows)
            throw new IndexOutOfRangeException();

        for (int i = 0; i < Cols; i++)
            _rows[curRow][i] = row[i];

        curRow++;
    }

    public Vector<TResult> GetColumn<TResult>(int col)
    {
        if (col < 0 || col >= Cols)
            throw new IndexOutOfRangeException();

        var column = new Vector<TResult>(Rows);

        for (int i = 0; i < Rows; i++)
            column.Add((TResult)Convert.ChangeType(_rows[i][col], typeof(TResult)));

        return column;
    }

    public IEnumerator<Vector<T>> GetEnumerator()
    {
        return ((IEnumerable<Vector<T>>)_rows).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public static Matrix<T> operator +(Matrix<T> a, Matrix<T> b)
    {
        if (a.Rows != b.Rows || a.Cols != b.Cols)
            throw new DimensionsUnmatchedException();

        Matrix<T> result = new(a.Rows, a.Cols);

        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < a.Cols; j++)
                result[i, j] = a[i, j] + b[i, j];

        return result;
    }
    public static Matrix<T> operator -(Matrix<T> a, Matrix<T> b)
    {
        if (a.Rows != b.Rows || a.Cols != b.Cols)
            throw new DimensionsUnmatchedException();

        Matrix<T> result = new(a.Rows, a.Cols);

        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < a.Cols; j++)
                result[i, j] = a[i, j] - b[i, j];

        return result;
    }

    public static Matrix<T> operator *(Matrix<T> a, Matrix<T> b)
    {
        if (a.Cols != b.Rows)
            throw new DimensionsUnmatchedException();

        Matrix<T> result = new(a.Rows, b.Cols);

        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < b.Cols; j++)
                for (int k = 0; k < a.Cols; k++)
                    result[i, j] += a[i, k] * b[k, j];

        return result;
    }
    public static Matrix<T> operator *(Matrix<T> a, double scalar)
    {
        Matrix<T> result = new(a.Rows, a.Cols);

        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < a.Cols; j++)
                result[i, j] = a[i, j] * scalar;

        return result;
    }
    public static Matrix<T> operator *(double scalar, Matrix<T> a)
    {
        return a * scalar;
    }
    public static Matrix<T> operator /(Matrix<T> a, double scalar)
    {
        Matrix<T> result = new(a.Rows, a.Cols);

        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < a.Cols; j++)
                result[i, j] = a[i, j] / scalar;

        return result;
    }

    public override string ToString()
    {
        var finale = new StringBuilder();

        finale.AppendLine("[");

        for (int i = 0; i < _rows.Length; i++)
        {
            var row = _rows[i];

            finale.Append(" {");

            finale.Append(string.Join(", ", row.Select(x => x.ToString())));

            finale.AppendLine("}" + (i == _rows.Length - 1 ? "" : ","));
        }

        finale.AppendLine("]");

        return finale.ToString();
    }
}