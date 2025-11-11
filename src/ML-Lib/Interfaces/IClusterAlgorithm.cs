using ML_Lib.Common;

namespace ML_Lib.Interfaces;

public interface IClusterAlgorithm
{
    int[] Cluster(Matrix data);
}