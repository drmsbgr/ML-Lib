namespace ML_Lib.Interfaces;

public interface ITrainable<TInput, TOutput>
{
    TOutput Train(TInput data);
}
