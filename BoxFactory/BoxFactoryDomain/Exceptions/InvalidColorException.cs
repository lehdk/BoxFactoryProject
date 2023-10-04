namespace BoxFactoryAPI.Exceptions;

public sealed class InvalidColorException : Exception
{
    public InvalidColorException() : base() { }

    public InvalidColorException(string message) : base(message) { }
}
