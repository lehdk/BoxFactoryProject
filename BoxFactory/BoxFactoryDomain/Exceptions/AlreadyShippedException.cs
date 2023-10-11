namespace BoxFactoryDomain.Exceptions;

public class AlreadyShippedException : Exception
{
    public AlreadyShippedException(string message) : base(message) { }  
}
