using System.Reflection;
using ML_Lib.Algorithms.Classification;
using ML_Lib.Common;

namespace ML_Lib.App;

public static class KNNExample
{
    public static void Exec()
    {
        var folderPath = Assembly.GetExecutingAssembly().Location;

        var filePath = Path.Combine(folderPath, "..", "..", "..", "..", "data.txt");

        var dr = new DataReader(filePath);

        var (data, classes) = dr.Read();

        //knn
        var knn = new KNN(data, classes, KNNOptions.Default);
        var input = VectorFactory.Create(1.0, 0.0);
        var predictedClass = knn.Predict(input);

        Console.Write($"Input: {input}\nPredictedClass: {predictedClass}");
    }
}