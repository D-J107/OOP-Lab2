using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CustomExceptions;

public sealed class AttributeNotSpecifiedException : NullReferenceException
{
    public AttributeNotSpecifiedException() { }
    public AttributeNotSpecifiedException(string message)
        : base(message) { }

    public AttributeNotSpecifiedException(string message, Exception innerException)
        : base(message, innerException)
    { }
}