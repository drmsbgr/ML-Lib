using ML_Lib.Common;

namespace ML_Lib.Algorithms.Classification;

public class KNNOptions(int k = 3, DistanceOptions distanceOption = DistanceOptions.Euclidean)
{
    public static KNNOptions Default => new();

    public int K { get; } = k;
    public DistanceOptions DistanceOption { get; } = distanceOption;
}
