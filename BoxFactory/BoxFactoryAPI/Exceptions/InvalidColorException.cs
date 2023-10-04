namespace BoxFactoryAPI.Exceptions;

public sealed class InvalidColorException : Exception
{
    public InvalidColorException(string message) : base(message) { }
}
