using System.Globalization;

namespace ML_Lib.Common;

public class DataReader(string filePath)
{
    public (Matrix<double> data, Vector<int> classes) Read(bool hasHeader = true)
    {
        var lines = new List<string>(File.ReadAllLines(filePath));

        if (hasHeader)
            lines.RemoveAt(0);

        var fullMatrix = MatrixFactory.Create(lines.Count, lines[0].Split(',').Length);

        lines.ForEach(r =>
        {
            var values = r.Split(',');

            var row = VectorFactory.Create(values.Select(x => double.Parse(x, CultureInfo.InvariantCulture)));

            fullMatrix.AddRow(row);
        });

        //splitting data and class
        var classes = fullMatrix.GetColumn<int>(fullMatrix.Cols - 1);
        var data = new Matrix<double>(fullMatrix.Rows, fullMatrix.Cols - 1);

        for (int i = 0; i < fullMatrix.Rows; i++)
        {
            var row = new Vector<double>(fullMatrix.Cols - 1);
            for (int j = 0; j < fullMatrix.Cols - 1; j++)
                row[j] = fullMatrix[i, j];
            data.AddRow(row);
        }

        return (data, classes);
    }
}