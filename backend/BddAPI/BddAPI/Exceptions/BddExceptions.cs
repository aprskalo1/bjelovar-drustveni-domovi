namespace BddAPI.Exceptions;

internal class UserException(string message) : BddCustomException(message)
{
    public override string ToString()
    {
        return $"UserException: {Message}";
    }
}