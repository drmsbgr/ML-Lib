namespace ML_Lib.Interfaces;

public interface IPredictable<TInput, TOutput>
{
    TOutput Predict(TInput input);
}
