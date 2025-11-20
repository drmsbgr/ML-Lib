using ML_Lib.Common;
using ML_Lib.Interfaces;

namespace ML_Lib.Algorithms.Classification;

public class DecisionTreeTrainer(string targetAttribute) : ITrainable<List<Dictionary<string, string>>, DecisionTree>
{
    public DecisionTree Train(List<Dictionary<string, string>> data)
    {
        var id3 = new ID3(targetAttribute);
        var root = id3.BuildTree(data, [.. data[0].Keys.Where(x => x != targetAttribute)]);
        return new DecisionTree(root);
    }
}
