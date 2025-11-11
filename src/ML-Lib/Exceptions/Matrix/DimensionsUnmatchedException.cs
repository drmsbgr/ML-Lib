namespace ML_Lib.Exceptions.Matrix;

public sealed class DimensionsUnmatchedException : Exception
{
    public DimensionsUnmatchedException() : base("Matrislerin boyutları eşleşmiyor.")
    {
    }
}