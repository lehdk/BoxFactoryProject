﻿namespace BoxFactoryDomain.Exceptions;

public class EmptyListException : Exception
{
    public EmptyListException(string message) : base(message) { }
}
