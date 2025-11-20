using ML_Lib.Common;

namespace ML_Lib.App;

public static class MatrixExample
{
    public static void Exec()
    {
        var a = MatrixFactory
        .Create(4, 3)
        .Label("A")
        .AddRow(1, 2, 3)
        .AddRow(1, 0, 2)
        .AddRow(2, 2, 1)
        .AddRow(0, 3, 5);

        a.RemoveRow(3);


        Console.WriteLine(a);
        Console.WriteLine(a.GetNColumns(2).Label("A2"));
        Console.WriteLine(a.GetColumn(2).Label("A3"));

        var b = MatrixFactory.Create(3, 3).AddRow(1, 1, 1).AddRow(0, 1, 1).AddRow(2, 2, 1).Label("B");

        var x = -2 * a + b * 2;

        Console.WriteLine(b);
        Console.WriteLine(x.Label("C"));
    }
}