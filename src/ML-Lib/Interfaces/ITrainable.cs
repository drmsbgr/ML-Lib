namespace ML_Lib.Interfaces;

public interface ITrainable<TInput>
{
    void Train(TInput data);
}
