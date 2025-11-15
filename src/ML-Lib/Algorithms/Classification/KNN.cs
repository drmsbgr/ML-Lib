using ML_Lib.Common;
using ML_Lib.Interfaces;

namespace ML_Lib.Algorithms.Classification;

public class KNN(Matrix<double> data, Vector<int> classes, KNNOptions options) : IPredictable<Vector<double>, int>
{
    public int Predict(Vector<double> input)
    {
        var dict = new Dictionary<int, Vector<double>>();

        for (int i = 0; i < data.Rows; i++)
            dict.Add(i, data[i]);

        var sortedDict = dict.OrderBy(kv =>
            options.DistanceOption == DistanceOptions.Euclidean
            ? Distance.Euclidean(input, kv.Value)
            : Distance.Manhattan(input, kv.Value));

        var topK = sortedDict.Take(options.K);

        return topK
            .GroupBy(kv => classes[kv.Key])
            .OrderByDescending(g => g.Count())
            .First()
            .Key;
    }
}