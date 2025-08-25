namespace WSDK.Errors;

/// <summary>
/// Represents the outcome of an operation that can either succeed with a value or fail with an error.
/// </summary>
public class Result<T>
{
    public bool IsSuccess { get; }
    public T? Value { get; }
    public WalacorException? Error { get; }

    private Result(bool isSuccess, T? value, WalacorException? error)
    {
        IsSuccess = isSuccess;
        Value = value;
        Error = error;
    }

    public static Result<T> FromValue(T value) => new(true, value, null);
    public static Result<T> FromError(WalacorException error) => new(false, default, error);
}
